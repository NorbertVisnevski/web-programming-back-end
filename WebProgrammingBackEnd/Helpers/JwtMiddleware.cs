using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebProgrammingBackEnd.Data;

namespace WebProgrammingBackEnd.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public JwtMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task Invoke(HttpContext context, AppDbContext _context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, _context, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, AppDbContext _context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["AppSettings:Secret"]);

                var jwtToken = tokenHandler.ReadJwtToken(token);
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "nameid").Value);
                var email = jwtToken.Claims.First(x => x.Type == "name").Value;

                var user = _context.Users.Include(x => x.Roles).FirstOrDefault(x => x.Id == userId && x.Email.Equals(email));
                if (user != null)
                {
                    var roles = jwtToken.Claims.Where(x => x.Type == "role").Select(x => x.Value).ToList();
                    foreach (var role in roles)
                    {
                        if (!user.Roles.Any(x => x.Name == role))
                        {
                            throw new Exception("JwtValidation error");
                        }
                    }
                    context.Items["User"] = user;
                }
            }
            catch
            {

            }
        }
    }
}
