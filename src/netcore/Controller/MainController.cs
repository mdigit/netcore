#region Usings

using System;
using System.Diagnostics;
using System.Text;
using mdigit.netcore.Definition.Enums;

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

        /// <summary>
        ///     Gets or sets the <see cref="ISenderService" />
        /// </summary>
        public ISenderService SenderService
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        /// <summary>
        ///     Gets or sets the <see cref="IReceiverService" />
        /// </summary>
        public IReceiverService ReceiverService
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
            ShowOptions();
            while ( option != null )
            {
                option = ReadLineWithCancel();

                if ( !OptionsService.ValidateOption( option ) )
                {
                    Console.WriteLine($"{Environment.NewLine}Invalid option. Try again.");
                    continue;
                }

                Console.WriteLine( $"{Environment.NewLine}{GetFunction( option )}" );
                ExecuteFunction( option.OptionToFunction() );
            }
        }

        /// <summary>
        ///     Shows the options.
        /// </summary>
        private void ShowOptions()
        {
            Console.Clear();
            foreach ( var option in OptionsService.GetValidOptions() )
                Console.WriteLine( $"- {option.Key}\t{option.FunctionName}" );
            Console.WriteLine( "- <Esc>\tExit" );
        }

        /// <summary>
        ///     Gets the corresponding function name from the given option.
        /// </summary>
        /// <param name="option">The option.</param>
        /// <returns>Returns a function name.</returns>
        private String GetFunction( String option ) => option == "t" ? "Test" : String.Empty;

        /// <summary>
        ///     Executes the given function.
        /// </summary>
        /// <param name="function">The function.</param>
        private void ExecuteFunction( Function function )
        {
            switch ( function )
            {
                case Function.SendMessage:
                    SenderService.Send();
                    break;
                case Function.StartListening:
                    ReceiverService.StartListening();
                    break;
                case Function.StoptListening:
                    ReceiverService.StopListening();
                    break;
                default:
                    Console.WriteLine( $"Function {function} not implemented yet." );
                    break;
            }
        }

        #endregion
    }
}