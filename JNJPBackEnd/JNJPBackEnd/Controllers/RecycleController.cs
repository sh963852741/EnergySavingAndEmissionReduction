using JNJPBackEnd.Hubs;
using JNJPBackEnd.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Security.Modules;
using Security.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JNJPBackEnd.Controllers
{
    [ApiController]
    [Route("/api/recycle/[action]")]
    public class RecycleController : ControllerBase
    {
        private readonly JNJPContext _context;
        private readonly IAuthenticationService auService;
        private readonly IHubContext<RecycleHub> _recycleHub;

        public RecycleController(JNJPContext context, IAuthenticationService authenticationService, IHubContext<RecycleHub> recycleHub)
        {
            _context = context;
            auService = authenticationService;
            _recycleHub = recycleHub;
        }

        
        /// <summary>
        /// 用户新建表单
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateForm([FromBody] RecycleForm form)
        {
            Category category = _context.Categories.Find(form.CategoryID);
            if(category == null)
            {
                return Ok(new
                {
                    success = false,
                    message = "类别ID不存在"
                });
            }

            User user = auService.GetCurrentUser();
            form.UserID = user.ID;

            form.State = RecycleFormState.Created;
            _context.RecycleForms.Add(form);
            _context.SaveChanges();
            _recycleHub.Clients.All.SendAsync("OpenBox", form.ID);

            return Ok(new
            {
                success = true,
                data = form
            });
        }

        /// <summary>
        /// 用户确认提交表单
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult SubmitForm([FromQuery] Guid formId)
        {
            RecycleForm form = _context.RecycleForms.Find(formId);
            if (form == null)
            {
                return Ok(new
                {
                    success = false,
                    message = "表单不存在"
                });
            }
            form.State = RecycleFormState.UserSubmited;
            _context.RecycleForms.Update(form);
            _context.SaveChanges();

            return Ok(new
            {
                success = true,
                data = form
            });
        }

        /// <summary>
        /// 用户确认提交表单
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult CompleteForm([FromQuery] Guid formId)
        {
            RecycleForm form = _context.RecycleForms.Find(formId);
            if (form == null)
            {
                return Ok(new
                {
                    success = false,
                    message = "表单不存在"
                });
            }
            form.State = RecycleFormState.Complete;
            _context.RecycleForms.Update(form);
            _context.SaveChanges();

            return Ok(new
            {
                success = true,
                data = form
            });
        }

        [HttpGet]
        public ActionResult GetAllForm(int page = 10, int pageSize = 20)
        {
            List<RecycleForm> forms = _context.RecycleForms.Skip((page - 1) * pageSize).Take(pageSize).Include(e => e.User).Include(e => e.Category).ToList();

            return Ok(new
            {
                success = true,
                page,
                pageSize,
                data = forms
            });
        }

        [HttpDelete]
        public ActionResult DeleteForm(Guid id)
        {
            RecycleForm form = _context.RecycleForms.Find(id);

            if(form == null)
            {
                return Ok(new
                {
                    success = false,
                    message = "表单不存在"
                });
            }

            _context.RecycleForms.Remove(form);
            _context.SaveChanges();

            return Ok(new
            {
                success = true
            });
        }
    }
}
