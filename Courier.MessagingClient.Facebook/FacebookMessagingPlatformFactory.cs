using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.MessagingClient.Facebook;

internal class FacebookMessagingPlatformFactory : IMessagingPlatformFactory
{
	public CredentialSource ServicedPlatformId => new("Facebook");

	public Task<ICredential> CreateCredentialAsync(
		string credentialIdentifier,
		Func<string, CancellationToken, Task<string>> credentialReadCallback,
		CancellationToken token)
	{
		throw new NotImplementedException();
	}
}
