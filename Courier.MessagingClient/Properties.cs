using EasyIOC;
using Microsoft.Extensions.DependencyInjection;

[assembly: InstallAllWithEasyIOC]

namespace Courier.MessagingClient
{
	public class Installer : IInstaller
	{
		public void Install(IServiceCollection container)
		{
			container.AddTransient<ISuportedLoginsProvider, SuportedLoginsProvider>();
		}
	}
}