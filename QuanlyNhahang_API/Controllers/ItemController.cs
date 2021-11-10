using Microsoft.AspNetCore.Mvc;
using QuanlyNhahang_API.Data;
using QuanlyNhahang_API.Model;
using System.Collections.Generic;
using System.Linq;

namespace QuanlyNhahang_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _context.Item.ToList();
        }
    }
}
