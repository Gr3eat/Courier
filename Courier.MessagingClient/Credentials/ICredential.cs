namespace Courier.MessagingClient;

public interface ICredential
{
	Task<IMessagingClient> CreateClientAsync(CancellationToken token);
}