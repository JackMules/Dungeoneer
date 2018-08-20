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
	/// Interaction logic for DamageDialog.xaml
	/// </summary>
	public partial class DamageDialog : Window
	{
		public DamageDialog(string feedback = null)
		{
			InitializeComponent();
			comboDamageType.ItemsSource = Utility.Methods.GetDamageTypeStringList();
			comboDamageType.SelectedIndex = 0;
		}

		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		public string Damage
		{
			get { return txtDamage.Text; }
		}

		public string DamageType
		{
			get { return comboDamageType.SelectedItem.ToString(); }
		}
	}
}
