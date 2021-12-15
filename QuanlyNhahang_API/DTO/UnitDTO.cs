﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanlyNhahang_API.Model;

namespace QuanlyNhahang_API.DTO
{
    public class UnitDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public UnitType UnitType { get; set; }
        public RestaurantDTO Restaurant { get; set; }
        public UserDTO CreatedUser { get; set; }
        public UserDTO UpdatedUser { get; set; }
    }
}