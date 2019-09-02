﻿using DomainModels.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.Helpers
{
    public class TokenHelper : ITokenHelper
    {
        private readonly IConfiguration _configuration;

        public TokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string userName, int Id, Role role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, userName),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Role, role.ToString())
            };

            var token = new JwtSecurityToken
                (
                      issuer: _configuration["Jwt:Issuer"],
                      audience: _configuration["Jwt:Issuer"],
                      expires: DateTime.Now.AddDays(30),
                      claims: claims,
                      signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
