﻿using System.ComponentModel;

namespace Xamarin.Forms
{
	// TODO hartez 2018/05/31 11:49:49 Move the stuff in ItemsControl.cs to the appropriate files
	public interface IItemsLayout : INotifyPropertyChanged {}

	public enum ItemsLayoutOrientation
	{
		Vertical,
		Horizontal
	}

	public abstract class ItemsLayout : BindableObject, IItemsLayout
	{
		public ItemsLayoutOrientation Orientation { get; }

		protected ItemsLayout(ItemsLayoutOrientation orientation)
		{
			Orientation = orientation;
		}

		public static readonly BindableProperty SnapPointsAlignmentProperty =
			BindableProperty.Create(nameof(SnapPointsAlignment), typeof(SnapPointsAlignment), typeof(ItemsLayout), 
				SnapPointsAlignment.Start);

		public SnapPointsAlignment SnapPointsAlignment
		{
			get => (SnapPointsAlignment)GetValue(SnapPointsAlignmentProperty);
			set => SetValue(SnapPointsAlignmentProperty, value);
		}

		public static readonly BindableProperty SnapPointsTypeProperty =
			BindableProperty.Create(nameof(SnapPointsType), typeof(SnapPointsType), typeof(ItemsLayout), 
				SnapPointsType.None);

		public SnapPointsType SnapPointsType
		{
			get => (SnapPointsType)GetValue(SnapPointsTypeProperty);
			set => SetValue(SnapPointsTypeProperty, value);
		}
	}

	public class ListItemsLayout : ItemsLayout
	{
		// TODO hartez 2018/08/29 17:28:42 Consider changing this name to LinearItemsLayout; not everything using it is a list (e.g., Carousel)	
		public ListItemsLayout(ItemsLayoutOrientation orientation) : base(orientation)
		{
		}

		// TODO hartez 2018/05/31 15:56:23 Should these just be called Vertical and Horizontal (without List)?	
		public static readonly IItemsLayout VerticalList = new ListItemsLayout(ItemsLayoutOrientation.Vertical); 
		public static readonly IItemsLayout HorizontalList = new ListItemsLayout(ItemsLayoutOrientation.Horizontal);

		// TODO hartez 2018/08/29 20:31:54 Need something like these previous two, but as a carousel default	

		public override string ToString()
		{
			return Orientation == ItemsLayoutOrientation.Horizontal ? "Horizontal List" : "Vertical List";
		}
	}

	public class GridItemsLayout : ItemsLayout
	{
		public static readonly BindableProperty SpanProperty =
			BindableProperty.Create(nameof(Span), typeof(int), typeof(GridItemsLayout), 1);

		public int Span
		{
			get => (int)GetValue(SpanProperty);
			set => SetValue(SpanProperty, value);
		}

		public GridItemsLayout([Parameter("Span")] int span, [Parameter("Orientation")] ItemsLayoutOrientation orientation) :
			base(orientation)
		{
			Span = span;
		}

		public override string ToString()
		{
			var orientation = Orientation == ItemsLayoutOrientation.Horizontal ? "Horizontal Grid" : "Vertical Grid";
			
			return $"{orientation}, {nameof(Span)} {Span}";
		}
	}

	public enum SnapPointsAlignment
	{
		Start,
		Center,
		End
	}

	public enum SnapPointsType
	{
		None,
		Optional,
		Mandatory,
		OptionalSingle,
		MandatorySingle,
	}
}
