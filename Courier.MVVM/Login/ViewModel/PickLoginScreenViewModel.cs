using Courier.MessagingClient;
using Courier.MVVM.ChatList.ViewModel;
using Courier.MVVM.Login.View;
using EasyIOC.CodeGen;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace Courier.MVVM.Login.ViewModel;

[View(typeof(PickLoginScreenPage), IsNavigation = true)]
internal class PickLoginScreenViewModel : IPickLoginScreenViewModel
{
	private readonly ISuportedLoginsProvider _suportedLoginsProvider;
	private readonly ILoginViewModelFactory _loginViewModelFactory;
	private readonly IChatListViewModelFactory _chatListViewModelFactory;

	public event PropertyChangedEventHandler? PropertyChanged;

	[Factory]
	public PickLoginScreenViewModel(
		ISuportedLoginsProvider suportedLoginsProvider,
		ILoginViewModelFactory loginViewModelFactory,
		IChatListViewModelFactory chatListViewModelFactory)
	{
		_suportedLoginsProvider = suportedLoginsProvider;
		_loginViewModelFactory = loginViewModelFactory;
		SuportedLogins = _suportedLoginsProvider.SuportedCredentialSources.Select(x => new LoginProviderViewModel(x)).ToArray();
		foreach (var login in SuportedLogins)
			login.Clicked += LoginClicked;
		_chatListViewModelFactory = chatListViewModelFactory;
	}

	private async void LoginClicked(LoginProviderViewModel login)
	{
		var vm = _loginViewModelFactory.Create(login.Credential);
		await Navigation.PushAsync(vm.CreatePage());
		if (vm.Result is not null)
		{
			await Navigation.PopToRootAsync();
			await Navigation.PushModalAsync(_chatListViewModelFactory.Create(new []{await vm.Result.CreateClientAsync(CancellationToken.None)}).CreatePage());
		}
	}

	public IEnumerable<LoginProviderViewModel> SuportedLogins { get; }
	public INavigation? Navigation { get; set; }
}
