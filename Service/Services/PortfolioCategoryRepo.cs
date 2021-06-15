using DataAccess.Entities;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PortfolioCategoryRepo : IPortfolioCategoryService
    {
        private IRepository<PortfolioCategory> _repository;

        public PortfolioCategoryRepo(IRepository<PortfolioCategory> repository)
        {
            _repository = repository;
        }

        public IEnumerable<PortfolioCategory> GetAllPortfolios()
        {
            return _repository.GetAll();
        }

        public async Task<PortfolioCategory> GetPortfolioByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreatePortfolioAsync(PortfolioCategory category)
        {
            await _repository.CreateAsync(category);
        }

        public async Task UpdatePortfolioAsync(int id, PortfolioCategory category)
        {
            PortfolioCategory categoryFromDb = await _repository.GetByIdAsync(id);

            categoryFromDb.Name = category.Name;
            await _repository.UpdateAsync(category);
        }

        public async Task DeletePortfolioAsync(PortfolioCategory category)
        {
            await _repository.DeleteAsync(category);
        }
    }
}
