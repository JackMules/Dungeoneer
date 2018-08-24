using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;

namespace Dungeoneer.ViewModel
{
	public class NonPlayerActorInitiativeViewModel : ActorInitiativeViewModel
	{
		public NonPlayerActorInitiativeViewModel()
		{
			_actor = new Model.NonPlayerActor();
			_attacksWindow = new View.AttacksWindow();
			_attacksWindow.DataContext = Attacks;
			_showAttacksWindow = new Command(ExecuteShowAttacksWindow);
			_hideAttacksWindow = new Command(ExecuteHideAttacksWindow);
		}

		private View.AttacksWindow _attacksWindow;
		private Command _showAttacksWindow;
		private Command _hideAttacksWindow;

		public new Model.NonPlayerActor Actor
		{
			get { return _actor as Model.NonPlayerActor; }
			set
			{
				_actor = value;
				NotifyPropertyChanged("Actor");
			}
		}

		public float ChallengeRating
		{
			get { return Actor.ChallengeRating; }
			set
			{
				Actor.ChallengeRating = value;
				NotifyPropertyChanged("ChallengeRating");
			}
		}

		public Utility.FullyObservableCollection<AttackViewModel> Attacks
		{
			get { return Actor.Attacks; }
			set
			{
				Actor.Attacks = value;
				NotifyPropertyChanged("Attacks");
			}
		}

		public Command ShowAttacksWindow
		{
			get { return _showAttacksWindow; }
		}

		private void ExecuteShowAttacksWindow()
		{
			_attacksWindow.Visibility = Visibility.Visible;
		}

		public Command HideAttacksWindow
		{
			get { return _hideAttacksWindow; }
		}

		private void ExecuteHideAttacksWindow()
		{
			_attacksWindow.Visibility = Visibility.Collapsed;
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			Model.NonPlayerActor nonPlayerActor = new Model.NonPlayerActor();
			nonPlayerActor.ReadXML(xmlNode);
			Actor = nonPlayerActor;
		}
	}
}
