using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionAppWithQueues
{
    public static class Function2
    {
        [FunctionName("CollectorQueueOutput")]
        public static void Run([TimerTrigger("*/2 * * * * *")]TimerInfo myTimer,
                       ILogger log,
                       [Queue("101functionsqueue", Connection = "AzureWebJobsStorage")] ICollector<QueueObject> queueCollector)
        {
            log.LogInformation("101 Azure Function Demo - Storage Queue output");

            for (int i = 0; i < 10; i++)
            {
                queueCollector.Add(new QueueObject { Id = i });
            }
        }
    }

    public class QueueObject
    {
        public int Id { get; set; }
    }
}
