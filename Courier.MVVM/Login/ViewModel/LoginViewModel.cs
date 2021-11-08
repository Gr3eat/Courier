using Courier.Gui.Login;
using Courier.MessagingClient;
using EasyIOC.CodeGen;
using Microsoft.Maui.Controls;
using System;
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
	}

	public string Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public ICommand LoginCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
