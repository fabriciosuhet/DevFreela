using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetUser;

public class GetUserQuery : IRequest<UserViewModel>
{
	public Guid Id { get; private set; }

	public GetUserQuery(Guid id)
	{
		Id = id;
	}
}