using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Models
{
    public class Evento
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Local { get; set; } = string.Empty;

        public DateTime Data { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}