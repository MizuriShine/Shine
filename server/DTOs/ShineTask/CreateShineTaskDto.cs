using System.ComponentModel.DataAnnotations;

public class CreateShineTaskDto
{
	[Required]
	public required string Title { get; set; }
	public string? Description { get; set; }
}