﻿namespace Xamarin.Forms.Controls.GalleryPages.CollectionViewGalleries
{
	internal class ExampleTemplates
	{
		public static DataTemplate PhotoTemplate()
		{
			return new DataTemplate(() =>
			{
				var templateLayout = new Grid
				{
					RowDefinitions = new RowDefinitionCollection { new RowDefinition(), new RowDefinition() },
					WidthRequest = 100,
					HeightRequest = 100
				};

				var image = new Image
				{
					HeightRequest = 100, WidthRequest = 100,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center
				};

				image.SetBinding(Image.SourceProperty, new Binding("Image"));

				var caption = new Label
				{
					HorizontalOptions = LayoutOptions.Fill,
					HorizontalTextAlignment = TextAlignment.Center
				};

				caption.SetBinding(Label.TextProperty, new Binding("Caption"));
				
				templateLayout.Children.Add(image);
				templateLayout.Children.Add(caption);

				Grid.SetRow(caption, 1);

				return templateLayout;
			});
		}

		public static DataTemplate SnapPointsTemplate()
		{
			return new DataTemplate(() =>
			{
				var templateLayout = new Grid
				{
					RowDefinitions = new RowDefinitionCollection { new RowDefinition(), new RowDefinition {Height = GridLength.Auto} },
					WidthRequest = 100,
					HeightRequest = 140
				};

				var image = new Image
				{
					Margin = new Thickness(5),
					HeightRequest = 100, 
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					Aspect = Aspect.AspectFit
				};

				image.SetBinding(Image.SourceProperty, new Binding("Image"));

				var caption = new Label
				{
					HorizontalOptions = LayoutOptions.Fill,
					HorizontalTextAlignment = TextAlignment.Center
				};

				caption.SetBinding(Label.TextProperty, new Binding("Caption"));
				
				templateLayout.Children.Add(image);
				templateLayout.Children.Add(caption);

				Grid.SetRow(caption, 1);

				return templateLayout;
			});
		}

		public static DataTemplate CarouselTemplate()
		{
			return new DataTemplate(() =>
			{
				var grid = new Grid
				{
					BackgroundColor = Color.LightBlue,
					RowDefinitions = new RowDefinitionCollection
					{
						new RowDefinition(),
						new RowDefinition { Height = GridLength.Auto }
					}
				};

				var image = new Image
				{
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					Aspect = Aspect.AspectFill
				};

				image.SetBinding(Image.SourceProperty, new Binding("Image"));

				var caption = new Label
				{
					BackgroundColor = Color.Gray,
					HorizontalOptions = LayoutOptions.Fill,
					HorizontalTextAlignment = TextAlignment.Center,
					Margin = new Thickness(5)
				};

				caption.SetBinding(Label.TextProperty, new Binding("Caption"));
				
				grid.Children.Add(image);
				grid.Children.Add(caption);

				Grid.SetRow(caption, 1);

				var frame = new Frame
				{
					Padding = new Thickness(5),
					Content = grid
				};

				return  frame;
			});
		}
	}
}