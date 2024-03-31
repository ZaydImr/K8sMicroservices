using Auth.Domain.DTOs;
using Auth.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace Auth.Application.Mappers;

[Mapper]
public partial class UserMapper
{
    public partial UserDto ToDto(AppUser user);
    public partial AppUser ToEntity(UserDto user);
}
