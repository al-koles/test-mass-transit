using MassTransit;
using Microsoft.Extensions.Logging;
using TestMassTransit.Contracts;

namespace TestMassTransit.Consumer.Console.Consumers;

public class SendMessageConsumer : IConsumer<SendMessageCommand>
{
    private readonly ILogger<SendMessageConsumer> _logger;

    public SendMessageConsumer(
        ILogger<SendMessageConsumer> logger
    )
    {
        _logger = logger;
    }

    public  Task Consume(ConsumeContext<SendMessageCommand> context)
    {
        _logger.LogInformation("Consumed and sent message: " + context.Message.Text);

        return Task.CompletedTask;
    }
}
