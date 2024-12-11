namespace DevFreela.Core.Entities;

public abstract class BaseEntity
{
	protected BaseEntity(){}
	public Guid Id { get; private set; }
}