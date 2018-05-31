#region Usings

using System;
using Autofac;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     The program.
    /// </summary>
    static class Program
    {
        /// <summary>
        ///     The main entry point.
        /// </summary>
        /// <param name="args"></param>
        private static void Main( String[] args )
        {
            // Get IoC container
            var container = Bootstrapper.Run();

            using ( var scope = container.BeginLifetimeScope() )
            {
                var mainController = scope.Resolve<IController>();
                mainController.Run();
            }
        }
    }
}