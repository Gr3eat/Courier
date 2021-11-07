using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.MessagingClient;

public interface ICredentialStore
{
	Task<ICredential> GetCredentialAsync(CredentialIdentifier id, CancellationToken token);
	IAsyncEnumerable<CredentialIdentifier> GetStoredCredentialsAsync(CancellationToken token);

}
