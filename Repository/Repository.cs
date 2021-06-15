using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _entity;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _entity = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return  _entity.ToList();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entity.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task UpdateAsync(T data)
        {
           await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T data)
        {
            _entity.Remove(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(T data)
        {
            await _entity.AddAsync(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
