using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FortuneAI.ChatGpt.Entity
{
    internal class ChatGptResponseChoiceEntity
    {
        [JsonPropertyName("message")]
        public ChatGptPostMessageEntity Message { get; set; } = new ChatGptPostMessageEntity();
    }
}
