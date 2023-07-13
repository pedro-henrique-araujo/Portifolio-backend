using Portifolio.Data;

namespace Portifolio.Services
{
    public interface IContactService
    {
        Task CreateAsync(Contact contact);
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(Guid id);
    }
}