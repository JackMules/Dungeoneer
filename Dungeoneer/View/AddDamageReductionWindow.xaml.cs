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
	/// Interaction logic for AddDamageReductionWindow.xaml
	/// </summary>
	public partial class AddDamageReductionWindow : Window
	{
		public AddDamageReductionWindow(string feedback = null)
		{
			InitializeComponent();
			lblFeedback.Content = feedback;
		}

		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}
	}
}
