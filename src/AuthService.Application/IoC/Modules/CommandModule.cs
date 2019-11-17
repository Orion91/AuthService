using AuthService.Application.Commands;
using AuthService.Application.CQRS;
using Autofac;
using System.Reflection;

namespace AuthService.Application.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
		protected override void Load(ContainerBuilder builder)
		{
			var assembly = typeof(CommandModule)
				.GetTypeInfo()
				.Assembly;

			builder.RegisterAssemblyTypes(assembly)
				.AsClosedTypesOf(typeof(ICommandHandler<>))
				.InstancePerLifetimeScope();

			builder.RegisterType<CommandDispatcher>()
				.As<ICommandDispatcher>()
				.InstancePerLifetimeScope();
		}

	}
}