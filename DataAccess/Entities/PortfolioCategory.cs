using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class PortfolioCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Portfolio> Portfolios { get; set; }
    }
}
