using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanlyNhahang_API.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        
        public string PassWord { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public bool OffDuty { get; set; }
        public virtual Role Role { get; set; }
        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }
        [NotMapped]
        public IEnumerable<User> CreatedUser { get; set; }
        [NotMapped]
        public IEnumerable<User> UpdatedUser { get; set; }

      
    }
}
