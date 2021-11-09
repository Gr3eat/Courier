using Microsoft.Maui.Controls;
using System;
using System.ComponentModel;
using System.Reflection;

namespace Courier.MVVM;

public interface IViewModel : INotifyPropertyChanged
{
	INavigation? Navigation { get; set; }
}


[AttributeUsage(AttributeTargets.Class)]
public class ViewAttribute : Attribute
{
	public Type PageType { get; }
	public bool IsNavigation { get; init; } = false;

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
		viewModel.Navigation = page.Navigation;
		if (attribute.IsNavigation)
			return new NavigationPage(page);
		return page;
	}
}
