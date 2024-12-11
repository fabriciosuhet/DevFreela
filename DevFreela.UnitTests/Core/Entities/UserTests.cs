using DevFreela.Core.Entities;

namespace DevFreela.UnitTests.Core.Entities;

public class UserTests
{
	[Fact]
	public void TestsIfUserIsWorks()
	{
		var user = new User("fabricio suhet", "email@teste.com", new DateTime(2020, 01, 01),
			"SenhaTeste@10", "client");

		Assert.NotNull(user);
		Assert.NotNull(user.FullName);
		Assert.NotEmpty(user.FullName);
		
		Assert.NotNull(user.Email);
		Assert.NotEmpty(user.Email);
		Assert.Equal(user.Active, true);
		
		Assert.NotNull(user.BirthDate);
		
		Assert.NotNull(user.Password);
		Assert.NotEmpty(user.Password);

		Assert.NotNull(user.Role);
		Assert.NotEmpty(user.Role);
	}
}