using Microsoft.EntityFrameworkCore;

public interface IProjectRepository
{
	Task<IEnumerable<Project>> GetAllProjectsAsync();
	Task<Project?> GetProjectByIdAsync(int id);
	Task CreateProjectAsync(Project project);
	Task UpdateProjectAsync(Project project);
	Task DeleteProjectAsync(Project project);
}

public class ProjectRepository : IProjectRepository
{
	private readonly ApplicationDbContext _dbContext;

	public ProjectRepository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<Project>> GetAllProjectsAsync()
	{
		return await _dbContext.Projects.ToListAsync();
	}

	public async Task<Project?> GetProjectByIdAsync(int id)
	{
		return await _dbContext.Projects.FindAsync(id);
	}

	public async Task CreateProjectAsync(Project project)
	{
		await _dbContext.Projects.AddAsync(project);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateProjectAsync(Project project)
	{
		_dbContext.Projects.Update(project);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteProjectAsync(Project project)
	{
		_dbContext.Projects.Remove(project);
		await _dbContext.SaveChangesAsync();
	}
}