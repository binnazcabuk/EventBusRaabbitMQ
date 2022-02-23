﻿using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.RabbitMQ
{
    public class RabbitMQPersistentConnection : IDisposable
    {
        private IConnection connection;
        private readonly IConnectionFactory connectionFactory;
        private readonly int retryCount;
        private object lock_object = new object();
        private bool _disposed;

        public RabbitMQPersistentConnection(IConnectionFactory connectionFactory, int retyCount = 5)
        {
            this.connectionFactory=connectionFactory;
            this.retryCount=retyCount;
        }

        public bool IsConnection => connection!=null&&connection.IsOpen;
        public IModel CreateModel()
        {
            return connection.CreateModel();
        }
        public void Dispose()
        {
            _disposed=true;
            connection.Dispose();
        }

        public bool TryConnect()
        {
            lock (lock_object)
            {
                var policy = Policy.Handle<BrokerUnreachableException>()
                    .Or<SocketException>()
                    .WaitAndRetry(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {


                    }

                         );
                policy.Execute(() =>
                {
                    connection=connectionFactory.CreateConnection();
                });

                if (IsConnection)
                {
                    connection.ConnectionShutdown+=Connection_ConnectionShutdown;
                    connection.CallbackException+=Connection_CallbackException;
                    connection.ConnectionBlocked+=Connection_ConnectionBlocked;

                    return true;
                }
                return false;
            }
        }

        private void Connection_ConnectionBlocked(object sender, ConnectionBlockedEventArgs e)
        {
            if (!_disposed) return;
            TryConnect();
        }

        private void Connection_CallbackException(object sender, CallbackExceptionEventArgs e)
        {
            if (!_disposed) return;
            TryConnect();
        }

        private void Connection_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            if (!_disposed) return;
            TryConnect();
        }
    }
}