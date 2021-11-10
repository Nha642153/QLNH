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
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //[HttpGet]
        //public IEnumerable<User> Get()
        //{
        //    return _context.User.ToList();
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            try
            {
                var data = await _context.User.Select(d => new User
                {
                    Id = d.Id,
                    UserName = d.UserName,
                    Description = d.Description,
                    Updated = d.Updated,
                    Deleted = d.Deleted,
                    OffDuty = d.OffDuty,
                    Role = d.Role,
                    CreatedUser = _context.User.Where(c => c.Id == d.CreatedUserId).Select(s => new User
                    {
                        Id = s.Id,
                        UserName = s.UserName,
                        Description = s.Description,
                        Updated = d.Updated,
                        Deleted = d.Deleted,
                        OffDuty = d.OffDuty,
                        Role = d.Role
                    }).ToList(),
                    UpdatedUser = _context.User.Where(c => c.Id == d.UpdatedUserId).Select(s => new User
                    {
                        Id = s.Id,
                        UserName = s.UserName,
                        Description = s.Description,
                        Updated = d.Updated,
                        Deleted = d.Deleted,
                        OffDuty = d.OffDuty,
                        Role = d.Role
                    }).ToList()
                }).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<UserDTO>>(data);
                return new JsonResult(model);
                
            }
            catch (ArgumentException ex)
            {
                return BadRequest("not good");
            }
        }

        [HttpGet("Id")]
        public User Get([FromQuery] int Id)
        {
            return _context.User.Where(user => user.Id == Id).FirstOrDefault();
        }
        ///<summary>
        ///Them Quyen
        /// </summary>
        [HttpPost]
        public User Post([FromQuery] User User)
        {
            
            _context.User.Add(User);
            _context.SaveChanges();
            return User;
        }
    }
}
