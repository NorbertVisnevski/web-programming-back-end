using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebProgrammingBackEnd.Data;
using WebProgrammingBackEnd.DTOs;
using WebProgrammingBackEnd.Entities;

namespace WebProgrammingBackEnd.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserController(AppDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(UserRegisterDTO userDTO)
        {
            var user = await Register(_mapper.Map<User>(userDTO), userDTO.Password);
            var token = GenerateToken(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            return Ok(new { User = _mapper.Map<UserLoadDTO>(user), Token = tokenHandler.WriteToken(token) });

        }
        [Authorize(Policy = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.Include(x => x.Roles).ToListAsync();
            return Ok(_mapper.Map<List<UserLoadDTO>>(users));
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _context.Users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
                return NotFound();
            return Ok(_mapper.Map<UserLoadDTO>(user));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserEditDTO userDTO)
        {
            var user = await _context.Users.FindAsync(userDTO.Id);
            if (user == null)
                return NotFound(user);
            _mapper.Map(userDTO, user);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<UserLoadDTO>(user));
        }

        private bool HasAuthorityToEdit(ClaimsPrincipal user, int id)
        {
            throw new NotImplementedException();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userDTO)
        {
            var userFromRepo = await Login(userDTO.Email, userDTO.Password);
            if (userFromRepo == null)
                return Unauthorized("User not found");
            var token = GenerateToken(userFromRepo);
            var tokenHandler = new JwtSecurityTokenHandler();
            return Ok(new { User = _mapper.Map<UserLoadDTO>(userFromRepo), Token = tokenHandler.WriteToken(token) });
        }

        private SecurityToken GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
            };
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
            var key = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_config["AppSettings:Secret"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.CreateToken(tokenDescriptor);
        }

        private async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Roles = new List<Role> { _context.Roles.Find("Customer") };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private async Task<User> Login(string email, string password)
        {
            var user = await _context.Users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
                return null;
            if (!VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; ++i)
                if (computedHash[i] != passwordHash[i])
                    return false;
            return true;
        }
    }
}
