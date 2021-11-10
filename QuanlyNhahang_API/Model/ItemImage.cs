using System;
using System.ComponentModel.DataAnnotations;
namespace QuanlyNhahang_API.Model
{
    public class ItemImage
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Data { get; set; }
        public string Dessription { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
    }
}