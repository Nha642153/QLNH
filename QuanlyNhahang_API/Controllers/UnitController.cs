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
    public class UnitController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UnitController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitDTO>>> Get()
        {
            try
            {
                // Task.Delay(100).Wait();
                var data = await _context.Unit
                    .Include(r => r.CreatedUser)
                    .Include(r => r.UpdatedUser)
                    .Include(r => r.Restaurant)
                    .Include(r=>r.UnitType)
                    .ToArrayAsync();
                var model = _mapper.Map<IEnumerable<UnitDTO>>(data);
                return new JsonResult(model);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("not good");
            }
        }
        [HttpPost]
        public Unit Post([FromBody] Unit Unit)
        {
            Unit.Created = DateTime.Now;
            var createdUser = _context.User.Find(Unit.CreatedUser.Id);
            Unit.CreatedUser = createdUser;
            var updatedUser = _context.User.Find(Unit.UpdatedUser.Id);
            Unit.UpdatedUser = updatedUser;

            _context.Unit.Add(Unit);
            _context.SaveChanges();
            return Unit;
        }
        [HttpPut]
        public Unit Put([FromBody] Unit Unit)
        {
            Unit.Updated = DateTime.Now;
            var unit = _context.Unit.Find(Unit.Id);
            if (unit == null)
            {
                return Unit;
            }
            unit.Name = Unit.Name;
            unit.Description = Unit.Description;
         
            unit.Deleted = Unit.Deleted;
            var updatedUser = _context.User.Find((Unit.UpdatedUser != null) ? Unit.UpdatedUser.Id : 1);
            unit.UpdatedUser = updatedUser;
            _context.SaveChanges();
            return unit;
        }
    }
}
