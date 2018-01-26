using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntityCrudExample
{
    public class Orders
    {
        [Key]
        public Guid Id { get; set; }

        [MinLength(2), MaxLength(180), Required]
        public String Product { get; set; }

        [Required, DefaultValue(0)]
        public int Price { get; set; }

        [Required, DefaultValue(0)]
        public int Qty { get; set; }

        [Required]
        public virtual Users IdUser { get; set; }
    }
}