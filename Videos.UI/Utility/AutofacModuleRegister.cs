using Autofac;
using Videos.Application.Users;
using Videos.Database;

namespace Videos.UI.Utility
{
    public class AutofacModuleRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<RedisDb>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CreateUser>().AsSelf().InstancePerLifetimeScope();
			builder.RegisterType<ElasticSearchDb>().AsSelf().InstancePerLifetimeScope();
		}
    }
}
