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
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RoleController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        //public IEnumerable<Role> Get()
        //{

        //return _context.Role.Where(c=> !c.Deleted)
        //                           .Include(r => r.CreatedUser)
        //                           .Include(r=> r.UpdatedUser)
        //                           .ToList(); 
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            try
            {
                var data = await _context.Role.ToArrayAsync();
                var model = _mapper.Map<IEnumerable<RoleDTO>>(data);
                return new JsonResult(model);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("not good");
            }
        }
        ///<summary>
        ///Them Nha hang
        /// </summary>
        [HttpPost]
        public Role Post([FromBody] Role Role)
        {
            
            _context.Role.Add(Role);
            _context.SaveChanges();
            return Role;
        }
        ///<summary>
        ///Chinh sua (put)
        /// </summary>
        [HttpPut]
        public Role Put([FromBody] Role Role)
        {
            var role = _context.Role.Find(Role.Id);
            if (role == null)
            {
                return Role;
            }
            role.Name = Role.Name;
            role.Description = Role.Description;
            role.Deleted = Role.Deleted;

            role.Updated = DateTime.Now;
            _context.SaveChanges();
            return role;
        }
    }
}
