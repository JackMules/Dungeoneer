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
	/// Interaction logic for InitiativeCard.xaml
	/// </summary>
	public partial class InitiativeCard : UserControl
	{
		public InitiativeCard() => InitializeComponent();

		public static readonly DependencyProperty ActorPlaceHolderProperty =
		DependencyProperty.Register("ActorPlaceHolder", typeof(object), typeof(InitiativeCard), new PropertyMetadata(null));

		public object ActorPlaceHolder
		{
			get { return GetValue(ActorPlaceHolderProperty); }
			set { SetValue(ActorPlaceHolderProperty, value); }
		}
	}
}
