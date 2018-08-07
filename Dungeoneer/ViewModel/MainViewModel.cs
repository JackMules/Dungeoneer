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
			_encounter = new EncounterViewModel();

			CreateTestData();
		}

		private Model.ActorLibrary _actorLibrary;
		private EncounterViewModel _encounter;

		public EncounterViewModel Encounter
		{
			get { return _encounter; }
			set
			{
				_encounter = value;
				NotifyPropertyChanged("EncounterViewModel");
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
				if (actorObj is Model.PlayerActor)
				{
					Encounter.AddActor(actorObj as Model.PlayerActor);
				}
				else
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
		}
		
		private void CreateTestData()
		{
			Model.PlayerActor osprey = new Model.PlayerActor { DisplayName = "Osprey", ActorName = "Osprey" };
			ActorViewModel ospreyViewModel = ActorViewModelFactory.GetActorViewModel(osprey);
			InitiativeValueViewModel ospreyInit = new InitiativeValueViewModel { InitiativeScore = "15", InitiativeMod = "12", InitiativeRoll = "19" };
			InitiativeCardViewModel ospreyCard = new InitiativeCardViewModel { ActorViewModel = ospreyViewModel, InitiativeValueViewModel = ospreyInit };
			Encounter.AddInitiativeCard(ospreyCard);

			Model.Creature grell = new Model.Creature { DisplayName = "Grell 1", ActorName = "Grell", ArmourClass = 14 };
			ActorViewModel grellViewModel = ActorViewModelFactory.GetActorViewModel(grell);
			InitiativeValueViewModel grellInit = new InitiativeValueViewModel { InitiativeScore = "18", InitiativeMod = "6", InitiativeRoll = "5" };
			InitiativeCardViewModel grellCard = new InitiativeCardViewModel { ActorViewModel = grellViewModel, InitiativeValueViewModel = grellInit };
			Encounter.AddInitiativeCard(grellCard);

			Model.Creature troll = new Model.Creature { DisplayName = "Troll 1", ActorName = "Troll", ArmourClass = 16 };
			ActorViewModel trollViewModel = ActorViewModelFactory.GetActorViewModel(troll);
			InitiativeValueViewModel trollInit = new InitiativeValueViewModel { InitiativeScore = "15", InitiativeMod = "3", InitiativeRoll = "9" };
			InitiativeCardViewModel trollCard = new InitiativeCardViewModel { ActorViewModel = trollViewModel, InitiativeValueViewModel = trollInit };
			Encounter.AddInitiativeCard(trollCard);

			Model.Creature troll2 = new Model.Creature { DisplayName = "Troll 2", ActorName = "Troll", ArmourClass = 16 };
			ActorViewModel troll2ViewModel = ActorViewModelFactory.GetActorViewModel(troll2);
			InitiativeValueViewModel troll2Init = new InitiativeValueViewModel { InitiativeScore = "15", InitiativeMod = "3", InitiativeRoll = "3" };
			InitiativeCardViewModel troll2Card = new InitiativeCardViewModel { ActorViewModel = troll2ViewModel, InitiativeValueViewModel = troll2Init };
			Encounter.AddInitiativeCard(troll2Card);
		}
	}
}
