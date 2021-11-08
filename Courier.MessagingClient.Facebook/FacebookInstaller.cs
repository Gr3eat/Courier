using EasyIOC;
using Microsoft.Extensions.DependencyInjection;

[assembly: InstallAllWithEasyIOC]

namespace Courier.MessagingClient.Facebook;

//todo: make automatic registration work
internal class FacebookInstaller : IInstaller
{
	public void Install(IServiceCollection container)
	{
		container.AddTransient<IMessagingPlatformFactory, FacebookMessagingPlatformFactory>();
	}
}
