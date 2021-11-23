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
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            try
            {
                var data = await _context.User
                    //.Include(r => r.CreatedUser)
                    //.Include(r => r.UpdatedUser)
                    .Include(r=> r.Role)
                
                    .ToArrayAsync();
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
        ///Them User
        /// </summary>
        [HttpPost]
        public User Post([FromBody] User User)
        {
            //var createdUser = _context.User.Find(User.CreatedUserId);
            //User.CreatedUser = (IEnumerable<User>)createdUser;
            //var updatedUser = _context.User.Find(User.UpdatedUserId);
            //User.UpdatedUser = (IEnumerable<User>)updatedUser;
            User.Created = DateTime.Now;
            User.Updated = DateTime.Now;
            var role = _context.Role.Find((User.Role != null) ? User.Role.Id : 0);
            User.Role = role;
            _context.User.Add(User);
            _context.SaveChanges();
            return User;
        }
        [HttpPut]
        public User Put([FromBody] User User)
        {
            User.Updated = DateTime.Now;
            var user = _context.User.Find(User.Id);
            if (user == null)
            {
                return User;
            }
            user.UserName= User.UserName;
            user.Description = User.Description;
            user.Phone = User.Phone;
            user.Address = User.Address;
            user.Deleted = User.Deleted;
            var updatedUser = _context.User.Find((User.UpdatedUser != null) ? User.UpdatedUserId : 1);
            user.UpdatedUser = (IEnumerable<User>)updatedUser;
            _context.SaveChanges();
            return user;
        }
    }
}
