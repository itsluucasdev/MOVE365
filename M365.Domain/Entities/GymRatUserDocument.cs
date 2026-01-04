namespace M365.Domain.Entities;

public class GymRatUserDocument
{
    public string Id { get; set; } = null!;
    public string Role { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string FullName { get; set; } = null!;
    public string? ProfilePictureUrl { get; set; }
}