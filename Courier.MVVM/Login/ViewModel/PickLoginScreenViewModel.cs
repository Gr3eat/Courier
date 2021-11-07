using Courier.MessagingClient;
using EasyIOC.CodeGen;
using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace Courier.MVVM.Login.ViewModel;

internal class PickLoginScreenViewModel : IPickLoginScreenViewModel
{
	private readonly ISuportedLoginsProvider _suportedLoginsProvider;

	[Factory]
	public PickLoginScreenViewModel(ISuportedLoginsProvider suportedLoginsProvider)
	{
		_suportedLoginsProvider = suportedLoginsProvider;
	}

	public IEnumerable<string> SuportedLogins { get; }

	public Page CreatePage()
	{
		throw new System.NotImplementedException();
	}
}
