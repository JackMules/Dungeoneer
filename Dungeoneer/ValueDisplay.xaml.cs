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

namespace Dungeoneer
{
	/// <summary>
	/// Interaction logic for ValueDisplay.xaml
	/// </summary>
	public partial class ValueDisplay : UserControl
	{
		public Binding ValueBinding { get; set; }

		public ValueDisplay()
		{
			InitializeComponent();
		}

		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

		public static readonly DependencyProperty TitleProperty =
			DependencyProperty.Register("Title", typeof(string),
			typeof(CharacterCard), new PropertyMetadata(""));

		public string Value
		{
			get { return (string)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		public static readonly DependencyProperty ValueProperty =
				DependencyProperty.Register("Value", typeof(object),
					typeof(CharacterCard), new PropertyMetadata(""));

		private void GridLoaded(object sender, RoutedEventArgs e)
		{
			valueLabel.SetBinding(Label.ContentProperty, ValueBinding);
		}
	}
}
