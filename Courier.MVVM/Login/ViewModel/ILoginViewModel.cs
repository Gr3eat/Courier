using System.Windows.Input;

namespace Courier.MVVM.Login.ViewModel;

public interface ILoginViewModel : IViewModel
{
	string Username { get; set; }
	string Password { get; set; }

	ICommand LoginCommand { get; set; }
}
