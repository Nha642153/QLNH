using Microsoft.AspNetCore.Mvc;
using QuanlyNhahang_API.Data;
using QuanlyNhahang_API.Model;
using System.Collections.Generic;
using System.Linq;


namespace QuanlyNhahang_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<CategoryType> Get()
        {
            return _context.CategoryType.ToList();
        }
        [HttpPost]
        public CategoryType Post([FromBody] CategoryType CategoryType)
        {

            _context.CategoryType.Add(CategoryType);
            _context.SaveChanges();
            return CategoryType;
        }

    }
}
