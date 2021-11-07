using Courier.MVVM;
using EasyIOC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading;
using Application = Microsoft.Maui.Controls.Application;

namespace Courier.Gui
{
	public partial class App : Application
	{
		private readonly IServiceProvider _serviceProvider;
		public App()
		{
			InitializeComponent();
			_serviceProvider = InstallServices();
			MainPage = _serviceProvider.GetRequiredService<IApplicationEntryPoint>().GetEntryVmAsync(CancellationToken.None).Result.CreatePage();
		}


		private static IServiceProvider InstallServices()
		{
			var collection = new ServiceCollection();
			collection.WithEasyIoc(Assembly.GetExecutingAssembly());
			return collection.BuildServiceProvider();
		}
	}
}
