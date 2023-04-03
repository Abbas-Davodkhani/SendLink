namespace SendingSMS.Model.Repository
{
    public interface IContactRepository
    {
        Task<Contact> AddAsync(Contact contact, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<List<Contact>> GetAllAsync(CancellationToken cancellationToken);
        Task<Contact> GetAsync(int id, CancellationToken cancellationToken);
        Task<Contact> UpdateAsync(int id, Contact contact, CancellationToken cancellationToken);
        Task<Contact> SendUrlToContcat(int id, string message, CancellationToken cancellationToken);
    }
}