using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Security.Modules;
using Security.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Security.Controllers
{
    [ApiController]
    [Route("~/api/security/[action]")]
    public class SecurityController : ControllerBase
    {
        private readonly SecurityContext _context;

        (string appid, string secret) WeChatConfig = ("wx4589952adbf1fcbd", "1bae92d28c83c139a150b14cc30257bc");

        public SecurityController(SecurityContext context, IAuthenticationService authenticationService)
        {
            _context = context;
            auService = authenticationService;
        }

        private readonly IAuthenticationService auService;

        [HttpGet]
        public ActionResult GetUserList(int page = 1,int pageSize = 20)
        {
            List<User> users = _context.Users.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(new
            {
                success = true,
                data = users
            });
        }

        [HttpGet]
        public ActionResult GetUser(Guid id)
        {
            User user = _context.Users.SingleOrDefault(e => e.ID == id);
            return Ok(new
            {
                success = true,
                data = user
            });
        }

        [HttpPost]
        public ActionResult Regist(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new
            {
                success = true,
                data = user
            });
        }

        [HttpPost]
        public ActionResult WeChatLogin()
        {
            StreamReader reader1 = new StreamReader(HttpContext.Request.Body);
            string httpBody = string.Empty;
            Task.Run(async () =>
            {
                httpBody = await reader1.ReadToEndAsync();
            }).Wait();
            reader1.Close();

            string code = JObject.Parse(httpBody)["code"].Value<string>();
            string name = JObject.Parse(httpBody)["name"].Value<string>();
            HttpWebRequest request = WebRequest.CreateHttp(
                $"https://api.weixin.qq.com/sns/jscode2session?appid={WeChatConfig.appid}&secret={WeChatConfig.secret}&js_code={code}&grant_type=authorization_code");
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string jsonStr = string.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                jsonStr = reader.ReadToEnd();
            }

            JObject responseJson = JObject.Parse(jsonStr);
            string openid = responseJson["openid"].Value<string>();
            User user = _context.Users.SingleOrDefault(e => e.OpenID == openid);

            // 用户已经绑定了微信
            if(user != null)
            {
                auService.Login(user);
            }
            // 新用户
            else
            {
                User newUser = new User
                {
                    OpenID = openid,
                    Name = name
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();
                user = newUser;
                auService.Login(user);
            }

            return CreatedAtAction(nameof(GetMyself), new
            {
                success = true,
                data = user
            });
        }

        /// <summary>
        /// 获取已登录的用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMyself()
        {
            User user = auService.GetCurrentUser();
            return Ok(new
            {
                success = true,
                data = user
            });
        }
    }
}
