using UserTestingApp.Common.DTO;

namespace UserTestingApp.BLL.Services.Interfaces;

public interface IUserService
{
    public Task<AuthSuccessDTO> Auhtorization(UserDTO dto);
}