using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IAboutUsService
    {
        IEnumerable<AboutUs> GetAllAboutUs();
        Task<AboutUs> GetAboutUsByIdAsync(int id);
        Task CreateAboutAsync(AboutUs about);
        Task UpdateAboutUsAsync(int id, AboutUs about);
        Task DeleteAboutUsAsync(AboutUs about);
    }
}
