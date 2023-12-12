using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;
        private readonly string _secretKey;

        public LoginController(Context context)
        {
            _context = context;
            _secretKey = Environment.GetEnvironmentVariable("SECRET_KEY") ?? throw new ArgumentNullException(nameof(_secretKey));
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginParameters parameters)
        {
            if (parameters == null)
            {
                return BadRequest("Invalid client request");
            }

            var user = _context.UserModel.FirstOrDefault(u => u.Email == parameters.Email);

            if (user != null)
            {

                if (_secretKey == null)
                {
                    return BadRequest("Internal server error!");
                }

                if (!VerifyPassword(user.Password, parameters.Password))
                {
                    return Unauthorized();
                }

                var claims = new Claim[] {
                    new Claim(ClaimTypes.Email , user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(ClaimTypes.AuthorizationDecision , string.Join(",", user.Permissions.Select(p => p.Type).ToList())),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_secretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: null,
                    audience: null,
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: creds
                );

                var tokenHandler = new JwtSecurityTokenHandler();
                var stringToken = tokenHandler.WriteToken(token);
                return Ok(stringToken);
            }
            else
            {
                return Unauthorized();
            }
        }

        public static bool VerifyPassword(string savedPasswordHash, string passwordToCheck)
        {
            string[] parts = savedPasswordHash.Split(':');
            byte[] salt = Convert.FromBase64String(parts[0]);
            string hashedPassword = parts[1];
            string hashedPasswordToCheck = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: passwordToCheck,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashedPassword == hashedPasswordToCheck;
        }

    }
}

public class LoginParameters
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    public required string Password { get; set; }
}