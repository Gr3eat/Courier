using Microsoft.Maui.Controls;
using System;
using System.Reflection;

namespace Courier.MVVM;

public interface IViewModel
{
}


[AttributeUsage(AttributeTargets.Class)]
public class ViewAttribute : Attribute
{
	public Type PageType { get; }

	public ViewAttribute(Type pageType)
	{
		PageType = pageType;
	}
}

public static class ViewModelExtensions
{
	public static Page CreatePage(this IViewModel viewModel)
	{
		var attribute = viewModel.GetType().GetCustomAttribute<ViewAttribute>()!;
		var page = (Page)Activator.CreateInstance(attribute.PageType)!;
		page.BindingContext = viewModel;
		return page;
	}
}
