using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyIOC
{
	public static class InstallationExtension
	{
		public static IServiceCollection WithEasyIoc(this IServiceCollection collection, Assembly installingAssembly)
		{
			var installers = GetTransitivelyDependantAssemblies(installingAssembly)
				.Distinct()
				.SelectMany(x => x.GetExportedTypes())
				.Where(x => !x.IsAbstract && x.GetInterfaces().Any(typeof(IInstaller).IsAssignableFrom))
				.Select(Activator.CreateInstance)
				.Cast<IInstaller>();
			foreach (var installer in installers)
				installer.Install(collection);
			return collection;
		}


		private static IEnumerable<Assembly> GetTransitivelyDependantAssemblies(Assembly assembly)
		{
			yield return assembly;
			foreach (var a in assembly.GetReferencedAssemblies())
				foreach (var ass in GetTransitivelyDependantAssemblies(assembly))
					yield return ass;
		}
	}
}
