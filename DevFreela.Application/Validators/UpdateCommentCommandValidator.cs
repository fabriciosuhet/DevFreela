using DevFreela.Application.Commands.UpdateProject;
using FluentValidation;

namespace DevFreela.Application.Validators;

public class UpdateCommentCommandValidator : AbstractValidator<UpdateProjectCommand>
{
	public UpdateCommentCommandValidator()
	{
		RuleFor(uc => uc.Description)
			.NotEmpty()
			.WithMessage("A descrição não pode ser vázia");

		RuleFor(uc => uc.Description)
			.NotNull()
			.WithMessage("A descrição não pode ser nula");

		RuleFor(uc => uc.Description)
			.MaximumLength(50)
			.WithMessage("A descrição não pode ser maior que 50 caracteres");
	}
}