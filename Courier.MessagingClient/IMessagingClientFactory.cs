namespace Courier.MessagingClient;

public interface IMessagingClientFactory
{
	Task<IMessagingClient> CreateAsync(ICredential credential, CancellationToken token);
}
