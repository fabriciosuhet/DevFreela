namespace DevFreela.Core.Exceptions;

public class ProjectAlreadyStartedException : Exception
{
	public ProjectAlreadyStartedException() : base("Project has already been started.")
	{
		
	}
}