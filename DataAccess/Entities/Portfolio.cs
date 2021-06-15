using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entites
{
    public class Portfolio : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        public string Image { get; set; }

        [Required]
        public int PortfolioCategoryId { get; set; }
        public virtual PortfolioCategory PortfolioCategory { get; set; }
    }
}
