using System.Collections.Generic;

namespace Courier.MVVM.Login.ViewModel;

internal interface IPickLoginScreenViewModel : IViewModel
{
	IEnumerable<string> SuportedLogins { get; }
}