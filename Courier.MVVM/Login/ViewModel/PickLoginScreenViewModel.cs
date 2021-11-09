using Courier.MessagingClient;
using Courier.MVVM.Login.View;
using EasyIOC.CodeGen;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;

namespace Courier.MVVM.Login.ViewModel;

[View(typeof(PickLoginScreenPage), IsNavigation = true)]
internal class PickLoginScreenViewModel : IPickLoginScreenViewModel
{
	private readonly ISuportedLoginsProvider _suportedLoginsProvider;
	private readonly ILoginViewModelFactory _loginViewModelFactory;

	[Factory]
	public PickLoginScreenViewModel(ISuportedLoginsProvider suportedLoginsProvider, ILoginViewModelFactory loginViewModelFactory)
	{
		_suportedLoginsProvider = suportedLoginsProvider;
		_loginViewModelFactory = loginViewModelFactory;
		SuportedLogins = _suportedLoginsProvider.SuportedCredentialSources.Select(x => new LoginProviderViewModel(x)).ToArray();
		foreach (var login in SuportedLogins)
			login.Clicked += LoginClicked;
	}

	private async void LoginClicked(LoginProviderViewModel login)
	{
		var vm = _loginViewModelFactory.Create(login.Credential);
		await Navigation.PushAsync(vm.CreatePage());
	}

	public IEnumerable<LoginProviderViewModel> SuportedLogins { get; }
	public INavigation Navigation { get; set; }
}
