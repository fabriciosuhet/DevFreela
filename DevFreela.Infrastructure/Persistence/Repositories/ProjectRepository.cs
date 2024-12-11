using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
	private readonly string? _connectionString;
	private readonly DevFreelaDbContext _context;

	public ProjectRepository(DevFreelaDbContext context, IConfiguration configuration)
	{
		_context = context;
		_connectionString = configuration.GetConnectionString("DefaultConnection");
	}

	public async Task<List<Project>> GetAllAsync()
	{
		return await _context.Projects.ToListAsync();
	}

	public async Task<Project?> GetByIdAsync(Guid id)
	{
		return await _context.Projects
			.Include(p => p.Client)
			.Include(p => p.Freelancer)
			.SingleOrDefaultAsync(p => p.Id == id);
	}

	public async Task AddAsync(Project project)
	{
		await _context.Projects.AddAsync(project);
		await _context.SaveChangesAsync();
	}

	public async Task StartAsync(Project project)
	{
		// _context.SaveChanges();
		using (var sqlConnection = new MySqlConnection(_connectionString))
		{
			sqlConnection.Open();
			var script = "UPDATE Projects SET Status = @status, StartedAt = @startedAt WHERE Id = @id";
			await sqlConnection.ExecuteAsync(script,
				new { status = project.Status, startedAt = project.StartedAt, project.Id });
		}
	}

	public async Task SaveChangesAsync()
	{
		await _context.SaveChangesAsync();
	}

	public async Task AddCommentAsync(ProjectComment projectComment)
	{
		await _context.ProjectComments.AddAsync(projectComment);
		await _context.SaveChangesAsync();
	}

	public async Task RemoveProjectAsync(Guid id)
	{
		var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);
		if (project != null) _context.Projects.Remove(project);
		await _context.SaveChangesAsync();
	}

	public async Task FinishAsync(Project project)
	{
		var finishProject = await _context.Projects.SingleOrDefaultAsync(p => p.Id == project.Id);
		finishProject.Finish();
		await _context.SaveChangesAsync();
	}
}