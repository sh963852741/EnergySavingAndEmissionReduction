using JNJPBackEnd.Modules;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
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

        public RecycleController(JNJPContext context, IAuthenticationService authenticationService)
        {
            _context = context;
            auService = authenticationService;
        }

        private readonly IAuthenticationService auService;

        [HttpPost]
        public ActionResult SubmitForm([FromBody] RecycleForm form)
        {
            _context.RecycleForms.Add(form);

            _context.SaveChanges();

            return Ok(new
            {
                success = true,
                data = form
            });
        }
    }
}
