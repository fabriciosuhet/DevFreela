namespace DevFreela.Application.ViewModels;

public class ProjectViewModel
{
	public string Title { get; private set; }
	public DateTime CreatedAt { get; private set; }
	public Guid Id { get; private set; }

	public ProjectViewModel(Guid id, string title, DateTime createdAt)
	{
		Id = id;
		Title = title;
		CreatedAt = createdAt;
	}
}