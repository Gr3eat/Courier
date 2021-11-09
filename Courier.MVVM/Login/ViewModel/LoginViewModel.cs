using AsyncAwaitBestPractices.MVVM;
using Courier.Gui.Login;
using Courier.MessagingClient;
using EasyIOC.CodeGen;
using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Courier.MVVM.Login.ViewModel;

[View(typeof(LoginPage))]
internal class LoginViewModel : ILoginViewModel
{

	private readonly ICredentialStore _credentialStore;
	private readonly CredentialSource _credentialSource;

	[Factory]
	public LoginViewModel(
		ICredentialStore credentialStore,
		[Parameter] CredentialSource credentialSource)
	{
		_credentialStore = credentialStore;
		_credentialSource = credentialSource;
		LoginCommand = new AsyncCommand(Login);
	}

	private async Task Login()
	{
		Result = await _credentialStore.GetCredentialAsync(new CredentialIdentifier(_credentialSource, Label), CancellationToken.None);
		await Navigation.PopAsync(true);
	}

	public ICommand LoginCommand { get; }
	public INavigation? Navigation { get; set; }
	public ICredential? Result { get; private set; }
	public string Username { get; set; }
	public string Password { get; set; }
	public string Label { get; set; }

	public event PropertyChangedEventHandler? PropertyChanged;
}
