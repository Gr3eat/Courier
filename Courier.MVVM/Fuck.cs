using EasyIOC;
using Courier.MVVM.Login.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Courier.MVVM;

public class Installer : IInstaller
{
	public void Install(IServiceCollection container)
	{
		container.AddTransient<IApplicationEntryPoint, ApplicationEntryPoint>();
		container.AddTransient<ILoginViewModelFactory, LoginViewModelFactory>();
	}
}
