using System.ComponentModel.DataAnnotations;

public class ShineTaskDto
{
	[Required]
	public required string Title { get; set; }
	public string? Description { get; set; }
}