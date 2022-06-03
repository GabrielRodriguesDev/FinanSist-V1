using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using FinanSist.Domain.Commands.Autentica;
using FinanSist.Domain.Entities;
using WMSLite.WebApi;
using System.Security.Cryptography;
using FinanSist.Domain.Commands;

namespace FinanSist.Domain.Services
{
    public class TokenService
    {

        public static string GenerateToken(Autenticado autenticado)
        {
            var key = Encoding.ASCII.GetBytes(Settings.Secret);// Pegando a chave
            var tokenHandler = new JwtSecurityTokenHandler(); //Classe que vai gerar o token;
            var tokenDescriptor = new SecurityTokenDescriptor
            { //Criando o token;
                Subject = new ClaimsIdentity(new Claim[] { //Criando as claims no corpo
                    new Claim(ClaimTypes.Name, autenticado.Id.ToString()),//User.Identity.Name
                    new Claim("Usuario", autenticado.Nome),
                    new Claim(ClaimTypes.Role, autenticado.Permissao) //User.IsInRole()
        }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) //Credenciais para encripitar e desencriptar o token
            };
            // Com tudo parametrizado acima, podemos gerar o token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); //Retornando o token em string
        }

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public static RefreshAutenticado GetPrincipalFromExpiredToken(RefreshTokenCommand cmd)
        {
            cmd.Validate();
            if (cmd.Invalid)
                return new RefreshAutenticado(false, "Ops, Algo deu errado!", cmd.Notifications);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Secret)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            dynamic validateToken;
            try
            {
                validateToken = tokenHandler.ValidateToken(cmd.Token, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
                    return new RefreshAutenticado(false, "Token inválido.");
            }
            catch (System.Exception)
            {
                return new RefreshAutenticado(false, "Token inválido.");
            }
            return new RefreshAutenticado(true, "Token válido.", Guid.Parse(validateToken.Identity.Name), cmd.RefreshToken);
        }
    }
}
