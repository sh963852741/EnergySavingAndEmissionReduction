using JNJPBackEnd.Modules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JNJPBackEnd.Controllers
{
    [Route("api/maquillage/[action]")]
    [ApiController]
    public class MaquillageController : ControllerBase
    {

        private readonly JNJPContext _context;

        public MaquillageController(JNJPContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult GetList(int page = 1, int pageSize = 20)
        {
            List<Maquillage> m = _context.Maquillages.Skip((page - 1) * pageSize).Take(pageSize).Include(e => e.Category).ToList();

            return Ok(new
            {
                success = true,
                page,
                pageSize,
                data = m
            });
        }

        [HttpGet]
        public ActionResult Get(Guid id)
        {
            Maquillage maquillage = _context.Maquillages.Include(e => e.Category).SingleOrDefault(e => id == e.ID);

            return Ok(new
            {
                success = true,
                data = maquillage
            });
        }


        [HttpPost]
        public ActionResult Post([FromBody] Maquillage newMaquillage)
        {
            _context.Maquillages.Add(newMaquillage);
            _context.SaveChanges();

            return Ok(new
            {
                success = true,
                data = newMaquillage
            });
        }


        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            Maquillage maquillage = _context.Maquillages.Find(id);
            if(maquillage != null)
            {
                _context.Maquillages.Remove(maquillage);
                _context.SaveChanges();

                return Ok(new
                {
                    success = true
                });
            }
            else
            {
                return Ok(new
                {
                    success = false,
                    message = "找不到对应化妆品"
                });
            }
        }
    }
}
