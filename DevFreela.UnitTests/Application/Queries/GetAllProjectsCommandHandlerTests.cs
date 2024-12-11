using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries;

public class GetAllProjectsCommandHandlerTests
{
	[Fact]
	public async Task ThreeProjectsExist_Excetuted_ReturnThreeProjectsViewModels()
	{
		// Arrange
		var projects = new List<Project>
		{
			new Project("nome do teste 1", "texto da descricao 1", Guid.NewGuid(), Guid.NewGuid(), 10000),
			new Project("nome do teste 2", "texto da descricao 2", Guid.NewGuid(), Guid.NewGuid(), 20000),
			new Project("nome do teste 3", "texto da descricao 3", Guid.NewGuid(), Guid.NewGuid(), 30000),
		};

		var projectRepositoryMock = new Mock<IProjectRepository>();
		projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

		var getAllProjectsQuery = new GetAllProjectsQuery("");
		var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);
		// Act 
		var projectViewModelList =
			await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

		// Assert

		Assert.NotNull(projectViewModelList);
		Assert.NotEmpty(projectViewModelList);
		Assert.Equal(projects.Count, projectViewModelList.Count);
		
		projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
	}
}