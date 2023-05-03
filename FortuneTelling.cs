using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FortunTellingAI.Function
{
    public class FortuneTelling
    {
        [FunctionName("FortuneTelling")]
        public void Run([TimerTrigger("0 */1 * * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
