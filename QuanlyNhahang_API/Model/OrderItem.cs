using Microsoft.AspNetCore.Mvc;
using QuanlyNhahang_API.Data;
using QuanlyNhahang_API.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace QuanlyNhahang_API.Model
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Data { get; set; }
        public string Dessription { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public bool Voied { get; set; }
        public double SalePrice { get; set; }
        public virtual Item Item { get; set; }
    }
}
