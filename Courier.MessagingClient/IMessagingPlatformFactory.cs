namespace Courier.MessagingClient;

public interface IMessagingPlatformFactory
{
	CredentialSource ServicedPlatformId { get; }
	Task<ICredential> CreateCredentialAsync(string credentialIdentifier, Func<string, CancellationToken, Task<string>> credentialReadCallback, CancellationToken token);

	
}
