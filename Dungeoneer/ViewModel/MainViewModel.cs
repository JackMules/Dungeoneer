using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	class MainViewModel : ViewModel
	{
		public MainViewModel()
		{
			_encounter = new Model.Encounter();

			_actorLibrary = new Model.ActorLibrary();

			_addActorCommand = new Command(AddActorToEncounter);
		}

		private Model.Encounter _encounter;

		public Model.Encounter Encounter
		{
			get { return _encounter; }
			set { _encounter = value; }
		}

		private Model.ActorLibrary _actorLibrary;

		public Model.ActorLibrary ActorLibrary
		{
			get { return _actorLibrary; }
			set { _actorLibrary = value; }
		}

		private Command _addActorCommand;

		public Command AddActorCommand
		{
			get { return _addActorCommand; }
		}

		// If one of the PC checkboxes changes, send all currently checked PCs to Encounter. 

		// Each time an enemy add button is clicked, pass that enemy object to Encounter

		private void AddActorToEncounter(object actor)
		{
			Encounter.AddActor((Model.Actor)actor);
		}
		
	}
}
