using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanlyNhahang_API.DTO
{
    public class StatusDTO
    {
        public int Id { get; set; }
        public int parentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public RestaurantDTO RestaurantDTO { get; set; }
        public UserDTO CreatedUser { get; set; }
        public UserDTO UpdatedUser { get; set; }
    }
}
