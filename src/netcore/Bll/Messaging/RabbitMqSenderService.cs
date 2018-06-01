#region Usings

using System;
using System.Diagnostics;
using System.Text;
using RabbitMQ.Client;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     The RabbitMq message sender service class.
    /// </summary>
    public class RabbitMqSenderService : ISenderService
    {
        #region Fields

        /// <summary>
        ///     The parameters.
        /// </summary>
        private IParameters _parameters;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the <see cref="IParameterService" />.
        /// </summary>
        public IParameterService ParameterService
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        /// <summary>
        ///     Gets the parameters
        /// </summary>
        private IParameters Parameters => _parameters ?? ( _parameters = ParameterService.GetParameters() );

        #endregion

        #region Implementation of ISenderService

        /// <summary>
        ///     Sends a message to the message broker.
        /// </summary>
        public void Send()
        {
            var factory = new ConnectionFactory { HostName = Parameters.HostName };
            using ( var connection = factory.CreateConnection() )
            {
                using ( var channel = connection.CreateModel() )
                {
                    channel.QueueDeclare( queue: Parameters.QueueName,
                                          durable: false,
                                          exclusive: false,
                                          autoDelete: false,
                                          arguments: null );

                    const String message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes( message );

                    channel.BasicPublish( exchange: "",
                                          routingKey: "hello",
                                          basicProperties: null,
                                          body: body );
                    Console.WriteLine( " [->] Sent {0}", message );
                }
            }
        }

        #endregion
    }
}