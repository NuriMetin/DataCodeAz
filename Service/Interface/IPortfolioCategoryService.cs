using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPortfolioCategoryService
    {
        IEnumerable<PortfolioCategory> GetAllPortfolios();
        Task<PortfolioCategory> GetPortfolioByIdAsync(int id);
        Task CreatePortfolioAsync(PortfolioCategory portfolio);
        Task UpdatePortfolioAsync(int id, PortfolioCategory portfolio);
        Task DeletePortfolioAsync(PortfolioCategory portfolio);
    }
}
