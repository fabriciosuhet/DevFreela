using MediatR;

namespace DevFreela.Application.Commands.CreateComment;

public class CreateCommentCommand : IRequest<Unit>
{
	public string Content { get; set; }
	public Guid IdProject { get; set; }
	public Guid IdUser { get; set; }
}