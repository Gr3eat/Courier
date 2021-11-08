using Microsoft.Maui.Essentials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Courier.MessagingClient.Xamarin;

internal class MauiCredentialStore : ICredentialStore
{
	private readonly IMessagingPlatformFactory[] _platforms;

	public MauiCredentialStore(IEnumerable<IMessagingPlatformFactory> platforms)
	{
		_platforms = platforms.ToArray();
	}

	public Task<ICredential> GetCredentialAsync(CredentialIdentifier id, CancellationToken token)
	{
		var platform = _platforms.First(x => x.ServicedPlatformId == id.Platform);
		return platform.CreateCredentialAsync(id.Identifier, (name, t) => SecureStorage.GetAsync(name), token);

	}

	public async Task<IEnumerable<CredentialIdentifier>> GetStoredCredentialsAsync(CancellationToken token)
	{
		var path = Path.Combine(FileSystem.AppDataDirectory, "saved_credential_ids.json");
		if (File.Exists(path))
		{
			var status = await Permissions.RequestAsync<Permissions.StorageWrite>();
			var readStatus = await Permissions.RequestAsync<Permissions.StorageRead>();
			if (status is PermissionStatus.Granted && readStatus is PermissionStatus.Granted)
			{
				using var text = new FileStream(path, FileMode.OpenOrCreate);

				return await JsonSerializer.DeserializeAsyncEnumerable<CredentialIdentifier>(text, cancellationToken: token).Select(x => x!).ToArrayAsync(token);
			}
			else
				throw new MauiCredentialStoragePermissionDeniedException(path);
		}
		else
		{
			using var text = new FileStream(path, FileMode.OpenOrCreate);

			await JsonSerializer.SerializeAsync(text, Array.Empty<CredentialIdentifier>(), cancellationToken: token);
			return Array.Empty<CredentialIdentifier>();
			
		}
	}

}
