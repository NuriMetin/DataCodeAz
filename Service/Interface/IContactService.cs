using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
        Task<Contact> GetContactByIdAsync(int id);
        Task CreateContactAsync(Contact contact);
        Task UpdateContactAsync(int id, Contact contact);
        Task DeleteContactAsync(Contact contact);
        bool SendMail(string from, string message);
    }
}
