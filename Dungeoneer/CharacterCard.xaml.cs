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
	/// Interaction logic for CharacterCard.xaml
	/// </summary>
	public partial class CharacterCard : UserControl
	{
		public CharacterCard()
		{
			InitializeComponent();
		}

		public string CharacterName
		{
			get { return (string)GetValue(CharacterNameProperty);	}
			set { SetValue(CharacterNameProperty, value); }
		}

		public static readonly DependencyProperty CharacterNameProperty = 
			DependencyProperty.Register("CharacterName", typeof(string),
			typeof(CharacterCard), new PropertyMetadata(""));

		public NamedValue InitiativeMod
		{
			get { return (NamedValue)GetValue(InitiativeModProperty); }
			set { SetValue(InitiativeModProperty, value); }
		}

		public static readonly DependencyProperty InitiativeModProperty =
				DependencyProperty.Register("InitiativeMod", typeof(NamedValue),
					typeof(CharacterCard), new PropertyMetadata(null));

	}
}
