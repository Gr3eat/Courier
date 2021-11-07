using Microsoft.Extensions.DependencyInjection;

namespace EasyIOC
{
	public interface IInstaller
	{
		void Install(IServiceCollection container);
	}
}
