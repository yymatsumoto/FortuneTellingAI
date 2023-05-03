using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FortuneAI.Function
{
    public class FortuneTelling
    {
        [FunctionName("FortuneTelling")]
        public static async void Run([TimerTrigger("0 * */1 * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            var result = await new FortuneAI.ChatGpt.ChatGptApiService().GetFortuneTelling();
        }
    }
}
