namespace Courier.MessagingClient;

public struct CredentialSource
{
	public string PlatformName { get; }

	public CredentialSource(string platformName)
	{
		PlatformName = platformName;
	}

	public override bool Equals(object? obj)
	{
		return obj is CredentialSource source && PlatformName == source.PlatformName;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(PlatformName);
	}

	public static bool operator ==(CredentialSource left, CredentialSource right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(CredentialSource left, CredentialSource right)
	{
		return !(left == right);
	}
}
