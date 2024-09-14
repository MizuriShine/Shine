using System.ComponentModel.DataAnnotations;

public class CreateProjectDto
{
    [Required]
    public required string Title { get; set; }
    public string? Description { get; set; }
}