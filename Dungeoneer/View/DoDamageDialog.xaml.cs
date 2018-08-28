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
using Dungeoneer.Utility;

namespace Dungeoneer.View
{
	/// <summary>
	/// Interaction logic for DamageDialog.xaml
	/// </summary>
	public partial class DoDamageDialog : Window
	{
		public DoDamageDialog(string feedback = null)
		{
			InitializeComponent();
		}

		private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}
	}
}
