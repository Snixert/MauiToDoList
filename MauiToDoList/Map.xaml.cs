

namespace MauiToDoList;

public partial class Map : ContentPage
{
	public Map()
	{
		InitializeComponent();

#if WINDOWS
            mapNotSupportedLabel.IsVisible = true;
#else
        var mapView = new Microsoft.Maui.Controls.Maps.Map
        {
            IsShowingUser = true,
            VerticalOptions = LayoutOptions.FillAndExpand
        };
        contentGrid.Children.Add(mapView);
        mapNotSupportedLabel.IsVisible = false;
#endif
    }


}