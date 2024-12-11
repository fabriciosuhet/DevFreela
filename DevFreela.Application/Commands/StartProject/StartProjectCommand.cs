using MediatR;

namespace DevFreela.Application.Commands.StartProject;

public class StartProjectCommand : IRequest<Unit>
{
	public Guid Id { get; private set; }

	public StartProjectCommand(Guid id)
	{
		Id = id;
	}
}