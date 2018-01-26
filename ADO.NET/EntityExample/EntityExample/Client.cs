using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace EntityExample
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(180), MinLength(3), Required]
        public string FirstName { get; set; }

        [MaxLength(180), MinLength(3), Required]
        public string LastName { get; set; }

        [Column(TypeName = "datetime2"), Required]
        public DateTime RegisterDate { get; set; }
    }
}