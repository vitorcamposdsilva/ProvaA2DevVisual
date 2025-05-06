using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dev.Models;
using Dev.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Dev.Controllers
{
    [ApiController]
    [Route("Dev/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        public UsuarioController(IUsuarioRepository usuarioRepository,
            IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            return Created("", usuario);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            Usuario? usuarioExistente = _usuarioRepository
                .BuscarUsuarioPorEmailSenha(usuario.Email, usuario.Senha);

            if (usuarioExistente == null)
            {
                return Unauthorized(new { mensagem = "Usuário ou senha inválidos!" });
            }

            string token = GerarToken(usuarioExistente);
            return Ok(token);
        }
        
        

        [HttpGet("listar")]
        [Authorize]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Email)
            };

            var chave = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]!);
            
            var assinatura = new SigningCredentials(
                new SymmetricSecurityKey(chave),
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: assinatura
            );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


}
}