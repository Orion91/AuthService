using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Application.Services.Interfaces;
using AuthService.Application.Services.Implementations;
using AuthService.Core.Repositories;
using AuthService.Infrastructure.Repositories;
using AuthService.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AuthService.Application.IoC.Modules;
using AuthService.Infrastructure.IoC.Modules;
using FluentValidation.AspNetCore;

namespace AuthService.API
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

		public ILifetimeScope AutofacContainer { get; private set; }

		public IConfiguration Configuration { get; private set; }

		public Startup(IWebHostEnvironment env)
        {
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
        }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordService, PasswordService>();
			services.AddScoped<IJwtProvider, JwtProvider>();
			services.AddOptions();
			services.AddControllers()
				.AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Startup>());
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterModule<CommandModule>();
			builder.RegisterModule(new InfrastructureSettingsModule(Configuration));
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

			AutofacContainer = app.ApplicationServices.GetAutofacRoot();
        }
    }
}
