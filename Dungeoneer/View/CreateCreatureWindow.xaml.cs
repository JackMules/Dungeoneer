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
using System.Windows.Shapes;

namespace Dungeoneer.View
{
	/// <summary>
	/// Interaction logic for CreateNewActorWindow.xaml
	/// </summary>
	public partial class CreateCreatureWindow : Window
	{
		public Model.Creature Creature
		{
			get
			{
				return Creature;
			}
			set
			{
				Creature = value;
			}
		}
		public CreateCreatureWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// Add hit die values to combobox
			for (int hd = 1; hd <= 40; ++hd)
			{
				HDComboBox.Items.Add(hd);
			}

//			foreach (string dieStr in Constants.dieTypes)
//			{
//				HDTypeComboBox.Items.Add(dieStr);
//			}
		}
	}
}
