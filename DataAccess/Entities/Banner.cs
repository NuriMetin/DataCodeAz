using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entites
{
    public class Banner : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
