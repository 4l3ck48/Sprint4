// Tests/UnitTests/UsuarioRepositorioTests.cs
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using TarefasSPT3.Data;
using TarefasSPT3.Models;
using TarefasSPT3.Repositories;
using Xunit;

namespace TarefasSPT3.Tests.UnitTests
{
    public class UsuarioRepositorioTests
    {
        private readonly SistemasTarefasDBContext _context;
        private readonly UsuarioRepositorio _repositorio;

        public UsuarioRepositorioTests()
        {
            var options = new DbContextOptionsBuilder<SistemasTarefasDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            _context = new SistemasTarefasDBContext(options);
            _repositorio = new UsuarioRepositorio(_context);
        }

        [Fact]
        public async Task Adicionar_Usuario_DeveSerAdicionado()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nome = "Teste",
                Email = "teste@example.com",
                Cpf = 123456789012,
                Senha = "Senha123",
                Telefone = 1234567890123456
            };

            // Act
            var result = await _repositorio.Adicionar(usuario);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Teste", result.Nome);
        }

        [Fact]
        public async Task BuscarPorId_UsuarioExistente_DeveRetornarUsuario()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nome = "Buscar",
                Email = "buscar@example.com",
                Cpf = 987654321098,
                Senha = "Senha456",
                Telefone = 6543210987654321
            };
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repositorio.BuscarPorId(usuario.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Buscar", result.Nome);
        }

        [Fact]
        public async Task Apagar_UsuarioExistente_DeveRetornarTrue()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nome = "Apagar",
                Email = "apagar@example.com",
                Cpf = 112233445566,
                Senha = "Senha789",
                Telefone = 1122334455667788
            };
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repositorio.Apagar(usuario.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Atualizar_UsuarioExistente_DeveAtualizarNome()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nome = "Atualizar",
                Email = "atualizar@example.com",
                Cpf = 998877665544,
                Senha = "Senha000",
                Telefone = 9988776655443322
            };
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var usuarioAtualizado = new Usuario
            {
                Nome = "Atualizado",
                Email = "atualizado@example.com",
                Cpf = 998877665544,
                Senha = "Senha000",
                Telefone = 9988776655443322
            };

            // Act
            var result = await _repositorio.Atualizar(usuarioAtualizado, usuario.Id);

            // Assert
            Assert.Equal("Atualizado", result.Nome);
        }
    }
}
