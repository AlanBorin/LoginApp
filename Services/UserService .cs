using LoginApp.DTOs;
using LoginApp.Interface;
using LoginApp.Models;

namespace LoginApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService(
            IUserRepository userRepository, 
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;

        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public void RegisterUser(UserDTO userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Password = userDto.Password
            };
            _userRepository.AddUser(user);
        }

        public LoginResponseDTO ValidateLogin(LoginDTO loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Username))
            {
                throw new ArgumentException("Username is required");
            }

            var user = _userRepository.GetUserByUsername(loginDto.Username);

            if (user == null || user.Password != loginDto.Password)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var token = _tokenService.GenerateToken(user);

            return new LoginResponseDTO
            {
                Token = token,
                Username = user.Username
            };
        }

        public List<UserDTO> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return users.Select(u => new UserDTO
            {
                Username = u.Username
            }).ToList();
        }
    }
}
