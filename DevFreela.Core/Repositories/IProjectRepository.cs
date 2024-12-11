using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IProjectRepository
{
	Task<List<Project>> GetAllAsync();
	Task<Project?> GetByIdAsync(Guid id);
	Task AddAsync(Project project);
	Task StartAsync(Project project);
	Task SaveChangesAsync();
	Task AddCommentAsync(ProjectComment projectComment);
	Task RemoveProjectAsync(Guid id);
	Task FinishAsync(Project project);
}