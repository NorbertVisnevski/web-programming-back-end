using System.Security.Claims;

namespace WebProgrammingBackEnd.Helpers
{
    public static class AuthorityChecker
    {
        public static bool HasAuthorityToEdit(ClaimsPrincipal user, int id)
        {
            if (user.Claims.Where(x => x.Type == "role").Select(x => x.Value).ToList().Contains("Admin"))
            {
                return true;
            }
            if (int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value) != id)
            {
                return false;
            }
            return true;
        }
    }
}
