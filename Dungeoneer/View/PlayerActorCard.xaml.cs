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
	/// Interaction logic for PlayerActorCard.xaml
	/// </summary>
	public partial class PlayerActorCard : UserControl
	{
		public PlayerActorCard()
		{
			InitializeComponent();
		}

		public string ActorName
		{
			get { return (string)GetValue(ActorNameProperty);	}
			set { SetValue(ActorNameProperty, value); }
		}

		public static readonly DependencyProperty ActorNameProperty = 
			DependencyProperty.Register("ActorName", typeof(string),
			typeof(PlayerActorCard), new PropertyMetadata(""));

		public Model.NamedValue<int> InitiativeMod
		{
			get { return (Model.NamedValue<int>)GetValue(InitiativeModProperty); }
			set { SetValue(InitiativeModProperty, value); }
		}

		public static readonly DependencyProperty InitiativeModProperty =
				DependencyProperty.Register("InitiativeMod", typeof(Model.NamedValue<int>),
					typeof(PlayerActorCard), new PropertyMetadata(null));

	}
}
