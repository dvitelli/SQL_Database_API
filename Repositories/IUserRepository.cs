using Backend.Models;

namespace Backend.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
    }
}