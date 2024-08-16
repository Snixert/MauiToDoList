

namespace MauiToDoList;

public partial class Map : ContentPage
{
	public Map()
	{
		InitializeComponent();

#if WINDOWS
        var htmlSource = new HtmlWebViewSource
        {
            Html = @"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta name=""viewport"" content=""initial-scale=1.0, user-scalable=no"">
                    <meta charset=""utf-8"">
                    <style>
                        html, body, #map {
                            height: 100%;
                            margin: 0;
                            padding: 0;
                        }
                    </style>
                    <script src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyC0Fi-RVBnRiIWvEo7SAnp-92z_zYzAkJE""></script>
                    <script>
                        function initMap() {
                            var location = { lat: -34.397, lng: 150.644 };
                            var map = new google.maps.Map(document.getElementById('map'), {
                                center: location,
                                zoom: 8
                            });
                        }
                    </script>
                </head>
                <body onload=""initMap()"">
                    <div id=""map""></div>
                </body>
                </html>"
        };

        var webView = new WebView
        {
            Source = htmlSource,
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        contentGrid.Children.Add(webView);
        mapNotSupportedLabel.IsVisible = false;
#elif ANDROID
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