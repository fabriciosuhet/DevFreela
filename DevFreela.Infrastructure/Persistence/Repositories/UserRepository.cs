using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
	private readonly DevFreelaDbContext _context;

	public UserRepository(DevFreelaDbContext context)
	{
		_context = context;
	}

	public async Task<User?> GetUserAsync(Guid id)
	{
		return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
	}

	public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
	{
		return await _context
			.Users.SingleOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(passwordHash));
	}

	public async Task AddAsync(User user)
	{
		await _context.Users.AddAsync(user);
		await _context.SaveChangesAsync();
	}
}