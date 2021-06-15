using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IOurServiceService
    {
        IEnumerable<OurService> GetAllOurServices();
        Task<OurService> GetOurServiceByIdAsync(int id);
        Task CreateOurServiceAsync(OurService ourService);
        Task UpdateOurServiceAsync(int id, OurService ourService);
        Task DeleteOurServiceAsync(OurService ourService);
    }
}
