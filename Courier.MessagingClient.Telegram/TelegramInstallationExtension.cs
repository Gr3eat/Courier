using Courier.MessagingClient.Facebook;
using Microsoft.Extensions.DependencyInjection;

namespace Courier.MessagingClient.Telegram;

public static class TelegramInstallationExtension
{

	public static IServiceCollection WithTelegram(this IServiceCollection collection)
	{
		var installer = new TelegramInstaller();
		installer.Install(collection);
		return collection;
	}
}
