using Microsoft.EntityFrameworkCore;
using SendingSMS.Common;
using SendingSMS.Service;

namespace SendingSMS.Model.Repository
{

    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Contact> contacts;
        private readonly IMessageService _messageService;
        //private readonly 
        public ContactRepository(ApplicationDbContext context , IMessageService messageService)
        {
            _context = context;
            _messageService= messageService;
        }
        // Get
        public async Task<Contact> GetAsync(int id, CancellationToken cancellationToken)
        {
            var res = await _context.Contacts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (res == null)
                throw new NotFoundException(nameof(res), id);

            return res;
        }
        // Get
        public async Task<List<Contact>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Contacts.AsNoTracking().ToListAsync();
        }
        // Add
        public async Task<Contact> AddAsync(Contact contact, CancellationToken cancellationToken)
        {
            await _context.AddAsync(contact);
            await _context.SaveChangesAsync();

            return contact;
        }
        // Update
        public async Task<Contact> UpdateAsync(int id, Contact contact, CancellationToken cancellationToken)
        {
            var c = await GetAsync(id, cancellationToken);
            c.PhoneNumber = contact.PhoneNumber;

            _context.Update(c);
            await _context.SaveChangesAsync();

            return contact;
        }
        // Delete
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var c = await GetAsync(id, cancellationToken);
            c.IsDeleted = true;

            _context.Update(c);
            await _context.SaveChangesAsync();

            //return contact;
        }

        public async Task<Contact> SendUrlToContcat(int id , string message , CancellationToken cancellationToken)
        {
            // find contact by id
            var contact = await GetAsync(id, cancellationToken);

            await _messageService.Send(message , contact.PhoneNumber, cancellationToken);

            return contact;
        }

    }

}
