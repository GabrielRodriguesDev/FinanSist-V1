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
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, autenticado.Id.ToString()),//User.Identity.Name
                    new Claim("Usuario", autenticado.Nome),
                    new Claim(ClaimTypes.Role, autenticado.Permissao) //User.IsInRole()
        }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) //Credenciais para encripitar e desencriptar o token
            };
            // Com tudo parametrizado acima, podemos gerar o token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
