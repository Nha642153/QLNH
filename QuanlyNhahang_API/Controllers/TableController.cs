using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuanlyNhahang_API.Data;
using System.Collections.Generic;
using System.Linq;

namespace QuanlyNhahang_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TableController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Table> Get()
        {
            return (IEnumerable<Table>)_context.Table.ToList();
        }
    }
}
