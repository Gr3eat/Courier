using Courier.MessagingClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Courier.MVVM.Login.ViewModel;
using Courier.MVVM.ChatList.ViewModel;

namespace Courier.MVVM;

internal class ApplicationEntryPoint : IApplicationEntryPoint
{
	private readonly ICredentialStore _credentialStore;
	private readonly IPickLoginScreenViewModelFactory _pickLoginScreenViewModelFactory;
	private readonly IChatListViewModelFactory _chatListViewModelFactory;

	public ApplicationEntryPoint(
		ICredentialStore credentialStore,
		IPickLoginScreenViewModelFactory pickLoginScreenViewModelFactory,
		IChatListViewModelFactory chatListViewModelFactory)
	{
		_credentialStore = credentialStore;
		_pickLoginScreenViewModelFactory = pickLoginScreenViewModelFactory;
		_chatListViewModelFactory = chatListViewModelFactory;
	}

	public async Task<IViewModel> GetEntryVmAsync(CancellationToken token)
	{
		var credentials = await _credentialStore.GetStoredCredentialsAsync(token);
		if (credentials.Any())
			return _chatListViewModelFactory
				.Create(
					await Task.WhenAll(credentials
						.Select(x => _credentialStore.GetCredentialAsync(x, token))
						.Select(async (x) => await (await x).CreateClientAsync(token))
						.ToArray())
				);
		else
			return _pickLoginScreenViewModelFactory.Create();

	}

}
