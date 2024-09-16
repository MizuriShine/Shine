using System.ComponentModel.DataAnnotations;

public class UpdateProjectDto
{
    [Required]
    public required string Title { get; set; }
    public string? Description { get; set; }
}