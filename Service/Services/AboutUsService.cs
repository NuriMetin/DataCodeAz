using DataAccess.Entities;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AboutUsService : IAboutUsService
    {
        private IRepository<AboutUs> _repository;

        public AboutUsService(IRepository<AboutUs> repository)
        {
            _repository = repository;
        }

        public IEnumerable<AboutUs> GetAllAboutUs()
        {
            return _repository.GetAll();
        }

        public async Task<AboutUs> GetAboutUsByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAboutAsync(AboutUs about)
        {
            await _repository.CreateAsync(about);
        }

        public async Task UpdateAboutUsAsync(int id, AboutUs aboutUs)
        {

            AboutUs aboutUsFromDb = await _repository.GetByIdAsync(id);

            aboutUsFromDb.Title = aboutUs.Title;
            aboutUsFromDb.Image = aboutUs.Image;
            aboutUsFromDb.Description = aboutUs.Description;

            await _repository.UpdateAsync(aboutUsFromDb);
        }

        public async Task DeleteAboutUsAsync(AboutUs about)
        {
            await _repository.DeleteAsync(about);
        }
    }
}
