using Microsoft.Extensions.DependencyInjection;

namespace Courier.MessagingClient.Maui;

public static class InstallerExtension
{
	public static IServiceCollection WithMauiCredentials(this IServiceCollection container)
	{
		return container.AddTransient<ICredentialStore, MauiCredentialStore>();
	}
}
