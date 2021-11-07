using System.Threading;
using System.Threading.Tasks;

namespace Courier.MVVM;

public interface IApplicationEntryPoint
{
	Task<IViewModel> GetEntryVmAsync(CancellationToken token);
}