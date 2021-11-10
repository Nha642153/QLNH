using Microsoft.AspNetCore.Mvc;
using QuanlyNhahang_API.Data;
using QuanlyNhahang_API.Model;
using System.Collections.Generic;
using System.Linq;

namespace QuanlyNhahang_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatogoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CatogoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Catogory> Get()
        {
            return _context.Catogory.ToList();
        }


    }
}
