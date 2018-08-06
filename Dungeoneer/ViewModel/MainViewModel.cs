using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	class MainViewModel : BaseViewModel
	{
		public MainViewModel()
		{
			_addActorCommand = new Command(AddActorToEncounter);
			_actorLibrary = new Model.ActorLibrary();
			_encounter = new Model.Encounter();

			CreateTestData();
		}

		private Model.ActorLibrary _actorLibrary;
		private Model.Encounter _encounter;

		public Model.Encounter Encounter
		{
			get { return _encounter; }
			set
			{
				_encounter = value;
				NotifyPropertyChanged("Encounter");
			}
		}

		public Model.ActorLibrary ActorLibrary
		{
			get { return _actorLibrary; }
			set
			{
				_actorLibrary = value;
				NotifyPropertyChanged("ActorLibrary");
			}
		}

		private Command _addActorCommand;

		public Command AddActorCommand
		{
			get { return _addActorCommand; }
		}

		private void AddActorToEncounter(object actorObj)
		{
			if (actorObj is Model.Actor)
			{
				Model.Actor actor = (Model.Actor)actorObj;
				string defaultActorName = actor.ActorName + " " + (Encounter.GetNumberOfActorsWithName(actor.ActorName) + 1);

				View.InputDialog inputDialog = new View.InputDialog("Enter name", defaultActorName);
				if (inputDialog.ShowDialog() == true)
				{
					actor.DisplayName = inputDialog.Answer;
					Encounter.AddActor(actor);
				}
			}
		}
		
		private void CreateTestData()
		{
			Model.PlayerActor osprey = new Model.PlayerActor { DisplayName = "Osprey", ActorName = "Osprey" };
			Encounter.AddActor(osprey);

			Model.Creature grell = new Model.Creature { DisplayName = "Grell 1", ActorName = "Grell", ArmourClass = 14 };
			Encounter.AddActor(grell);

			Model.Creature troll = new Model.Creature { DisplayName = "Troll 1", ActorName = "Troll", ArmourClass = 16 };
			Encounter.AddActor(troll);
		}
	}
}
