using MauiToDoList.ViewModels;

namespace MauiToDoList;

public partial class CreateTaskPage : ContentPage
{
	public CreateTaskPage()
	{
		InitializeComponent();
		BindingContext = new CreateTaskViewModel();
	}
}