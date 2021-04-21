using JNJPBackEnd.Modules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JNJPBackEnd.Controllers
{
    [ApiController]
    [Route("/api/category/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly JNJPContext _context;

        public CategoryController(JNJPContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategory(Guid id)
        {
            //返回所有分类
            if (id == Guid.Empty)
            {
                List<Category> categories = _context.Categories.Where(e => e.ParentID == Guid.Empty)
                    .Include(c => c.SubCategories).ToList();
                return Ok(new
                {
                    success = true,
                    data = categories
                });
            }
            //返回指定ID的分类
            else
            {
                Category category = _context.Categories.Find(id);
                return Ok(new
                {
                    success = true,
                    data = category
                });
            }
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategory), new
            {
                success = true,
                date = category
            });
        }

        [HttpDelete]
        public IActionResult RemoveCategory(Guid id)
        {
            var category = _context.Categories.Include(c => c.SubCategories).SingleOrDefault(c => c.ID == id);
            _context.Remove(category);
            _context.SaveChanges();
            return Ok(new
            {
                success = true
            });
        }
    }
}
