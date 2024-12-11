using DevFreela.Application.Commands.CreateComment;
using FluentValidation;

namespace DevFreela.Application.Validators;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
	public CreateCommentCommandValidator()
	{
		RuleFor(c => c.Content)
			.NotEmpty()
			.WithMessage("O comentário não pode ser vázio");

		RuleFor(c => c.Content)
			.NotNull()
			.WithMessage("O comentário não pode ser nulo.");
	}
}