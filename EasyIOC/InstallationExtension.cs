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
			var assemblies = GetTransitivelyDependantAssemblies(installingAssembly)
				.Distinct().ToArray();
			var installers = assemblies
				.SelectMany(x => x.ExportedTypes)
				.Where(typeof(IInstaller).IsAssignableFrom)
				.Where(x => x.IsClass)
				.ToArray();
			foreach (var installer in installers.Select(Activator.CreateInstance).Cast<IInstaller>())
				installer.Install(collection);
			//foreach(var assembly in assemblies)
			//	if(assembly.GetCustomAttribute<InstallAllWithEasyIOCAttribute>() != null)
			//		foreach(var type in assembly.GetTypes())
			return collection;
		}


		private static IEnumerable<Assembly> GetTransitivelyDependantAssemblies(Assembly assembly, HashSet<Assembly>? addedAssemblies = null)
		{
			if (addedAssemblies is null || !addedAssemblies.Contains(assembly))
			{
				addedAssemblies ??= new HashSet<Assembly>();
				yield return assembly;
				addedAssemblies.Add(assembly);
				foreach (var a in assembly.GetReferencedAssemblies())
					if (!a.Name.StartsWith("System") && !a.Name.StartsWith("Microsoft"))
						foreach (var ass in GetTransitivelyDependantAssemblies(Assembly.Load(a), addedAssemblies))
							yield return ass;
			}
		}
	}
}
