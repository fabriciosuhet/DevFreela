namespace DevFreela.Core.Entities;

public class ProjectComment : BaseEntity
{
	public string Content { get; private set; }
	public Guid IdProject { get; private set; }
	public Project Project { get; private set; }
	public User User { get; private set; }
	public Guid IdUser { get; private set; }
	public DateTime CreatedAt { get; private set; }
	
	protected ProjectComment(){}

	public ProjectComment(string content, Guid idProject, Guid idUser)
	{
		Content = content;
		IdProject = idProject;
		IdUser = idUser;
		
		CreatedAt = DateTime.UtcNow;
	}
}