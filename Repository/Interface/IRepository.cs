using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(string id);
        Task CreateAsync(T data);
        Task UpdateAsync(T data);
        Task DeleteAsync(T data);
    }
}
