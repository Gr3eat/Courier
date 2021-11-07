using Courier.MessagingClient;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Courier.MVVM.Login.ViewModel;
using Courier.MVVM.ChatList.ViewModel;

namespace Courier.MVVM;

internal class ApplicationEntryPoint : IApplicationEntryPoint
{
	private readonly ICredentialStore _credentialStore;
	private readonly ILoginViewModelFactory _loginViewModelFactory;
	private readonly IPickLoginScreenViewModelFactory _pickLoginScreenViewModelFactory;
	private readonly IChatListViewModelFactory _chatListViewModelFactory;
	private readonly IMessagingClientFactory _messagingClientFactory;

	public async Task<IViewModel> GetEntryVmAsync(CancellationToken token)
	{
		var credentials = _credentialStore.GetStoredCredentialsAsync(token);
		if (await credentials.AnyAsync(token))
			return _chatListViewModelFactory
				.Create(
					await Task.WhenAll(await credentials
						.Select(x => _credentialStore.GetCredentialAsync(x, token))
						.Select(async x => await _messagingClientFactory.CreateAsync(await x, token))
						.ToArrayAsync(token))
				);
		else
			return _pickLoginScreenViewModelFactory.Create();

	}

}
