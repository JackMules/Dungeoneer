using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class NonPlayerActorInitiativeViewModel : ActorInitiativeViewModel
	{
		protected NonPlayerActorInitiativeViewModel()
		{
			InitCommands();
		}

		public NonPlayerActorInitiativeViewModel(Model.NonPlayerActor nonPlayerActor)
		{
			_actor = new Model.NonPlayerActor(nonPlayerActor);
			InitCommands();
		}

		public NonPlayerActorInitiativeViewModel(XmlNode nonPlayerActorXml)
		{
			_actor = new Model.NonPlayerActor(nonPlayerActorXml);
			InitCommands();
		}

		protected override void InitCommands()
		{
			base.InitCommands();
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

		public FullyObservableCollection<Model.AttackSet> AttackSets
		{
			get { return Actor.AttackSets; }
			set
			{
				Actor.AttackSets = value;
				NotifyPropertyChanged("Attacks");
			}
		}

		public Command ShowAttacksWindow
		{
			get { return _showAttacksWindow; }
		}

		private void ExecuteShowAttacksWindow()
		{
			_attacksWindow = new View.AttacksWindow();
			_attacksWindow.DataContext = this;
			_attacksWindow.Show();
		}

		public Command HideAttacksWindow
		{
			get { return _hideAttacksWindow; }
		}

		private void ExecuteHideAttacksWindow()
		{
			_attacksWindow.Close();
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("NonPlayerActorInitiativeViewModel");
		}

		public override void WriteActorXML(XmlWriter xmlWriter)
		{
			Actor.WriteXML(xmlWriter);
		}

		public override void ReadActorXML(XmlNode xmlNode)
		{
			Actor = new Model.NonPlayerActor(xmlNode);
		}
	}
}
