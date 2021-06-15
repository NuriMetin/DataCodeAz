using DataAccess.Entites;
using DataAccess.Entities;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ContactService : IContactService
    {
        private IRepository<Contact> _repository;

        public ContactService(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _repository.GetAll();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateContactAsync(Contact contact)
        {
            await _repository.CreateAsync(contact);
        }
        public async Task UpdateContactAsync(int id, Contact contact)
        {
            Contact contactFromDb = await _repository.GetByIdAsync(id);

            contactFromDb.Name = contact.Name;
            contactFromDb.Surname = contact.Surname;
            contactFromDb.Email = contact.Email;
            contactFromDb.Message = contact.Message;

            await _repository.UpdateAsync(contactFromDb);
        }

        public async Task DeleteContactAsync(Contact contact)
        {
            await _repository.DeleteAsync(contact);
        }

        public bool SendMail(string from, string message)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("datacode2020@gmail.com", "");
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add("info@datacode.az");
                mailMessage.From = new MailAddress(from);

                mailMessage.Subject = "Message from: " + from;
                mailMessage.Body = message;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);
                mailMessage.IsBodyHtml = true;

                return true;
            }

            catch
            {
                return false;
            }
        }
    }
}
