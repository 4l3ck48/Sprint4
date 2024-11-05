using Microsoft.EntityFrameworkCore;
using TarefasSPT3.Data;
using TarefasSPT3.Models;
using TarefasSPT3.Repositorios.Interfaces;

namespace TarefasSPT3.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemasTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemasTarefasDBContext sistemasTarefasDBContext) 
        {
            _dbContext = sistemasTarefasDBContext;
        }
        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }
        public async Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} nao foi encontrado .");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            throw new NotImplementedException(); Usuario usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} nao foi encontrado .");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
