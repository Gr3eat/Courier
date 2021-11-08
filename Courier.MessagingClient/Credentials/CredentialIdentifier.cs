namespace Courier.MessagingClient;

public struct CredentialIdentifier
{
	public CredentialIdentifier(CredentialSource platform, string identifier)
	{
		Platform = platform;
		Identifier = identifier;
	}

	public CredentialSource Platform { get; }
	public string Identifier { get; }
}
