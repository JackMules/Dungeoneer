using System.Windows;

namespace Dungeoneer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			Closing += MainWindow_Closing;
    }

		void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			App.Current.Shutdown();
		}
	}
}
