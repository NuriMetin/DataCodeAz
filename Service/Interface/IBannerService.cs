using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IBannerService
    {
        IEnumerable<Banner> GetAllBanners();
        Task<Banner> GetBannerByIdAsync(int id);
        Task CreateBannerAsync(Banner banner);
        Task UpdateBannerAsync(int id, Banner banner);
        Task DeleteBannerAsync(Banner banner);
    }
}
