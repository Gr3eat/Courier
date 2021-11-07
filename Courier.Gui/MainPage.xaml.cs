using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace Courier.Gui
{
	public partial class MainPage : ContentPage
	{
		int count = 0;

		public MainPage()
		{
			BindingContext = this;
			InitializeComponent();
		}

		public Command Navigate => new(async () => await Navigation.PushAsync(new Login.LoginPage()));

		private async void OnCounterClicked(object sender, EventArgs e)
		{
			count++;
			await Navigation.PushAsync(new Login.LoginPage());
		}
	}
}
