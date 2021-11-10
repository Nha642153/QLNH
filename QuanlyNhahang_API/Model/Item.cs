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
        public virtual Unit Unit { get; set; }
        public virtual Catogory Catogory { get; set; }
        public virtual IList<ItemImage> ItemImages { get; set; }

    }
}
