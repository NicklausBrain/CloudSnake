using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameClient.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace GameClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddAzureAdBearer(options =>
                {
                    options.ClientId = "352a9497-51a7-4712-8512-4b0a3454e38e";
                    options.ClientSecret = "/O$}=i@X)3J)[w=I;*Z=W9*./1&(WyZ#Bw/&&8C&$";
                    options.Instance = "https://login.microsoftonline.com/";
                    options.Domain = "NicklausBrainhotmail.onmicrosoft.com";
                    options.TenantId = "27e4fcee-63ff-47c2-9d92-fa40d44e8ba5";
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.useo
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
