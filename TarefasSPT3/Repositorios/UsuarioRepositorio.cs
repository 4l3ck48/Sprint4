// Repositories/UsuarioRepositorio.cs
using Microsoft.EntityFrameworkCore;
using TarefasSPT3.Data;
using TarefasSPT3.Models;
using TarefasSPT3.Repositories.Interfaces;

namespace TarefasSPT3.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemasTarefasDBContext _dbContext;

        public UsuarioRepositorio(SistemasTarefasDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            var usuario = await BuscarPorId(id);
            if (usuario == null)
            {
                return false;
            }

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            var usuarioExistente = await BuscarPorId(id);
            if (usuarioExistente == null)
            {
                return null;
            }

            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Cpf = usuario.Cpf;
            usuarioExistente.Telefone = usuario.Telefone;
            // Senha não é atualizada aqui por motivos de segurança

            _dbContext.Usuarios.Update(usuarioExistente);
            await _dbContext.SaveChangesAsync();
            return usuarioExistente;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
            
        }
    }
}


