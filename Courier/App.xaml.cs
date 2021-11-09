using Courier.MessagingClient.Facebook;
using Courier.MessagingClient.Maui;
using Courier.MVVM;
using EasyIOC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using System;
using System.Reflection;
using System.Threading;
using Application = Microsoft.Maui.Controls.Application;

namespace Courier
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
			collection
				.WithEasyIoc(Assembly.GetExecutingAssembly())
				.WithMauiCredentials()
				.WithFacebookMessenger();
			return collection.BuildServiceProvider();
		}
	}
}
