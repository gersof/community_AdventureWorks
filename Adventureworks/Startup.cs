using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Adventureworks.Core.MiddleWare;
using Adventureworks.Core.Supervisor.Classes;
using Adventureworks.Core.Supervisor.Interfaces;
using Adventureworks.Models;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace Adventureworks
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("AdventureWorksDB");
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonSupervisor,PersonSupervisor>();
            // Add framework services.
            services.AddMvc();
            
            services.AddDbContext<AdventureWorks2017Context>(options =>
                options.UseSqlServer(connectionString).EnableSensitiveDataLogging()
            );

            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<AdventureWorksQuery>();
            services.AddSingleton<AdventureWorksMutation>();
            services.AddSingleton<PersonType>();
            services.AddSingleton<PersonInputType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new AdventureWorksSchema(new FuncDependencyResolver(type => sp.GetService(type))));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseGraphiQl();

            app.UseMvc();

        }
    }
}
