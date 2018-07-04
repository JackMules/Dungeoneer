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
	/// Interaction logic for NamedValueDisplay.xaml
	/// </summary>
	public partial class NamedValueDisplay : UserControl
	{
		public NamedValueDisplay()
		{
			InitializeComponent();
		}

		public string Label
		{
			get { return (string)GetValue(LabelProperty); }
			set { SetValue(LabelProperty, value); }
		}

		public static readonly DependencyProperty LabelProperty =
			DependencyProperty.Register("Label", typeof(string),
			typeof(CharacterCard), new PropertyMetadata(""));

		public string Value
		{
			get { return (string)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		public static readonly DependencyProperty ValueProperty =
				DependencyProperty.Register("Value", typeof(object),
					typeof(CharacterCard), new PropertyMetadata(""));
	}
}
