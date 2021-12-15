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
    public class StatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public StatusController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        //public IEnumerable<Status> Get()
        //{

        //return _context.Status.Where(c=> !c.Deleted)
        //                           .Include(r => r.CreatedUser)
        //                           .Include(r=> r.UpdatedUser)
        //                           .ToList(); 
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusDTO>>> Get()
        {
            try
            {
                var data = await _context.Status
                    .Include(r => r.CreatedUser)
                    .Include(r => r.UpdatedUser)
                    .Include(r=>r.Restaurant)
                    .ToArrayAsync();
                var model = _mapper.Map<IEnumerable<StatusDTO>>(data);
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
        public Status Post([FromBody] Status Status)
        {
            var createdUser = _context.User.Find(Status.CreatedUser.Id);
            Status.CreatedUser = createdUser;
            var updatedUser = _context.User.Find(Status.UpdatedUser.Id);
            Status.UpdatedUser = updatedUser;
            var restaurant = _context.Restaurant.Find(Status.Restaurant.Id);
            Status.Restaurant = restaurant;

            _context.Status.Add(Status);
            _context.SaveChanges();
            return Status;
        }
        ///<summary>
        ///Chinh sua (put)
        /// </summary>
        [HttpPut]
        public Status Put([FromBody] Status Status)
        {
            var status = _context.Status.Find(Status.Id);
            if (status == null)
            {
                return Status;
            }
            status.Name = Status.Name;
            status.Description = Status.Description;
           
            status.Deleted = Status.Deleted;
            var updatedUser = _context.User.Find((Status.UpdatedUser != null) ? Status.UpdatedUser.Id : 1);
            status.UpdatedUser = updatedUser;
            _context.SaveChanges();
            return status;
        }
    }
}
