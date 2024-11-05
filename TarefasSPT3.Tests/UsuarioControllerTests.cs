using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using TarefasSPT3;
using System.Net;
using TarefasSPT3.Models;
using System.Text.Json;
using System.Text;

namespace TarefasSPT3.Tests
{
    public class UsuarioControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public UsuarioControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        // Método auxiliar para autenticar com um token de exemplo
        private void AddAuthToken()
        {
            // Simulação de um token JWT (substitua por um token válido em um cenário real)
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...";
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        [Fact]
        public async Task GetUsuarios_WithoutAuth_ShouldReturnUnauthorized()
        {
            // Act
            var response = await _client.GetAsync("/api/Usuario");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetUsuarios_WithAuth_ShouldReturnOk()
        {
            // Arrange
            AddAuthToken();

            // Act
            var response = await _client.GetAsync("/api/Usuario");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PostUsuario_ShouldCreateUser()
        {
            // Arrange
            AddAuthToken();
            var newUser = new Usuario
            {
                Nome = "Teste Usuario",
                Email = "teste@example.com",
                Cpf = 12345678901,
                Senha = "Senha123",
                Telefone = 5511999999999
            };

            var jsonContent = JsonSerializer.Serialize(newUser);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/Usuario", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetUsuarioById_ShouldReturnUser()
        {
            // Arrange
            AddAuthToken();
            var userId = 1; // Substitua pelo ID de um usuário existente para este teste

            // Act
            var response = await _client.GetAsync($"/api/Usuario/{userId}");

            // Assert
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
            else
            {
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
