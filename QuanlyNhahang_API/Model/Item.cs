using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanlyNhahang_API.Model
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public double Discount { get; set; }
        public int Quatity { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User UpdatedUser { get; set; }
        public virtual Category Category { get; set; }
        public virtual ItemImage ItemImage { get; set; }

    }
}
