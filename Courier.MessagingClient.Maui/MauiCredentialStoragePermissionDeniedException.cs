using System;
using System.Runtime.Serialization;

namespace Courier.MessagingClient.Xamarin;

[Serializable]
internal class MauiCredentialStoragePermissionDeniedException : Exception
{
	public MauiCredentialStoragePermissionDeniedException()
	{
	}

	public MauiCredentialStoragePermissionDeniedException(string path) : base($"Access to credential storage file: {path} was denied")
	{
	}

	public MauiCredentialStoragePermissionDeniedException(string message, Exception innerException) : base(message, innerException)
	{
	}

	protected MauiCredentialStoragePermissionDeniedException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
}