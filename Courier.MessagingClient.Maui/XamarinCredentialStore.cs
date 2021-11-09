using Microsoft.Maui.Essentials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Courier.MessagingClient.Xamarin;

internal class MauiCredentialStore : ICredentialStore
{
	private const string _credentialStoreKey = "saved_credential_ids";
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
		var savedCredentialString = Preferences.Get(
			_credentialStoreKey,
			"[]");
		using var stream = new MemoryStream(Encoding.UTF8.GetBytes(savedCredentialString));
		return await JsonSerializer.DeserializeAsync<CredentialIdentifier[]>(stream, cancellationToken: token);

	}

	public async Task StoreCredentialAsync(CredentialIdentifier id, IDictionary<string, string> serialisedCredential, CancellationToken token)
	{
		var alreadyStoredCredentialsTask = GetStoredCredentialsAsync(token);

		await Task.WhenAll(serialisedCredential.Select(x => SecureStorage.SetAsync(x.Key, x.Value)));

		var credentials = await alreadyStoredCredentialsTask;
		using var stream = new MemoryStream();
		await JsonSerializer.SerializeAsync(stream, credentials.Append(id), cancellationToken: token);
		Preferences.Set(_credentialStoreKey, Encoding.UTF8.GetString(stream.GetBuffer()));
	}

	// TODO: switch to this implementation, once windows stops https://github.com/Gr3eat/Courier/issues/3
	private async Task<IEnumerable<CredentialIdentifier>> FutureGetStoredCredentials(CancellationToken token)
	{
		var path = Path.Combine(FileSystem.AppDataDirectory, "saved_credential_ids.json");
		if (File.Exists(path))
		{
			if (true)
			{
				var k = File.ReadAllText(path);
				using var text = new FileStream(path, FileMode.Open, FileAccess.Read);

				var t = await JsonSerializer.DeserializeAsync<CredentialIdentifier[]>(text, cancellationToken: token).ConfigureAwait(false)!;
				return t;
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
