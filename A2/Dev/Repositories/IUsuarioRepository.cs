using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev.Models;

namespace Dev.Repositories;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
  List<Usuario> Listar();
Usuario? BuscarUsuarioPorEmailSenha(string email, string senha);

}