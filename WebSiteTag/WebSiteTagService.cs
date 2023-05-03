using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortuneAI.WebSiteTag
{
    internal class WebSiteTagService
    {

        public static string ConvertChatGptContentToWebSiteTag(string chatGptContent)
        {
            return $@"
<!DOCTYPE html>
<html>
  <head>
  </head>
  <body>
    更新 : {DateTime.Today.ToString("yyyy/MM/dd HH:ss")}
    {chatGptContent}
  </body>
</html>
";
        }
    }
}
