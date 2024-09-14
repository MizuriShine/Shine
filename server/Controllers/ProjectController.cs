using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
	private readonly ProjectService _projectService;
	
	public ProjectController(ProjectService projectService)
	{
		_projectService = projectService;
	}
	
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
	{
		return Ok(await _projectService.GetAllProjectsAsync());
	}
	
	[HttpGet("{id}")]
	public async Task<ActionResult<Project>> GetProjectById(int id)
	{
		var project = await _projectService.GetProjectByIdAsync(id);
		
		if (project == null)
			return NotFound();
			
		return Ok(project);
	}
	
	[HttpPost]
	public async Task<ActionResult> CreateProject([FromBody] CreateProjectDto createProjectDto)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);
			
		var project = new Project()
		{
			Title = createProjectDto.Title,
			Description = createProjectDto.Description,
			CreatedDate = DateTime.UtcNow
		};
		
		await _projectService.CreateProjectAsync(project);
		
		return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
	}
	
	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateProject(int id, [FromBody] UpdateProjectDto updateProjectDto)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);
			
		var existingProject = await _projectService.GetProjectByIdAsync(id);
		
		if (existingProject == null)
			return NotFound();
			
		existingProject.Title = updateProjectDto.Title;
		existingProject.Description = updateProjectDto.Description;
		existingProject.UpdatedDate = DateTime.UtcNow;
		
		await _projectService.UpdateProjectAsync(existingProject);
		
		return NoContent();
	}
	
	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteProject(int id)
	{
		var existingProject = await _projectService.GetProjectByIdAsync(id);
		
		if (existingProject == null)
			return NotFound();
			
		await _projectService.DeleteProjectAsync(existingProject);
		
		return NoContent();
	}
}