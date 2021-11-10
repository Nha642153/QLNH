﻿using System;
using System.ComponentModel.DataAnnotations;

namespace QuanlyNhahang_API.Model
{
    public class Catogory
    {
        [Key]
        public int Id { get; set; }
        public int parentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
    }
}