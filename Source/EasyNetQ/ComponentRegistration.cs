﻿using EasyNetQ.Consumer;
using EasyNetQ.Interception;
using EasyNetQ.Producer;
using EasyNetQ.Scheduling;

namespace EasyNetQ
{
    /// <summary>
    /// Registers the default EasyNetQ components in our internal super-simple IoC container.
    /// </summary>
    public class ComponentRegistration
    {
        public static void RegisterServices(IContainer container)
        {
            Preconditions.CheckNotNull(container, "container");

            // Note: IConnectionConfiguration gets registered when RabbitHutch.CreateBus(..) is run.

            // default service registration
            container
                .Register(_ => container)       
                .Register<ISerializer, JsonSerializer>()
                .Register<IConventions, Conventions>()
                .Register<IEventBus, EventBus>()
                .Register<ITypeNameSerializer, TypeNameSerializer>()
                .Register<ICorrelationIdGenerationStrategy, DefaultCorrelationIdGenerationStrategy>()                
                .Register<IMessageSerializationStrategy, DefaultMessageSerializationStrategy>()
                .Register<IMessageDeliveryModeStrategy, MessageDeliveryModeStrategy>()
                .Register<ITimeoutStrategy, TimeoutStrategy>()
                .Register<IClusterHostSelectionStrategy<ConnectionFactoryInfo>, RandomClusterHostSelectionStrategy<ConnectionFactoryInfo>>()
                .Register<IProduceConsumeInterceptor, DefaultInterceptor>()
                .Register<IConsumerDispatcherFactory, ConsumerDispatcherFactory>()
                .Register<IPublishExchangeDeclareStrategy, PublishExchangeDeclareStrategy>()
                .Register<IConsumerErrorStrategy, DefaultConsumerErrorStrategy>()
                .Register<IErrorMessageSerializer, DefaultErrorMessageSerializer>()
                .Register<IHandlerRunner, HandlerRunner>()
                .Register<IInternalConsumerFactory, InternalConsumerFactory>()
                .Register<IConsumerFactory, ConsumerFactory>()
                .Register<IConnectionFactory, ConnectionFactoryWrapper>()
                .Register<IPersistentChannelFactory, PersistentChannelFactory>()
                .Register<IPersistentConnectionFactory, PersistentConnectionFactory>()
                .Register<IClientCommandDispatcherFactory, ClientCommandDispatcherFactory>()
                .Register<IPublishConfirmationListener, PublishConfirmationListener>()
                .Register<IHandlerCollectionFactory, HandlerCollectionFactory>()
                .Register<IAdvancedBus, RabbitAdvancedBus>()
                .Register<IRpc, Rpc>()
                .Register<ISendReceive, SendReceive>()
                .Register<IScheduler, ExternalScheduler>()
                .Register<IBus, RabbitBus>();
        }
    }
}