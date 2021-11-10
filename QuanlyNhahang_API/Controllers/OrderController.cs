﻿using Microsoft.AspNetCore.Mvc;
using QuanlyNhahang_API.Data;
using QuanlyNhahang_API.Model;
using System.Collections.Generic;
using System.Linq;

namespace QuanlyNhahang_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _context.Order.ToList();
        }
    }
}