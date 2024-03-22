using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestMassTransit.Contracts;

var services = new ServiceCollection();
services.AddLogging(bld =>
{
    bld.AddConsole();
    bld.AddDebug();
    bld.AddSimpleConsole();
});

services.AddMassTransit(x => { x.UsingRabbitMq((context, cfg) => { }); });


for (;;)
{
    Console.WriteLine("Enter message: ");
    var message = Console.ReadLine();

    using var scope = services.BuildServiceProvider().CreateScope();
    var bus = scope.ServiceProvider.GetRequiredService<IBus>();
    
    await bus.Send(new SendMessageCommand() { Text = message! });
}