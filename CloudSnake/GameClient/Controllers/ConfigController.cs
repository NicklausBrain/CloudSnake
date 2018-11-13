using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GameClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ConfigController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Config Get()
        {
            var auth = this.configuration.GetSection("Auth");

            return new Config(
                clientId: auth["ClientId"],
                instance: auth["Instance"],
                domain: auth["Domain"],
                tenantId: auth["TenantId"],
                apiUrl: this.configuration["apiUrl"]);
        }

        public class Config
        {
            public Config(
                string clientId,
                string instance,
                string domain,
                string tenantId,
                string apiUrl)
            {
                this.ClientId = clientId;
                this.Instance = instance;
                this.Domain = domain;
                this.TenantId = tenantId;
                this.ApiUrl = apiUrl;
            }

            public string ClientId { get; }
            public string Instance { get; }
            public string Domain { get; }
            public string TenantId { get; }
            public string ApiUrl { get; }
        }
    }
}