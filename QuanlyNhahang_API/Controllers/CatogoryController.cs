using AutoMapper;
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
    public class CatogoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CatogoryController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatogoryDTO>>> Get()
        {
            try
            {
                var data = await _context.Catogory
                    .Include(r => r.CreatedUser)
                    .Include(r => r.UpdatedUser)
                    .Include(r => r.Restaurant)
                    .Include(r=>r.Children)
                    .Include(r=>r.Parent)
                    .ToArrayAsync();
                var model = _mapper.Map<IEnumerable<CatogoryDTO>>(data);
                return new JsonResult(model);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("not good");
            }
        }
        [HttpPost]
        public Catogory Post([FromBody] Catogory Catogory)
        {
            Catogory.Created = DateTime.Now;
            Catogory.Updated = DateTime.Now;
            var createdUser = _context.User.Find(Catogory.CreatedUser.Id);
            Catogory.CreatedUser = createdUser;
            var updatedUser = _context.User.Find(Catogory.UpdatedUser.Id);
            Catogory.UpdatedUser = updatedUser;
            var restaurant = _context.Restaurant.Find(Catogory.Restaurant.Id);
            Catogory.Restaurant = restaurant;
            var parent = _context.Catogory.Find(Catogory.Parent?.Id);
            Catogory.Parent = parent;

            _context.Catogory.Add(Catogory);
            _context.SaveChanges();
            return Catogory;
        }
        [HttpPut]
        public Catogory Put([FromBody] Catogory Catogory)
        {
            Catogory.Updated = DateTime.Now;
            var catogory = _context.Catogory.Find(Catogory.Id);
            if (catogory == null)
            {
                return Catogory;
            }
            catogory.Name = Catogory.Name;
            catogory.Description =Catogory.Description;
           
            catogory.Deleted = Catogory.Deleted;
            var updatedUser = _context.User.Find((Catogory.UpdatedUser != null) ? Catogory.UpdatedUser.Id : 1);
            catogory.UpdatedUser = updatedUser;
            _context.SaveChanges();
            return catogory;
        }


    }
}
