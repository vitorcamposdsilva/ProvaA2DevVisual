using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev.Data;
using Dev.Models;

namespace Dev.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;
    public UsuarioRepository(AppDbContext context)
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

    public void Cadastrar(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

    }

    public List<Usuario> Listar()
    {
        return _context.Usuarios.ToList();
    }
}