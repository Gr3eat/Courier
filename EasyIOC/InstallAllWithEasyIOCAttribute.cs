using System;
using System.Collections.Generic;
using System.Text;

namespace EasyIOC
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
	public class InstallAllWithEasyIOCAttribute : Attribute
	{
	}
}
