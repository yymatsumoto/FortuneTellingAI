using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FortuneAI.ChatGpt.Entity
{
    internal class ChatGptResponseEntity
    {
        [JsonPropertyName("choices")]
        public List<ChatGptResponseChoiceEntity> Choices { get; set; } = new List<ChatGptResponseChoiceEntity>();
    }
}
