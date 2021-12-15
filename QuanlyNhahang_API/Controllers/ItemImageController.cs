using AutoMapper;
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
    public class ItemImageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ItemImageController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemImageDTO>>> Get()
        {
            try
            {
                // Task.Delay(100).Wait();
                var data = await _context.ItemImage.AsNoTracking()
                    
                    .Include(r => r.CreatedUser)
                    .Include(r => r.UpdatedUser)
                   
                    .ToArrayAsync();
                var model = _mapper.Map<IEnumerable<ItemImageDTO>>(data);
                return new JsonResult(model);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("not good");
            }
        }
        [HttpPost]
        public ItemImage Post([FromBody] ItemImage ItemImage)
        {
            ItemImage.Created = DateTime.Now;
            ItemImage.Updated = DateTime.Now;
            var createdUser = _context.User.Find(ItemImage.CreatedUser.Id);
            ItemImage.CreatedUser = createdUser;
            var updatedUser = _context.User.Find(ItemImage.UpdatedUser.Id);
            ItemImage.UpdatedUser = updatedUser;

            _context.ItemImage.Add(ItemImage);
            _context.SaveChanges();
            return ItemImage;
        }
        [HttpPut]
        public ItemImage Put([FromBody] ItemImage ItemImage)
        {
            ItemImage.Updated = DateTime.Now;
            var itemImage = _context.ItemImage.Find(ItemImage.Id);
            if (itemImage == null)
            {
                return ItemImage;
            }
            itemImage.Name = ItemImage.Name;
            itemImage.Description = ItemImage.Description;

            itemImage.Deleted = ItemImage.Deleted;
            var updatedUser = _context.User.Find((ItemImage.UpdatedUser != null) ? ItemImage.UpdatedUser.Id : 1);
            itemImage.UpdatedUser = updatedUser;
            _context.SaveChanges();
            return itemImage;
        }
    }
}
