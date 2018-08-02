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
		}

		private Model.Encounter _encounter = new Model.Encounter();

		public Model.Encounter Encounter
		{
			get { return _encounter; }
			set
			{
				_encounter = value;
				NotifyPropertyChanged("Encounter");
			}
		}

		private Model.ActorLibrary _actorLibrary = new Model.ActorLibrary();

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

		private void AddActorToEncounter(object actor)
		{
			Encounter.AddActor((Model.Actor)actor);
		}
		
	}
}
