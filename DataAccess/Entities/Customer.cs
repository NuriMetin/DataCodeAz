using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
