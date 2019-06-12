using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Swashbuckle.AspNetCore.Swagger;
using dotnetAPI.Models;
using Microsoft.EntityFrameworkCore;
using dotnetAPI.MiddleWare;

namespace dotnetAPI
{
    public class Startup
    {
    
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

         

            services.AddDbContext<SitDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "SIT Testing API",
                    Description = "API controller to talk to the testing DB",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "The Knight King",
                        Email = string.Empty,
                        Url = "https://got.com"
                    },
                    License = new License
                    {
                        Name = "Use under MIT",
                     
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //using (var serviceScope = app.ApplicationServices.CreateScope())
            //{
            //    var services = serviceScope.ServiceProvider;
            //    var myDbContext = services.GetService<SitDbContext>();
            //   // myDbContext.
            //}

            loggerFactory.AddFile(Configuration.GetSection("Logging"));
          

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.ShowExtensions();
            });
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<IpWhiteListMiddleWare>();
            // set startup file to index.html for easy testing
            app.UseDefaultFiles();
            //added support for static file
            // 401's on favicons are no more!
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseMvc();
        }
    }
}
