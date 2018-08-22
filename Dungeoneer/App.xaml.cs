using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Dungeoneer
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			PresentationTraceSources.Refresh();
			PresentationTraceSources.DataBindingSource.Listeners.Add(new ConsoleTraceListener());
			PresentationTraceSources.DataBindingSource.Listeners.Add(new DebugTraceListener());
			PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Warning | SourceLevels.Error;
			base.OnStartup(e);
		}

		private bool mRequestClose = false;
		private MainWindow win = null;

		public void InitMainWindowCommandBinding(Window win)
		{
			win.CommandBindings.Add(new CommandBinding(AppCommand.Exit,
			(s, e) =>
			{
				e.Handled = true;

				((AppViewModel)win.DataContext).ExitExecuted();
			}));

			win.CommandBindings.Add(new CommandBinding(AppCommand.ShowDialog,
			(s, e) =>
			{
				((AppViewModel)win.DataContext).ShowUserNameDialog();

				e.Handled = true;
			}));

			win.CommandBindings.Add(new CommandBinding(AppCommand.NavigateBrowserTo,
			(s, e) =>
			{
				if (e != null)
					AppCommand.NavigateTo(e.Parameter);

				e.Handled = true;
			}));
		}

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			ViewModel.MainViewModel viewModel = new ViewModel.MainViewModel();  // Construct ViewModel and MainWindow
			MainWindow = new MainWindow();

			MainWindow.Closing += OnClosing;

			// When the ViewModel asks to be closed, it closes the window via attached behaviour.
			// We use this event to shut down the remaining parts of the application
			viewModel.RequestClose += delegate
			{
				// Make sure close down event is processed only once
				if (mRequestClose == false)
				{
					mRequestClose = true;

					// Save session data and close application
					OnClosed(MainWindow.DataContext as ViewModel.AppViewModel, MainWindow);
				}
			};

			MainWindow.DataContext = viewModel; // Attach ViewModel to DataContext of ViewModel
			InitMainWindowCommandBinding(MainWindow);  // Initialize RoutedCommand bindings
			MainWindow.Show(); // SHOW ME DA WINDOW!
		}

		private void App_SessionEnding(object sender, SessionEndingCancelEventArgs e)
		{
			e.Cancel = this.OnSessionEnding();
		}

		private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = this.OnSessionEnding();
		}

		private bool OnSessionEnding()
		{
			ViewModel.MainViewModel viewModel = MainWindow.DataContext as ViewModel.MainViewModel;

			if (viewModel != null)
			{
				if (viewModel.IsReadyToClose == false)
				{
					MessageBox.Show("Application is not ready to exit.\n" +
													"Hint: Check the checkbox in the MainWindow before exiting the application.",
													"Cannot exit application", MessageBoxButton.OK);

					return !viewModel.IsReadyToClose; // Cancel close down request if ViewModel is not ready, yet
				}

				viewModel.OnRequestClose(false);

				return !viewModel.IsReadyToClose; // Cancel close down request if ViewModel is not ready, yet
			}

			return true;
		}

		private void OnClosed(ViewModel.MainViewModel appVM, Window win)
		{
			try
			{
				Console.WriteLine("Closing down application.");
			}
			catch (System.Exception exp)
			{
				MessageBox.Show(exp.ToString(), "Error in OnClosed method", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}


	public class DebugTraceListener : TraceListener
	{
		public override void Write(string message)
		{
		}

		public override void WriteLine(string message)
		{
			Debugger.Break();
		}
	}
}
