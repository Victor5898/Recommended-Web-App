using Recommended.Entities;

namespace WebApplication2
{
    public interface ITokenService
    {
        string CreateToken(DbUser user);
    }
}
