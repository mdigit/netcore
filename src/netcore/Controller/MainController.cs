#region Usings

using System;
using System.Diagnostics;
using System.Text;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     The main controller class.
    /// </summary>
    public class MainController : IController
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the <see cref="IOptionsService" />
        /// </summary>
        public IOptionsService OptionsService
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        #endregion

        /// <summary>
        ///     Reads the console with cancel.
        /// </summary>
        /// <returns>Returns null if ESC key pressed during input.</returns>
        private static String ReadLineWithCancel()
        {
            String result = null;

            var buffer = new StringBuilder();

            //The key is read passing true for the intercept argument to prevent
            //any characters from displaying when the Escape key is pressed.
            var consoleKeyInfo = Console.ReadKey( true );
            while ( consoleKeyInfo.Key != ConsoleKey.Enter && consoleKeyInfo.Key != ConsoleKey.Escape )
            {
                Console.Write( consoleKeyInfo.KeyChar );
                buffer.Append( consoleKeyInfo.KeyChar );
                consoleKeyInfo = Console.ReadKey( true );
            }

            if ( consoleKeyInfo.Key == ConsoleKey.Enter )
                result = buffer.ToString();

            return result;
        }

        #region Implementation of IController

        /// <summary>
        ///     The run method.
        /// </summary>
        public void Run()
        {
            var option = String.Empty;
            while ( option != null )
            {
                ShowOptions();
                option = ReadLineWithCancel();

                if ( VerifyOption( option ) )
                    Console.WriteLine( $"{Environment.NewLine}{GetFunction( option )}" );
            }
        }

        /// <summary>
        ///     Shows the options.
        /// </summary>
        private void ShowOptions()
        {
            Console.Clear();
            Console.WriteLine( "- <Esc>\tExit" );
            Console.WriteLine( "- t\tTest" );
        }

        /// <summary>
        ///     Verfies the given option.
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        private Boolean VerifyOption( String option ) => option == "t";

        /// <summary>
        ///     Gets the corresponding function name from the given option.
        /// </summary>
        /// <param name="option">The option.</param>
        /// <returns>Returns a function name.</returns>
        private String GetFunction( String option ) => option == "t" ? "Test" : String.Empty;

        #endregion
    }
}