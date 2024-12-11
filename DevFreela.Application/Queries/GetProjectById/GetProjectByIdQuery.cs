using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetProjectById;

public class GetProjectByIdQuery : IRequest<ProjectDetailsViewModel>
{
	public Guid Id { get; private set; }

	public GetProjectByIdQuery(Guid id)
	{
		Id = id;
	}
}