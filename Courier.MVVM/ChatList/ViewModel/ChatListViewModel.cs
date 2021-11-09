using Courier.MessagingClient;
using EasyIOC.CodeGen;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Courier.MVVM.ChatList.ViewModel;

internal class ChatListViewModel : IChatListViewModel
{
	private readonly IEnumerable<IMessagingClient> _clients;

	[Factory]
	public ChatListViewModel([Parameter] IEnumerable<IMessagingClient> clients)
	{
		_clients = clients;
	}

	public INavigation? Navigation { get; set; }

	public event PropertyChangedEventHandler? PropertyChanged;
}
