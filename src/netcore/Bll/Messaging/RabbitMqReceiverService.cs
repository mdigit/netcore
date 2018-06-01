#region Usings

using System;
using System.Diagnostics;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

#endregion

namespace mdigit.netcore
{
    /// <summary>
    ///     The RabbitMq message receiver service class.
    /// </summary>
    public class RabbitMqReceiverService : IReceiverService, IDisposable
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

        /// <summary>
        ///     Gets or sets the connection.
        /// </summary>
        private IConnection Connection
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        /// <summary>
        ///     Gets or sets the connection.
        /// </summary>
        private IModel Channel
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        /// <summary>
        ///     Gets or sets the connection.
        /// </summary>
        private EventingBasicConsumer Consumer
        {
            [DebuggerStepThrough]
            get;
            [DebuggerStepThrough]
            set;
        }

        #endregion

        #region IDisposable

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if ( Consumer != null )
            {
                Consumer.Received -= EventHandler;
                Console.WriteLine( $"Listening to queue {Parameters.QueueName} stopped." );
            }

            Channel?.Dispose();
            Connection?.Dispose();
        }

        #endregion

        #region Private members

        /// <summary>
        ///     Handles the received messages.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="ea">The <see cref="BasicDeliverEventArgs" />.</param>
        private void EventHandler( Object model, BasicDeliverEventArgs ea )
        {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString( body );
            Console.WriteLine( " [<-] Received {0}", message );
        }

        #endregion

        #region Implementation of IReceiverService

        /// <summary>
        ///     Start waiting for message from the message broker.
        /// </summary>
        public void StartListening()
        {
            if ( Connection != null && Connection.IsOpen )
            {
                Console.WriteLine( "Already listening" );
                return;
            }

            var factory = new ConnectionFactory { HostName = Parameters.HostName };
            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();
            Channel.QueueDeclare( queue: Parameters.QueueName,
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null );
            Consumer = new EventingBasicConsumer( Channel );
            Consumer.Received += EventHandler;
            Channel.BasicConsume( queue: Parameters.QueueName,
                                  autoAck: true,
                                  consumer: Consumer );

            Console.WriteLine( $"Listening to queue {Parameters.QueueName} started." );
        }

        /// <summary>
        ///     Stops waiting for message from the message broker.
        /// </summary>
        public void StopListening() => Dispose();

        #endregion
    }
}