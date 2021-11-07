using Microsoft.Maui.Controls;
using System;

namespace Courier.MVVM;

public interface IViewModel
{
	Page CreatePage();
}