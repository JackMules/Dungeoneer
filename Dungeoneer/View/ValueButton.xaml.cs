using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dungeoneer.View
{
	/// <summary>
	/// Interaction logic for ValueButton.xaml
	/// </summary>
	public partial class ValueButton : UserControl
	{
		public ValueButton()
		{
			InitializeComponent();
		}

		public Binding ValueBinding { get; set; }
		public Binding CommandBinding { get; set; }
		
		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set => SetValue(TitleProperty, value);
		}

		public static readonly DependencyProperty TitleProperty =
			DependencyProperty.Register("ValueButtonTitle", typeof(string),
			typeof(ValueButton), new PropertyMetadata(""));

		public Orientation PanelOrientation
		{
			get
			{
				Orientation? o = GetValue(PanelOrientationProperty) as Orientation?;
				if (o.HasValue)
				{
					return o.Value;
				}
				else
				{
					return Orientation.Vertical;
				}
			}
			set => SetValue(PanelOrientationProperty, value);
		}

		public static readonly DependencyProperty PanelOrientationProperty =
				DependencyProperty.Register("ValueButtonOrientation", typeof(Orientation),
					typeof(ValueButton), new PropertyMetadata(null));

		private void GridLoaded(object sender, RoutedEventArgs e)
		{
			titleLabel.SetValue(Label.ContentProperty, Title);
			valueLabel.SetBinding(Label.ContentProperty, ValueBinding);
			button.SetBinding(Button.CommandProperty, CommandBinding);
			stackPanel.SetValue(StackPanel.OrientationProperty, PanelOrientation);
		}
	}
}

