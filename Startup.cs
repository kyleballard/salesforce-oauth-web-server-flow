using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesforceOAuth.Infrastructure;

namespace SalesforceOAuth
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // For production, be sure to add user secrets (for development) and environment variables/azure key vault (for production) #endregion
            //    safe configuration of client_secret and other sensitive data.
            var config = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", optional: true)
                             .Build();
            services.Configure<SalesforceConfig>(config.GetSection("Salesforce"));

            services.AddMvc();
            services.AddHttpClient<SalesforceClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // If you plan to place HTML files in the wwwroot folder, uncomment these two lines
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
