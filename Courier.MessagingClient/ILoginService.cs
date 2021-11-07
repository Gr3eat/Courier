using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courier.MessagingClient;

public interface ILoginService
{
	Task<CredentialIdentifier> Login(string username, string password, string platform, string identifier, CancellationToken token);
}
