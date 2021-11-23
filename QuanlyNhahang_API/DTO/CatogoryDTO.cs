using QuanlyNhahang_API.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanlyNhahang_API.DTO
{
    public class CatogoryDTO
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        [ForeignKey("ParentId")]
        public virtual CatogoryDTO Parent { get; set; }
        public virtual ICollection<CatogoryDTO> Children { get; set; }
        public RestaurantDTO RestaurantDTO { get; set; }
        public UserDTO CreatedUser { get; set; }
        public UserDTO UpdatedUser { get; set; }

        
    }
}
