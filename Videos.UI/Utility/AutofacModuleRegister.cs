using Autofac;
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
        }
    }
}
