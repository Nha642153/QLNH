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
    public class ItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ItemController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> Get()
        {
            try
            {
                // Task.Delay(100).Wait();
                var data = await _context.Item
                    .AsNoTracking()
                    .Include(r => r.CreatedUser)
                    .Include(r => r.UpdatedUser)
                    .Include(r => r.Restaurant)
                    .Include(r=>r.Category)
                    .Include(r=>r.ItemImage)
                    .ToArrayAsync();
                var model = _mapper.Map<IEnumerable<ItemDTO>>(data);
                return new JsonResult(model);
            }
            catch (ArgumentException)
            {
                return BadRequest("not good");
            }
        }
        [HttpPost]
        public Item Post([FromBody] Item Item)
        {
            Item.Created = DateTime.Now;
            Item.Updated = DateTime.Now;
            var createdUser = _context.User.Find(Item.CreatedUser.Id);
            Item.CreatedUser = createdUser;
            var updatedUser = _context.User.Find(Item.UpdatedUser.Id);
            Item.UpdatedUser = updatedUser;
            var restaurant = _context.Restaurant.Find(Item.Restaurant.Id);
            Item.Restaurant = restaurant;
            var caterogy = _context.Category.Find(Item.Category.Id);
            Item.Category = caterogy;
            var itemImage = _context.ItemImage.Find(Item.ItemImage.Id);
            Item.ItemImage = itemImage;


            _context.Item.Add(Item);
            _context.SaveChanges();
            return Item;
        }
        [HttpPut]
        public Item Put([FromBody] Item Item)
        {
            Item.Updated = DateTime.Now;
            var item = _context.Item.Find(Item.Id);
            if (item == null)
            {
                return Item;
            }
            item.Name = Item.Name;
            item.Description = Item.Description;
            item.Price = Item.Price;
            item.Discount = Item.Discount;
            item.Deleted = Item.Deleted;
            
            var updatedUser = _context.User.Find((Item.UpdatedUser != null) ? Item.UpdatedUser.Id : 1);
            item.UpdatedUser = updatedUser;
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}

