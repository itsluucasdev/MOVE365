using M365.Domain.Entities;

namespace M365.Infrastructure.GymRatUserMapper;

public static class GymRatUserMapper
{
    public static GymRatUserDocument ToDocument(GymRatUser user)
        => new()
        {
            Id = user.Id,
            FullName = user.FullName,
            Role = user.Role,
            CreatedAt = user.CreatedAt,
            ProfilePictureUrl = user.ProfilePictureUrl?.ToString()
        };

    public static GymRatUser ToDomain(GymRatUserDocument doc)
        => GymRatUser.Create(
            doc.FullName,
            doc.Role,
            doc.ProfilePictureUrl != null ? new Uri(doc.ProfilePictureUrl) : null
        );
}