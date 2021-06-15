using DataAccess.Entities;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CustomerService : ICustomerService
    {
        private IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Customer> GetAllCustumers()
        {
            return _repository.GetAll();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _repository.CreateAsync(customer);
        }

        public async Task UpdateCustomerAsync(int id, Customer customer)
        {
            Customer customerFromDb = await _repository.GetByIdAsync(id);

            customerFromDb.Name = customer.Name;
            customerFromDb.Image = customer.Image;
            customerFromDb.Description = customer.Description;

            await _repository.UpdateAsync(customerFromDb);
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            await _repository.DeleteAsync(customer);
        }
    }
}
