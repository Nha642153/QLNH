using QuanlyNhahang_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanlyNhahang_API.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        //public string PassWord { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; }
        public bool OffDuty { get; set; }
        public virtual Role Role { get; set; }
        public IEnumerable<UserDTO> CreatedUser { get; set; }
        public IEnumerable<UserDTO> UpdatedUser { get; set; }
    }
}
