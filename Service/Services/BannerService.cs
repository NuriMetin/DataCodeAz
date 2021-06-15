using DataAccess.Entites;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BannerService : IBannerService
    {
        private IRepository<Banner> _repository;

        public BannerService(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Banner> GetAllBanners()
        {
            return _repository.GetAll();
        }

        public async Task<Banner> GetBannerByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateBannerAsync(Banner banner)
        {
            await _repository.CreateAsync(banner);
            
        } 
        public async Task UpdateBannerAsync(int id, Banner banner)
        {
            Banner bannerFromDb = await _repository.GetByIdAsync(id);

            bannerFromDb.Title = banner.Title;
            bannerFromDb.Image = banner.Image;
            bannerFromDb.Description = banner.Description;

            await _repository.UpdateAsync(bannerFromDb);
        }

        public async Task DeleteBannerAsync(Banner banner)
        {
            await _repository.DeleteAsync(banner);
        }
    }
}
