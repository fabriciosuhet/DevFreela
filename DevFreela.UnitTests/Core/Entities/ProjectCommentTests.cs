using DevFreela.Core.Entities;

namespace DevFreela.UnitTests.Core.Entities;

public class ProjectCommentTests
{
	[Fact]
	public void TestsIfProjectCommentIsWorks()
	{
		var projectComment = new ProjectComment("comentario teste", Guid.NewGuid(), Guid.NewGuid());
		Assert.NotNull(projectComment);
		Assert.NotEmpty(projectComment.Content);
		
	}
}