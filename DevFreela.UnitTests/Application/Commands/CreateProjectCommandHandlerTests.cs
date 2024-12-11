using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands;

public class CreateProjectCommandHandlerTests
{
	[Fact]
	public async Task InputDataIsOk_Executed_ReturnProjectId()
	{
		// Arrange
		var projectRepository = new Mock<IProjectRepository>();
		var createProjectCommand = new CreateProjectCommand
		{
			Title = "Teste",
			Description = "Descricao teste",
			IdClient = Guid.NewGuid(),
			IdFreelancer = Guid.NewGuid(),
			TotalCost = 10000
		};
		
		var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepository.Object);

		// Act
		var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

		// Assert
		Assert.True(id >= Guid.Empty);
		projectRepository.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once);


	}
}