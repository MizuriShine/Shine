using System.ComponentModel.DataAnnotations;

public class UpdateShineTaskDto
{
	[Required]
	public required string Title { get; set; }
	public string? Description { get; set; }
}