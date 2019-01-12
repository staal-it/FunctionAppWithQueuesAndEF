using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionAppWithQueues
{
    public static class Function3
    {
        [FunctionName("HandleQueueItem")]
        public static void Run([QueueTrigger("101functionsqueue", Connection = "AzureWebJobsStorage")]QueueObject myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem.Id}");
        }
    }
}
