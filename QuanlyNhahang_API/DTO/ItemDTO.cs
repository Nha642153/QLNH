using QuanlyNhahang_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanlyNhahang_API.DTO
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public double Discount { get; set; }
        public int Quatity { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public RestaurantDTO Restaurant { get; set; }

        public UserDTO CreatedUser { get; set; }
        public UserDTO UpdatedUser { get; set; }
        public  CategoryDTO Category { get; set; }
        public  ItemImageDTO ItemImage { get; set; }
    }
}
