using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProductCatalog.Authentication
{
    public class AuthOptions
    {
        public const string Issuer = "AuthServer"; 
        public const string Audience = "AuthClient"; 
        private const string Key = "secretkey!1234567890@qwerty";   
        public const int Lifetime = 20; 

        public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
}
