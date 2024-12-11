using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetProjectById;

public class GetProjectsByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
{
	private readonly IProjectRepository _projectRepository;

	public GetProjectsByIdQueryHandler(IProjectRepository projectRepository)
	{
		_projectRepository = projectRepository;
	}


	public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
	{
		
		var project = await _projectRepository.GetByIdAsync(request.Id);
		
		if (project == null) return null;
		
		var projectDetailsViewModel = new ProjectDetailsViewModel(
			request.Id,
			project.Title,
			project.Description,
			project.TotalCost,
			project.StartedAt,
			project.FinishedAt,
			project.Client.FullName,
			project.Freelancer.FullName
		);
		return projectDetailsViewModel;
	}
}