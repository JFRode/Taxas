﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SDK.KeyVault;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Taxas.API.Controllers
{
    [Route("[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration) =>
            _configuration = configuration;

        /// <summary>
        /// Solicita um token novo através da verificação da chave informada.
        /// </summary>
        /// <param name="chave"></param>
        /// <param name="cancellationToken"></param>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RequestToken([FromBody] string chave, CancellationToken cancellationToken)
        {
            if (await ValidaChave(chave, cancellationToken))
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.SerialNumber, chave)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthenticationKeys.TaxasApi));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "TaxasAPI",
                    audience: "TaxasAPI",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credential);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Requisição inválida");
        }

        private async Task<bool> ValidaChave(string chave, CancellationToken cancellationToken) =>
            await Task.Run(() =>
            {
                return chave == AuthenticationKeys.TaxasApi;
            }, cancellationToken);
    }
}