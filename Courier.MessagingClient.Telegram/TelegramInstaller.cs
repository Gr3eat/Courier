using Courier.MessagingClient.Facebook;
using EasyIOC;
using Microsoft.Extensions.DependencyInjection;

[assembly: InstallAllWithEasyIOC]

namespace Courier.MessagingClient.Telegram;

//todo: make automatic registration work
internal class TelegramInstaller : IInstaller
{
	public void Install(IServiceCollection container)
	{
		container.AddTransient<IMessagingPlatformFactory, TelegramMessagingPlatformFactory>();
	}
}
