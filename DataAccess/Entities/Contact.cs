using DataAccess.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Contact : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Must be email address")]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string Message { get; set; }

        private DateTime _time = DateTime.Now;
        public DateTime Time { get { return _time; } private set { } }

        private bool _seen = false;
        public bool Seen { get { return _seen; } set { _seen = value; } }
    }
}
