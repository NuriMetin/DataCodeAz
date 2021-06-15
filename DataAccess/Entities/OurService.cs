using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class OurService : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
