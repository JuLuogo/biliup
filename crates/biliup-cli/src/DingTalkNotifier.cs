using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Biliup.Notifications
{
    public class DingTalkNotifier : INotifier
    {
        public async Task SendAsync(string message, string webhookUrl)
        {
            using var client = new HttpClient();
            var content = new StringContent($"{{\"msgtype\": \"text\", \"text\": {{\"content\": \"{message}\"}}}}");
            await client.PostAsync(webhookUrl, content);
        }
    }
}