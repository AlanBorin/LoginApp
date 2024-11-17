using LoginApp.DTOs;

namespace LoginApp.Interface
{
    public interface IUserService
    {
        void RegisterUser(UserDTO userDto);
        LoginResponseDTO ValidateLogin(LoginDTO loginDto);
        List<UserDTO> GetAllUsers();
    }
}

