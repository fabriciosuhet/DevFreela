namespace DevFreela.Core.Entities;

public class UserSkill : BaseEntity
{
	public Guid IdUser { get; private set; }
	public Guid IdSkill { get; private set; }
	
	protected UserSkill(){}

	public UserSkill(Guid idUser, Guid idSkill)
	{
		IdUser = idUser;
		IdSkill = idSkill;
	}
}