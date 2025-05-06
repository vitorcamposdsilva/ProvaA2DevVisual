using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev.Data;
using Dev.Models;

namespace Dev.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly AppDbContext _context;
    public EventoRepository(AppDbContext context)
    {
        _context = context;
    }

    public Usuario? BuscarUsuarioPorEmailSenha(string email, string senha)
    {
        Usuario? usuarioExistente = 
            _context.Usuarios.FirstOrDefault
            (x => x.Email == email && x.Senha == senha);
        return usuarioExistente;
    }

    public void Cadastrar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();

    }

    public List<Evento> Listar()
    {
        return _context.Eventos.ToList();
    }
}