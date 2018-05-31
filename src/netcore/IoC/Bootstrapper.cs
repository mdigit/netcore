#region Usings

using System;
using System.IO;
using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     Class initializing the IoC container for the application.
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        ///     Runs the bootstrapper.
        /// </summary>
        /// <remarks>Returns the created container.</remarks>
        public static IContainer Run()
            => ConfigurateAutofacContainer();

        #region Private Methods

        /// <summary>
        ///     Configures autofac.
        /// </summary>
        /// <remarks>
        ///     - Best Practices:
        ///     <a href="https://code.google.com/p/autofac/wiki/BestPractices#Use_Constructor_Injection_whenever_Possible"></a>
        ///     - Lifetime Primer: <a href="http://nblumhardt.com/2011/01/an-autofac-lifetime-primer/"></a>
        /// </remarks>
        /// <remarks>Returns the created container.</remarks>
        private static IContainer ConfigurateAutofacContainer()
        {
            var builder = new ContainerBuilder();

            ReadConfig( builder );
            var container = builder.Build();

            // Initialize component here if needed

            return container;
        }

        /// <summary>
        ///     Reads the configuration file and adds the defined registrations to the builder.
        /// </summary>
        /// <param name="builder">A <see cref="ContainerBuilder" /> used to register the types.</param>
        private static void ReadConfig( ContainerBuilder builder )
        {
            // Add the configuration to the ConfigurationBuilder.
            var config = new ConfigurationBuilder();

            var path = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "autofac.json" );
            config.AddJsonFile( path );

            // Register the ConfigurationModule with Autofac.
            var module = new ConfigurationModule( config.Build() );
            builder.RegisterModule( module );
        }

        #endregion
    }
}