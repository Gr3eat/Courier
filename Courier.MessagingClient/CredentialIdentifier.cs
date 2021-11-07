namespace Courier.MessagingClient;

public struct CredentialIdentifier
{
	internal CredentialIdentifier(string platform, string identifier)
	{
		Platform = platform;
		Identifier = identifier;
	}

	public string Platform { get; }
	public string Identifier { get; }
}
