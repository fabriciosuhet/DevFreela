using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities;

public class Project : BaseEntity
{
	public string Title { get; private set; }
	public string Description { get; private set; }
	public Guid IdClient { get; private set; }
	public User	Client { get; private set; }
	public Guid IdFreelancer { get; private set; }
	public User Freelancer { get; private set; }
	public decimal TotalCost { get; private set; }
	public DateTime CreatedAt { get; private set; }
	public DateTime? StartedAt { get; private set; }
	public DateTime? FinishedAt { get; private set; }
	public ProjectStatusEnum Status { get; private set; }
	public List<ProjectComment> Comments { get; private set; }
	
	protected Project(){}

	public Project(string title, string description, Guid idClient, Guid idFreelancer, decimal totalCost)
	{
		Title = title;
		Description = description;
		IdClient = idClient;
		IdFreelancer = idFreelancer;
		TotalCost = totalCost;
		
		CreatedAt = DateTime.UtcNow;
		Status = ProjectStatusEnum.Created;
		Comments = new List<ProjectComment>();
	}

	public void Cancel()
	{
		if (Status == ProjectStatusEnum.InProgress ||  Status == ProjectStatusEnum.InProgress)
		{
			Status = ProjectStatusEnum.Cancelled;
		}
		
	}

	public void Finish()
	{
		if (Status == ProjectStatusEnum.InProgress)
		{
			Status = ProjectStatusEnum.Finished;
			FinishedAt = DateTime.UtcNow;
		}
	}

	public void Start()
	{
		if (Status == ProjectStatusEnum.Created)
		{
			Status = ProjectStatusEnum.InProgress;
			StartedAt = DateTime.UtcNow;
		}
	}

	public void Update(string title, string description, decimal totalCost)
	{
		Title = title;
		Description = description;
		TotalCost = totalCost;
	}
}