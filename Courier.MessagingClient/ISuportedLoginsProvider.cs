using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.MessagingClient;

public interface ISuportedLoginsProvider
{
	IEnumerable<CredentialSource> SuportedCredentialSources { get; }
}

internal class SuportedLoginsProvider : ISuportedLoginsProvider
{
	private readonly IMessagingPlatformFactory[] _messagingClientFactories;

	public SuportedLoginsProvider(IEnumerable<IMessagingPlatformFactory> messagingClientFactories)
	{
		_messagingClientFactories = messagingClientFactories.ToArray();
	}

	public IEnumerable<CredentialSource> SuportedCredentialSources => _messagingClientFactories.Select(x => x.ServicedPlatformId);
}
