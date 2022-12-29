using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClientesApi.Application.Security
{
    /// <summary>
    /// Classe para configuração e geração dos TOKENS
    /// </summary>
    public class JwtSecurity
    {
        #region Atributos

        public static string SecretKey = "2DCF997D-F700-412B-B4D6-AAEE5135C5D4";
        public static int ExpirationInHours = 12;

        #endregion

        #region Método para geração dos TOKENS

        public static string CreateToken(string user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user) }),
                Expires = DateTime.UtcNow.AddHours(ExpirationInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion
    }
}



