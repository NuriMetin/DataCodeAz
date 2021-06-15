using DataAccess.Entites;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PortfolioService : IPortfolioService
    {
        private IRepository<Portfolio> _repository;
        public PortfolioService(IRepository<Portfolio> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Portfolio> GetAllPortfolios()
        {
            return _repository.GetAll();
        }

        public async Task<Portfolio> GetPortfolioByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreatePortfolioAsync(Portfolio portfolio)
        {
            await _repository.CreateAsync(portfolio);
        }

        public async Task UpdatePortfolioAsync(int id, Portfolio portfolio)
        {
            Portfolio portfolioFromDb = await _repository.GetByIdAsync(id);
            portfolioFromDb.Title = portfolio.Title;
            portfolioFromDb.Image = portfolio.Image;
            portfolioFromDb.PortfolioCategoryId = portfolio.PortfolioCategoryId;
            portfolioFromDb.Description = portfolio.Description;

            await _repository.UpdateAsync(portfolioFromDb);
        }

        public async Task DeletePortfolioAsync(Portfolio portfolio)
        {
            await _repository.DeleteAsync(portfolio);
        }
    }
}
