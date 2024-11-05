// Configuration/AppConfiguration.cs
namespace TarefasSPT3.Configuration
{
    public class AppConfiguration
    {
        public SwaggerConfig Swagger { get; set; }
        public ConnectionStringsConfig ConnectionStrings { get; set; }
        public Auth0Config Auth0 { get; set; }

        public class ConnectionStringsConfig
        {
            public string OracleFIAP { get; set; }
        }

        public class SwaggerConfig
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
        }

        public class Auth0Config
        {
            public string Domain { get; set; }
            public string Audience { get; set; }
        }
    }
}