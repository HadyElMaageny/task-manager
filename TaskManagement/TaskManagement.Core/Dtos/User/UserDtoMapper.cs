using TaskManagement.Core.Dtos.Task;

namespace TaskManagement.Core.Dtos.User;

public static class UserDtoMapper
{
    public static UserDto ToUserDto(this Entities.User user)
    {
        return new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            Tasks = user.Tasks.Select(c => c.ToTaskDto()).ToList()
        };
    }

    public static Entities.User ToUserItemFromCreateDto(this UserSaveDto userSaveDto)
    {
        return new Entities.User
        {
            UserName = userSaveDto.UserName,
            Email = userSaveDto.Email,
            FirstName = userSaveDto.FirstName,
            LastName = userSaveDto.LastName,
            Password = userSaveDto.Password,
        };
    }
}