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
    public class GuestController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GuestController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        //public IEnumerable<Guest> Get()
        //{

        //return _context.Guest.Where(c=> !c.Deleted)
        //                           .Include(r => r.CreatedUser)
        //                           .Include(r=> r.UpdatedUser)
        //                           .ToList(); 
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> Get()
        {
            try
            {
                var data = await _context.Guest.Include(r => r.CreatedUser).Include(r => r.UpdatedUser).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<GuestDTO>>(data);
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
        public Guest Post([FromBody] Guest Guest)
        {
            var createdUser = _context.User.Find(Guest.CreatedUser.Id);
            Guest.CreatedUser = createdUser;
            var updatedUser = _context.User.Find(Guest.UpdatedUser.Id);
            Guest.UpdatedUser = updatedUser;

            _context.Guest.Add(Guest);
            _context.SaveChanges();
            return Guest;
        }
        ///<summary>
        ///Chinh sua (put)
        /// </summary>
        [HttpPut]
        public Guest Put([FromBody] Guest Guest)
        {
            var guest = _context.Guest.Find(Guest.Id);
            if (guest == null)
            {
                return Guest;
            }
            guest.Name = Guest.Name;
            guest.Description = Guest.Description;
            guest.Phone = Guest.Phone;
            
            guest.Deleted = Guest.Deleted;
            var updatedUser = _context.User.Find((Guest.UpdatedUser != null) ? Guest.UpdatedUser.Id : 1);
            guest.UpdatedUser = updatedUser;
            _context.SaveChanges();
            return guest;
        }
    }
}
