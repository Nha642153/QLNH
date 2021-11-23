﻿using System;
using System.ComponentModel.DataAnnotations;

namespace QuanlyNhahang_API.Model
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public int parentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User UpdatedUser { get; set; }
    }
}