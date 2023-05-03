using FortuneAI.ChatGpt.Entity;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FortuneAI.ChatGpt
{
    internal class ChatGptApiService
    {
        private string _url = "https://api.openai.com/v1/chat/completions";

        private string _key = "";

        public async Task<string> GetFortuneTelling()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _key);

            var message = $@"{DateTime.Today.ToString("yyyy/MM/dd")}の占いを作成してください。星座ごとに、12個の結果を作成してください。1つの星座は20文字程度で作成してください。結果以外の文章は生成しないでください。";
            var jsonStr = JsonSerializer.Serialize(new Dictionary<string, object>()
            {
                { "model", "gpt-3.5-turbo" },
                { "messages", new List<ChatGptPostMessageEntity>(){ new ChatGptPostMessageEntity() { Role = "user", Content = message } } }
            });
            var content = new StringContent(jsonStr, Encoding.UTF8, @"application/json");

            try
            {
                var response = await client.PostAsync(_url, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseStr = await response.Content.ReadAsStringAsync();
                    var responseEntity = JsonSerializer.Deserialize<Entity.ChatGptResponseEntity>(responseStr);
                    return responseEntity.Choices[0].Message.Content;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}
