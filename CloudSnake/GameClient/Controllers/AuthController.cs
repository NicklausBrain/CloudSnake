using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GameClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public object Get()
        {
            var auth = this.configuration.GetSection("Auth");

            return new AuthSettings(
                clientId: auth["ClientId"],
                instance: auth["Instance"],
                domain: auth["Domain"],
                tenantId: auth["TenantId"]);
        }

        public class AuthSettings
        {
            public AuthSettings(
                string clientId,
                string instance,
                string domain,
                string tenantId
            )
            {
                this.ClientId = clientId;
                this.Instance = instance;
                this.Domain = domain;
                this.TenantId = tenantId;
            }

            public string ClientId { get; }
            public string Instance { get; }
            public string Domain { get; }
            public string TenantId { get; }
        }
    }
}