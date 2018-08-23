using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dungeoneer.ViewModel
{
	public class NonPlayerActorViewModel : ActorViewModel
	{
		public NonPlayerActorViewModel()
		{
			_actor = new Model.NonPlayerActor();
			_openAttacksWindow = new Command(ExecuteOpenAttacksWindow);
		}

		private View.AttacksWindow _attacksWindow;
		private Command _openAttacksWindow;

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

		public Command OpenAttacksWindow
		{
			get { return _openAttacksWindow; }
		}

		private void ExecuteOpenAttacksWindow()
		{
			if (_attacksWindow == null)
			{
				_attacksWindow = new View.AttacksWindow();
			}
			_attacksWindow.DataContext = Attacks;
			_attacksWindow.Show();
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			Model.NonPlayerActor nonPlayerActor = new Model.NonPlayerActor();
			nonPlayerActor.ReadXML(xmlNode);
			Actor = nonPlayerActor;
		}
	}
}
