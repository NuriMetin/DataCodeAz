using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entites
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int ID { get; set; }
    }
}
