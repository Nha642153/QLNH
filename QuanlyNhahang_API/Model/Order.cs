using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanlyNhahang_API.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string OrderNumber { get; set; }
        public string Dessription { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public bool Voided { get; set; }
        public double TotalPrice { get; set; }
        public virtual IList<OrderItem> OrderItem { get; set; }
    }
}
