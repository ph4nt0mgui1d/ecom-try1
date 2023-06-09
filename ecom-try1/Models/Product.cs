using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecom_try1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string P_Name { get; set; }


        public string? Description { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
