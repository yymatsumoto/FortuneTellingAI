using System;
using System.Linq;
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
            var requireUpdate = new AzureBlobStorageService().CheckRequireUpdate();
            if (!requireUpdate.Result) { return; }

            var chatGptContent = new FortuneAI.ChatGpt.ChatGptApiService().GetFortuneTelling();
            //�����Ȕ���ł͂Ȃ����A12�s�ȏ�Ȃ���ΐ������s�Ƃ��čX�V���Ȃ�
            if (chatGptContent.Result.Split("\n\n").Count() < 12) { return; }
            new AzureBlobStorageService().ReplaceFile(WebSiteTagService.ConvertChatGptContentToWebSiteTag(chatGptContent.Result));
        }
    }
}
