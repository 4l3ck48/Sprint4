// Repositories/Interfaces/IUsuarioRepositorio.cs

using Microsoft.EntityFrameworkCore;
using TarefasSPT3.Models;

namespace TarefasSPT3.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> BuscarTodosUsuarios();
        Task<Usuario> BuscarPorId(int id);
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Atualizar(Usuario usuario, int id);
        Task<bool> Apagar(int id);
    }
}

