using System;
using System.ComponentModel.DataAnnotations;

namespace EntityCrudExample
{
    public class Users
    {
        [Key]
        public Guid Id { get; set; }

        [MinLength(1), MaxLength(30), Required]
        public String FirstName { get; set; }

        [MinLength(1), MaxLength(30), Required]
        public String LastName { get; set; }

        [MinLength(1), MaxLength(80), Required, EmailAddress]
        public String Email { get; set; }
    }
}