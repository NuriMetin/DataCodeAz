using DataAccess.Entities;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OurServiceService : IOurServiceService
    {
        private IRepository<OurService> _repository;
        public OurServiceService(IRepository<OurService> repository)
        {
            _repository = repository;
        }

        public IEnumerable<OurService> GetAllOurServices()
        {
            return _repository.GetAll();
        }

        public async Task<OurService> GetOurServiceByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateOurServiceAsync(OurService ourService)
        {
            await _repository.CreateAsync(ourService);
        }

        public async Task UpdateOurServiceAsync(int id, OurService ourService)
        {
            OurService ourServiceFromDb = await _repository.GetByIdAsync(id);

            ourServiceFromDb.Title = ourService.Title;
            ourServiceFromDb.Image = ourService.Image;
            ourServiceFromDb.Description = ourService.Description;

            await _repository.UpdateAsync(ourServiceFromDb);
        }

        public async Task DeleteOurServiceAsync(OurService ourService)
        {
            await _repository.DeleteAsync(ourService);
        }
    }
}
