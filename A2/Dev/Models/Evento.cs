using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Models
{
    public class Evento
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Local { get; set; }

        public DateTime Data { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}