using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class SkillRepository : ISkillRepository
{
	private readonly string? _connectionString;

	public SkillRepository(IConfiguration configuration)
	{
		_connectionString = configuration.GetConnectionString("DefaultConnection");
	}


	public async Task<List<SkillDTO>> GetAllAsync()
	{
		using (var sqlconnection = new MySqlConnection(_connectionString))
		{
			sqlconnection.Open();
			var script = "SELECT Id, Description FROM Skills";

			var skills = await sqlconnection.QueryAsync<SkillDTO>(script);
			return skills.ToList();
		}
		
		// COM EF CORE

		// var skill = _dbContext.Skills;
		// var skillsViewModel = skill.Select(s => new SkillViewModel(s.Id, s.Description))
		// 	.ToList();
		// return skillsViewModel;
	}
}