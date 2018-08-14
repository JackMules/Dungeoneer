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
	/// Interaction logic for InitiativeDialog.xaml
	/// </summary>
	public partial class InitiativeDialog : Window
	{
		public InitiativeDialog(string initScore, string initAdjust, string initMod, string initRoll, string feedback = null)
		{
			InitializeComponent();
			txtScore.Text = initScore;
			txtAdjust.Text = initAdjust;
			txtMod.Text = initMod;
			txtRoll.Text = initRoll;
			lblFeedback.Content = feedback;
		}

		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		public string InitScore
		{
			get { return txtScore.Text; }
		}

		public string InitAdjust
		{
			get { return txtAdjust.Text; }
		}

		public string InitMod
		{
			get { return txtMod.Text; }
		}

		public string InitRoll
		{
			get { return txtRoll.Text; }
		}
	}
}
