using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using TestMassTransit.Consumer.Console.Consumers;

var services = new ServiceCollection();

services.AddMassTransit(x =>
{
    x.AddConsumer<SendMessageConsumer>();
    
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});
