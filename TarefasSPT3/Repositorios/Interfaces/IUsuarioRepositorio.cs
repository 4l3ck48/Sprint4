using TarefasSPT3.Models;

namespace TarefasSPT3.Repositorios.Interfaces
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
