using Microsoft.Extensions.DependencyInjection;

namespace Courier.MessagingClient.Facebook;

public static class FacebookInstallationExtension
{

	public static IServiceCollection WithFacebookMessenger(this IServiceCollection collection)
	{
		var installer = new FacebookInstaller();
		installer.Install(collection);
		return collection;
	}
}
