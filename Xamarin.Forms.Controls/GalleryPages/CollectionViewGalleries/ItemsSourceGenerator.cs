﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Controls.GalleryPages.CollectionViewGalleries
{
	[Preserve(AllMembers = true)]
	public class TestItem
	{
		public string Date { get; set; }
		public string Caption { get; set; }
		public string Image { get; set; }

		public override string ToString()
		{
			return $"{nameof(Date)}: {Date}";
		}
	}

	internal class ItemsSourceGenerator : ContentView
	{
		readonly ItemsView _cv;
		readonly Entry _entry;

		public ItemsSourceGenerator(ItemsView cv, int initialItems = 1000)
		{
			_cv = cv;

			var layout = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Fill
			};

			var button = new Button { Text = "Update" };
			var label = new Label { Text = "Item count:", VerticalTextAlignment = TextAlignment.Center };
			_entry = new Entry { Keyboard = Keyboard.Numeric, Text = initialItems.ToString(), WidthRequest = 200 };

			layout.Children.Add(label);
			layout.Children.Add(_entry);
			layout.Children.Add(button);

			button.Clicked += GenerateItems;

			Content = layout;

			IsClippedToBounds = true;
		}

		readonly string[] _images = 
		{
			"cover1.jpg", 
			"oasis.jpg",
			"photo.jpg",
			"Vegetables.jpg",
			"Fruits.jpg",
			"FlowerBuds.jpg",
			"Legumes.jpg"
		};

		public void GenerateItems()
		{
			if (int.TryParse(_entry.Text, out int count))
			{
				var items = new List<TestItem>();

				for (int n = 0; n < count; n++)
				{
					items.Add(new TestItem
					{
						Date = $"{DateTime.Now.AddDays(n).ToLongDateString()}", 
						Image = _images[n % _images.Length],
						Caption = $"{_images[n % _images.Length]}, {n}",
					});
				}

				_cv.ItemsSource = items;
			}
		}

		public void GenerateObservableCollection()
		{
			if (int.TryParse(_entry.Text, out int count))
			{
				var items = new List<TestItem>();

				for (int n = 0; n < count; n++)
				{
					items.Add(new TestItem
					{
						Date = $"{DateTime.Now.AddDays(n).ToLongDateString()}", 
						Image = _images[n % _images.Length],
						Caption = $"{_images[n % _images.Length]}, {n}",
					});
				}

				_cv.ItemsSource = new ObservableCollection<TestItem>(items);
			}
		}

		void GenerateItems(object sender, EventArgs e)
		{
			GenerateItems();
		}
	}
}