using DevFreela.Core.Entities;

namespace DevFreela.UnitTests.Core.Entities;

public class SkillTests
{
	[Fact]
	public void TestsIfSkillsItsWorks()
	{
		var skills = new Skill("descricao de teste");
		
		Assert.NotNull(skills);
		Assert.NotNull(skills.Description);
		Assert.NotEmpty(skills.Description);
		Assert.NotNull(skills.CreatedAt);
	}
}