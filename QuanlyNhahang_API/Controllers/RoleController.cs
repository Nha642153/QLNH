using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanlyNhahang_API.Data;
using QuanlyNhahang_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanlyNhahang_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class RoleController : ControllerBase
    {
            private readonly ApplicationDbContext _context;
            public RoleController(ApplicationDbContext context)
            {
                _context = context;
            }
        [DisableCors]
        [HttpGet]
        
        public IEnumerable<Role> Get()
            {
                return _context.Role.ToList();
            }
        ///<summary>
        ///Lay Quyen voi Id
        ///</summary>
        ///<returns>Danh sach Role</returns>
        
        [HttpGet("Id")]
        public Role Get([FromQuery] int Id)
        {
            return _context.Role.Where(role => role.Id == Id).FirstOrDefault();
        }
        ///<summary>
        ///Them Quyen
        /// </summary>
        [HttpPost]
        public Role Post([FromQuery]Role Role)
        {
            _context.Role.Add(Role);
            _context.SaveChanges();
            return Role;
        }
     }
}
