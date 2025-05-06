using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev.Models;
using Dev.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Controllers
{
    [ApiController]
    [Route("Dev/evento")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IConfiguration _configuration;
        public EventoController(IEventoRepository eventoRepository,
            IConfiguration configuration)
        {
            _eventoRepository = eventoRepository;
            _configuration = configuration;
        }

        [HttpPost("cadastrar")]
        [Authorize]
        public IActionResult Cadastrar([FromBody] Evento evento)
        {
            _eventoRepository.Cadastrar(evento);
            return Created("", evento);
        }
        
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(_eventoRepository.Listar());
        }
}
}