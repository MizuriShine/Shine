public class ProjectService
{
	private readonly IProjectRepository _projectRepository;
	
	public ProjectService(IProjectRepository projectRepository)
	{
		_projectRepository = projectRepository;
	}
	
	public Task<IEnumerable<Project>> GetAllProjectsAsync()
	{
		return _projectRepository.GetAllProjectsAsync();
	}
	
	public Task<Project?> GetProjectByIdAsync(int id)
	{
		return _projectRepository.GetProjectByIdAsync(id);
	}
	
	public Task CreateProjectAsync(Project project)
	{
		return _projectRepository.CreateProjectAsync(project);
	}
	
	public Task UpdateProjectAsync(Project project)
	{
		return _projectRepository.UpdateProjectAsync(project);
	}
	
	public Task DeleteProjectAsync(Project project)
	{
		return _projectRepository.DeleteProjectAsync(project);
	}
}