using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanlyNhahang_API.Data;
using QuanlyNhahang_API.DTO;
using QuanlyNhahang_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanlyNhahang_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoryController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            try
            {
                // Task.Delay(100).Wait();
                var data = await _context.Category
                    .Include(r => r.CreatedUser)
                    .Include(r => r.UpdatedUser)
                    .Include(r => r.Restaurant)
                    .Include(r => r.CategoryType)
                    .ToArrayAsync();
                var model = _mapper.Map<IEnumerable<CategoryDTO>>(data);
                return new JsonResult(model);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("not good");
            }
        }
        [HttpPost]
        public Category Post([FromBody] Category Category)
        {
            Category.Created = DateTime.Now;
            Category.Updated = DateTime.Now;
            var createdUser = _context.User.Find(Category.CreatedUser.Id);
            Category.CreatedUser = createdUser;
            var updatedUser = _context.User.Find(Category.UpdatedUser.Id);
            Category.UpdatedUser = updatedUser;
            var restaurant = _context.Restaurant.Find(Category.Restaurant.Id);
            Category.Restaurant = restaurant;
            var unitType = _context.CategoryType.Find(Category.CategoryType.Id);
            Category.CategoryType = unitType;

            _context.Category.Add(Category);
            _context.SaveChanges();
            return Category;
        }
        [HttpPut]
        public Category Put([FromBody] Category Category)
        {
            Category.Updated = DateTime.Now;
            var unit = _context.Category.Find(Category.Id);
            if (unit == null)
            {
                return Category;
            }
            unit.Name = Category.Name;
            unit.Description = Category.Description;

            unit.Deleted = Category.Deleted;
            var updatedUser = _context.User.Find((Category.UpdatedUser != null) ? Category.UpdatedUser.Id : 1);
            unit.UpdatedUser = updatedUser;
            _context.SaveChanges();
            return unit;
        }
    }
}

