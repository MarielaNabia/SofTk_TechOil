﻿using Microsoft.IdentityModel.Tokens;
using SofTk_TechOil.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SofTk_TechOil.Helper
{
    public class JwtTokenHelper
    {
        private IConfiguration _configuration;
        public JwtTokenHelper(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        public string CrearToken(User user)
        {
            try
            {
                var claims = new[]
               {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["AppSettings:Subject"]),
                //new Claim(ClaimTypes.Name, user.Nombre.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.CodUsuario.ToString()),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
               };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                                            GetBytes(_configuration.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    //Expires = System.DateTime.Now.AddDays(1),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                return $"Error al crear el token: {ex.Message}";
            }
        }
    }
}
