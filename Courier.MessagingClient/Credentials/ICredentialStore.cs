namespace Courier.MessagingClient;

public interface ICredentialStore
{
	Task<ICredential> GetCredentialAsync(CredentialIdentifier id, CancellationToken token);
	Task<IEnumerable<CredentialIdentifier>> GetStoredCredentialsAsync(CancellationToken token);
}
