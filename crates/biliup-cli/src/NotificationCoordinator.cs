using System;
using System.Threading.Tasks;

namespace Biliup.Notifications
{
    public class NotificationCoordinator
    {
        public async Task SendNotificationAsync(string platform, string message, string webhookUrl)
        {
            INotifier notifier = platform.ToLower() switch
            {
                "wechat" => new WeChatNotifier(),
                "dingtalk" => new DingTalkNotifier(),
                "email" => new EmailNotifier(),
                _ => throw new ArgumentException("Unsupported platform")
            };

            await notifier.SendAsync(message, webhookUrl);
        }
    }

    public interface INotifier
    {
        Task SendAsync(string message, string webhookUrl);
    }
}