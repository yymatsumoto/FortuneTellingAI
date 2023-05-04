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
             //まずは1ファイルで完結させたいのでcssを直接記載
            return $@"<!DOCTYPE html>
<html>
  <head>
    <meta charset=""utf-8"">
<style type=""text/css"">
body {{
  background-color: #f7f7f7; /* 薄いグレー */
  font-family: 'Helvetica Neue', sans-serif; /* サンセリフ体 */
  color: #333; /* 濃いグレー */
  line-height: 1.5;
}}

/* 結果表示エリア */
.result-area {{
  max-width: 960px;
  margin: 0 auto;
  padding: 30px;
  text-align: center;
}}

.result-area h1 {{
  font-size: 3rem;
  margin: 0;
  font-weight: bold;
  margin-bottom: 20px;
}}

.result-area p {{
  font-size: 1.5rem;
  margin: 0;
}}
</style>
  </head>
  <body>
    {string.Join("<br />", chatGptContent.Split("\n\n"))}
    <br />
    更新 : {System.TimeZoneInfo.ConvertTimeFromUtc(DateTime.Now, System.TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time")).ToString("yyyy/MM/dd HH:mm")}
  </body>
</html>
";
        }
    }
}
