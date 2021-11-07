using System;

namespace EasyIOC.CodeGen
{
	[AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false)]
	public class FactoryAttribute : Attribute { }
}