using Microsoft.EntityFrameworkCore;
using Portifolio.Data;

namespace Portifolio.Services
{
    public class ContactService : IContactService
    {
        private readonly PortifolioDbContext _dbContext;

        public ContactService(PortifolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            var output = await _dbContext.Set<Contact>()
                .OrderByDescending(c => c.Created)
                .ToListAsync();

            return output;
        }

        public async Task<Contact> GetByIdAsync(Guid id)
        {
            var output = await _dbContext.Set<Contact>().FirstOrDefaultAsync(x => x.Id == id);

            return output;
        }

        public async Task CreateAsync(Contact contact)
        {
            contact.Id = Guid.NewGuid();

            contact.Created = DateTime.Now;

            await _dbContext.AddAsync<Contact>(contact);

            await _dbContext.SaveChangesAsync();
        }

    }
}