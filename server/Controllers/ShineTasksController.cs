using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ShineTasksController : ControllerBase
{
	private readonly ShineTaskService _taskService;
	
	public ShineTasksController(ShineTaskService taskService)
	{
		_taskService = taskService;
	}
	
	[HttpGet]
	public async Task<ActionResult<IEnumerable<ShineTask>>> GetAllTasks()
	{
		return Ok(await _taskService.GetAllTasksAsync());
	}
	
	[HttpGet("{id}")]
	public async Task<ActionResult<ShineTask>> GetTaskById(int id)
	{
		var task = await _taskService.GetTaskByIdAsync(id);
		
		if (task == null)
			return NotFound();
			
		return Ok(task);
	}
	
	[HttpPost]
	public async Task<ActionResult> CreateTask([FromBody] CreateShineTaskDto createShineTaskDto)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);
			
		var task = new ShineTask()
		{
			Title = createShineTaskDto.Title,
			Description = createShineTaskDto.Description,
			CreatedDate = DateTime.UtcNow
		};
		
		await _taskService.CreateTaskAsync(task);
		
		return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
	}
	
	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateTask(int id, [FromBody] UpdateShineTaskDto updateShineTaskDto)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);
			
		var existingTask = await _taskService.GetTaskByIdAsync(id);
		
		if (existingTask == null)
			return NotFound();
			
		existingTask.Title = updateShineTaskDto.Title;
		existingTask.Description = updateShineTaskDto.Description;
		existingTask.UpdatedDate = DateTime.UtcNow;
		
		await _taskService.UpdateTaskAsync(existingTask);
		
		return NoContent();
	}
	
	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteTask(int id)
	{
		var existingTask = await _taskService.GetTaskByIdAsync(id);
		
		if (existingTask == null)
			return NotFound();
			
		await _taskService.DeleteTaskAsync(id);
		
		return NoContent();
	}
}