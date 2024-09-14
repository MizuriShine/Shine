public class ShineTaskService
{
	private readonly IShineTaskRepository _taskRepository;
	
	public ShineTaskService(IShineTaskRepository taskRepository)
	{
		_taskRepository = taskRepository;
	}
	
	public Task<IEnumerable<ShineTask>> GetAllTasksAsync()
	{
		return _taskRepository.GetAllTasksAsync();
	}
	
	public Task<ShineTask?> GetTaskByIdAsync(int id)
	{
		return _taskRepository.GetTaskByIdAsync(id);
	}
	
	public Task CreateTaskAsync(ShineTask task)
	{
		return _taskRepository.CreateTaskAsync(task);
	}
	
	public Task UpdateTaskAsync(ShineTask task)
	{
		return _taskRepository.UpdateTaskAsync(task);
	}
	
	public Task DeleteTaskAsync(ShineTask task)
	{
		return _taskRepository.DeleteTaskAsync(task);
	}
}