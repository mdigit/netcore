#region Usings

using Autofac;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     Default composition module.
    /// </summary>
    public class DefaultModule : Module
    {
        /// <summary>
        ///     Adds registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be registered.</param>
        protected override void Load( ContainerBuilder builder )
        {
            RegisterComponents( builder );
        }

        /// <summary>
        ///     Registers the service types.
        /// </summary>
        /// <param name="builder">The builder through which components can be registered.</param>
        private static void RegisterComponents( ContainerBuilder builder )
        {
            builder.RegisterType<MainController>()
                   .As<IController>()
                   .InstancePerLifetimeScope()
                   .PropertiesAutowired();
            builder.RegisterType<OptionsService>()
                   .As<IOptionsService>()
                   .InstancePerLifetimeScope()
                   .PropertiesAutowired();
        }
    }
}