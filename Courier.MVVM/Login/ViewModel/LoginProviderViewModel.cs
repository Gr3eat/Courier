using Courier.MessagingClient;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.MVVM.Login.ViewModel;

internal class LoginProviderViewModel
{
	public LoginProviderViewModel(CredentialSource credential)
	{
		Credential = credential;
		ClickCommand = new Command(() => Clicked?.Invoke(this));
	}

	public string Name => Credential.PlatformName;
	public CredentialSource Credential { get; }
	public Command ClickCommand { get; }
	public event Action<LoginProviderViewModel> Clicked;
}
