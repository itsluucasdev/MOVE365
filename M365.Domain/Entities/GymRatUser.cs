namespace M365.Domain.Entities;

public class GymRatUser
{
    public string Id { get; private set; } = string.Empty;
    public string Role { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public Uri? ProfilePictureUrl { get; private set; }

    protected GymRatUser() { } // For ORM

    private GymRatUser(string fullName, string role, Uri? profilePictureUrl)
    {
        Id = Guid.NewGuid().ToString();
        Role = role;
        FullName = fullName;
        ProfilePictureUrl = profilePictureUrl;
        CreatedAt = DateTime.UtcNow;
    }

    public static GymRatUser Create(string fullName, string role, Uri? profilePictureUrl)
        => new(fullName, role, profilePictureUrl);

    public void ChangeName(string name) => FullName = name;
    public void ChangeRole(string role) => Role = role;
    public void UpdateProfilePicture(Uri? uri) => ProfilePictureUrl = uri;
}