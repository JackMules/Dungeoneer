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
			_addActor = new Command(AddActorToEncounter);
			_saveActorLibrary = new Command(ExecuteSaveActorLibrary);
			_actorLibrary = new Model.ActorLibrary();
			_encounter = new EncounterViewModel();
			_exit = new Command(ExecuteExit);

			ActorLibrary.LoadValues();
			CreateTestData();
		}

		private Model.ActorLibrary _actorLibrary;
		private EncounterViewModel _encounter;
		private Command _addActor;
		private Command _saveActorLibrary;
		private Command _exit;

		public Command Exit
		{
			get { return _exit; }
		}

		private void ExecuteExit()
		{
			App.Current.Shutdown();
		}

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

		public Command AddActor
		{
			get { return _addActor; }
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

		public Command SaveActorLibrary
		{
			get { return _saveActorLibrary; }
		}

		private void ExecuteSaveActorLibrary()
		{
			ActorLibrary.WriteXML();
		}

		private void CreateTestData()
		{
			try
			{
				Model.PlayerActor osprey = ActorLibrary.Characters.Single(i => i.ActorName == "Osprey");
				ActorViewModel ospreyViewModel = ActorViewModelFactory.GetActorViewModel(osprey);
				InitiativeValueViewModel ospreyInit = new InitiativeValueViewModel { InitiativeScore = "15", InitiativeAdjust = "0", InitiativeMod = "12", InitiativeRoll = "19" };
				InitiativeCardViewModel ospreyCard = new InitiativeCardViewModel { ActorViewModel = ospreyViewModel, InitiativeValueViewModel = ospreyInit };
				Encounter.AddInitiativeCard(ospreyCard);
			}
			catch
			{

			}

			Model.Creature grell = new Model.Creature { DisplayName = "Grell 1", ActorName = "Grell", ArmourClass = 14, HitPoints = 24 };
			ActorViewModel grellViewModel = ActorViewModelFactory.GetActorViewModel(grell);
			InitiativeValueViewModel grellInit = new InitiativeValueViewModel { InitiativeScore = "18", InitiativeAdjust = "0", InitiativeMod = "6", InitiativeRoll = "5" };
			InitiativeCardViewModel grellCard = new InitiativeCardViewModel { ActorViewModel = grellViewModel, InitiativeValueViewModel = grellInit };
			Encounter.AddInitiativeCard(grellCard);

			Model.Creature troll = new Model.Creature { DisplayName = "Troll 1", ActorName = "Troll", ArmourClass = 16, HitPoints = 52 };
			ActorViewModel trollViewModel = ActorViewModelFactory.GetActorViewModel(troll);
			InitiativeValueViewModel trollInit = new InitiativeValueViewModel { InitiativeScore = "15", InitiativeAdjust = "0", InitiativeMod = "3", InitiativeRoll = "9" };
			InitiativeCardViewModel trollCard = new InitiativeCardViewModel { ActorViewModel = trollViewModel, InitiativeValueViewModel = trollInit };
			Encounter.AddInitiativeCard(trollCard);

			Model.Creature troll2 = new Model.Creature { DisplayName = "Troll 2", ActorName = "Troll", ArmourClass = 16, HitPoints = 52 };
			ActorViewModel troll2ViewModel = ActorViewModelFactory.GetActorViewModel(troll2);
			InitiativeValueViewModel troll2Init = new InitiativeValueViewModel { InitiativeScore = "15", InitiativeAdjust = "0", InitiativeMod = "3", InitiativeRoll = "3" };
			InitiativeCardViewModel troll2Card = new InitiativeCardViewModel { ActorViewModel = troll2ViewModel, InitiativeValueViewModel = troll2Init };
			Encounter.AddInitiativeCard(troll2Card);
		}
	}
}
