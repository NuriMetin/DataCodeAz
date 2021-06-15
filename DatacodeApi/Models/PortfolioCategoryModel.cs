using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatacodeApi.Models
{
    public class PortfolioCategoryModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public IEnumerable<Portfolio> Portfolios { get; set; }
    }
}
