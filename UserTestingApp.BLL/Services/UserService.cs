using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserTestingApp.BLL.Services.Interfaces;
using UserTestingApp.Common.DTO;
using UserTestingApp.Common.Models;
using UserTestingApp.DAL.Repository.Interface;
using UserTestingApp.Entities;

namespace UserTestingApp.BLL.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;
    private readonly JwtSettings _settings;

    public UserService(IRepository<User> userRepository, IMapper mapper, IOptions<JwtSettings> settings)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _settings = settings.Value;
    }

    public async Task<AuthSuccessDTO> Auhtorization(UserDTO dto)
    {
        var user = await _userRepository.FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (user == null)
        {
            user = _mapper.Map<User>(dto);

            await _userRepository.InsertAsync(user!);
        }

        return new AuthSuccessDTO(GenerateJwtToken(user!));
    }

    private string GenerateJwtToken(User user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("email", user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _settings.Issuer,
            Audience = _settings.Audience
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);
        return jwtToken;
    }
}