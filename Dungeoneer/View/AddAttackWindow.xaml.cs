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
	/// Interaction logic for AddAttackWindow.xaml
	/// </summary>
	public partial class AddAttackWindow : Window
	{
		public Model.Attack Attack
		{
			get
			{
				return Attack;
			}
			set
			{
				Attack = value;
			}
		}

		public AddAttackWindow()
		{
			InitializeComponent();
		}
	}
}
