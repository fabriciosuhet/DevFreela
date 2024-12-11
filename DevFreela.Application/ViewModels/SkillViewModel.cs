namespace DevFreela.Application.ViewModels;

public class SkillViewModel
{
	public Guid Id { get; private set; }
	public string Description { get; private set; }

	public SkillViewModel(Guid id, string description)
	{
		Id = id;
		Description = description;
	}
}