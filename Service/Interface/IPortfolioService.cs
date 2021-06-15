using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPortfolioService
    {
        IEnumerable<Portfolio> GetAllPortfolios();
        Task<Portfolio> GetPortfolioByIdAsync(int id);
        Task CreatePortfolioAsync(Portfolio portfolioItem);
        Task UpdatePortfolioAsync(int id, Portfolio portfolioItem);
        Task DeletePortfolioAsync(Portfolio portfolioItem);
    }
}
