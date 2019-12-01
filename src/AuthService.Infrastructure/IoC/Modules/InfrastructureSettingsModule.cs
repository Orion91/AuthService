using AuthService.Application.Extensions;
using AuthService.Infrastructure.Settings;
using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthService.Infrastructure.IoC.Modules
{
	public class InfrastructureSettingsModule : Autofac.Module
	{
		private readonly IConfiguration _configuration;

		public InfrastructureSettingsModule(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		protected override void Load(ContainerBuilder builder)
		{

			builder.RegisterInstance(_configuration.GetSettings<SqlSettings>())
					.SingleInstance();
			builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
					.SingleInstance();
		}
	}
}
