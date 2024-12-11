using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IUserRepository
{
	Task<User?> GetUserAsync(Guid id);
	Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
	Task AddAsync(User user);
}