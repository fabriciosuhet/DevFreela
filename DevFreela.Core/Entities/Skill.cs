namespace DevFreela.Core.Entities;

public class Skill : BaseEntity
{
	public string Description { get; private set; }
	public DateTime CreatedAt { get; private set; }
	
	protected Skill(){}

	public Skill(string description)
	{
		Description = description;
		CreatedAt = DateTime.UtcNow;
	}
}