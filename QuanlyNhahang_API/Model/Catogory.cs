using QuanlyNhahang_API.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanlyNhahang_API.Model
{
    public class Catogory
    {
        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        
        public virtual Catogory Parent { get; set; }
        public virtual Catogory Children { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User UpdatedUser { get; set; }

    }
}
