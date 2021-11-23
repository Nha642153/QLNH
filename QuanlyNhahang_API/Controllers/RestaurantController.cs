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
    public class RestaurantController : ControllerBase
    {
            
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;
            public RestaurantController(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                 _mapper = mapper;
            }
            
            [HttpGet]

            //public IEnumerable<Restaurant> Get()
            //{

            //return _context.Restaurant.Where(c=> !c.Deleted)
            //                           .Include(r => r.CreatedUser)
            //                           .Include(r=> r.UpdatedUser)
            //                           .ToList(); 
            //}
            
            
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Restaurant>>> Get()
            {
            try
            {
                Task.Delay(100).Wait();
                var data = await _context.Restaurant.Include(r => r.CreatedUser).Include(r => r.UpdatedUser).ToArrayAsync();
                var model = _mapper.Map<IEnumerable<RestaurantDTO>>(data);
                return new JsonResult(model);
            }catch (ArgumentException ex)
            {
                return BadRequest("not good");
            }
            }
            ///<summary>
            ///Them Nha hang
            /// </summary>
            [HttpPost]
            public Restaurant Post([FromBody] Restaurant Restaurant)
            {
                var createdUser = _context.User.Find(Restaurant.CreatedUser.Id);
                Restaurant.CreatedUser = createdUser;
                var updatedUser = _context.User.Find(Restaurant.UpdatedUser.Id);
                Restaurant.UpdatedUser = updatedUser;

               _context.Restaurant.Add(Restaurant);
               _context.SaveChanges();
                return Restaurant;
            }
            ///<summary>
            ///Chinh sua (put)
            /// </summary>
            [HttpPut]
            public Restaurant Put([FromBody] Restaurant Restaurant)
            {
            Restaurant.Updated = DateTime.Now;
            var restaurant = _context.Restaurant.Find(Restaurant.Id);
            if (restaurant == null)
            {
                return Restaurant;
            }
            restaurant.Name = Restaurant.Name;
            restaurant.Description = Restaurant.Description;
            restaurant.Phone = Restaurant.Phone;
            restaurant.Address = Restaurant.Address;
            restaurant.Deleted = Restaurant.Deleted;
            var updatedUser = _context.User.Find((Restaurant.UpdatedUser != null) ? Restaurant.UpdatedUser.Id : 1);
            restaurant.UpdatedUser = updatedUser;
            _context.SaveChanges();
            return restaurant;
            }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Restaurant >> DeleteRestaurant(int id)
        {
            try
            {
                var data = _context.Restaurant.Find(id);

                if (data == null)
                {
                    return NotFound($"Restaurant with Id = {id} not found");
                }

                return new JsonResult(data); ;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
