using System;
using FortuneAI.AzureBlobStorage;
using FortuneAI.WebSiteTag;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FortuneAI.Function
{
    public class FortuneTelling
    {
        [FunctionName("FortuneTelling")]
        public static void Run([TimerTrigger("0 0 * * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log)
        {
            var chatGptContent = new FortuneAI.ChatGpt.ChatGptApiService().GetFortuneTelling();
            new AzureBlobStorageService().ReplaceFile(WebSiteTagService.ConvertChatGptContentToWebSiteTag(chatGptContent.Result));
        }
    }
}
