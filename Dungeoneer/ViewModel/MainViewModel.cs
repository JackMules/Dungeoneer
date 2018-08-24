using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeoneer.ViewModel
{
	class MainViewModel : BaseViewModel
	{
		public MainViewModel()
		{
			_actorLibrary = new Model.ActorLibrary();
			_encounter = new EncounterViewModel();

			_addActor = new Command(AddActorToEncounter);
			_saveActorLibrary = new Command(ExecuteSaveActorLibrary);
			_exit = new Command(ExecuteExit);
			_createPlayerActor = new Command(ExecuteCreatePlayerActor);
			_createNonPlayerActor = new Command(ExecuteCreateNonPlayerActor);
			_createCreature = new Command(ExecuteCreateCreature);

			ActorLibrary.LoadValues();
			CreateTestData();
		}

		private Model.ActorLibrary _actorLibrary;
		private EncounterViewModel _encounter;
		private Command _addActor;
		private Command _saveActorLibrary;
		private Command _exit;
		private Command _createPlayerActor;
		private Command _createNonPlayerActor;
		private Command _createCreature;

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

		public Command CreatePlayerActor
		{
			get { return _createPlayerActor; }
		}

		private void ExecuteCreatePlayerActor()
		{
			CreateActorWindowViewModel createCharWindowViewModel = new CreateActorWindowViewModel();
			Model.PlayerActor playerActor = createCharWindowViewModel.GetPlayerActor();
			if (playerActor != null)
			{
				ActorLibrary.Characters.Add(playerActor);
			}
		}

		public Command CreateNonPlayerActor
		{
			get { return _createNonPlayerActor; }
		}

		private void ExecuteCreateNonPlayerActor()
		{
			CreateActorWindowViewModel createActorWindowViewModel = new CreateActorWindowViewModel();
			Model.NonPlayerActor nonPlayerActor = createActorWindowViewModel.GetNonPlayerActor();
			if (nonPlayerActor != null)
			{
				ActorLibrary.Enemies.Add(nonPlayerActor);
			}
		}

		public Command CreateCreature
		{
			get { return _createCreature; }
		}

		private void ExecuteCreateCreature()
		{
			Model.Creature creature = null;
			bool askForInput = true;
			string feedback = null;

			if (creature != null)
			{
				ActorLibrary.Enemies.Add(creature);
			}
		}

		private void CreateTestData()
		{
			try
			{
				Model.PlayerActor osprey = ActorLibrary.Characters.Single(i => i.ActorName == "Osprey");
				ActorInitiativeViewModel ospreyViewModel = ActorInitiativeViewModelFactory.GetActorViewModel(osprey);
				InitiativeValueViewModel ospreyInit = new InitiativeValueViewModel { InitiativeScore = "15", InitiativeAdjust = "0", InitiativeMod = "12", InitiativeRoll = "19" };
				InitiativeCardViewModel ospreyCard = new InitiativeCardViewModel { ActorViewModel = ospreyViewModel, InitiativeValueViewModel = ospreyInit };
				Encounter.AddInitiativeCard(ospreyCard);
			}
			catch
			{

			}

			Utility.FullyObservableCollection<Model.Damage> damages = new Utility.FullyObservableCollection<Model.Damage>();
			damages.Add(new Model.Damage { NumDice = 1, Die = Utility.Types.DieType.d6, Modifier = 3, Type = Utility.Types.DamageType.Bludgeoning });
			damages.Add(new Model.Damage { NumDice = 1, Die = Utility.Types.DieType.d4, Modifier = 2, Type = Utility.Types.DamageType.Acid });

			Model.Attack grellAttack = new Model.Attack
			{
				Name = "Slam",
				AttackMod = 5,
				AttackType = Utility.Types.AttackType.Primary,
				Damages = damages,
				CritMultiplier = 2,
				ThreatRangeMin = 19
			};

			AttackViewModel grellAttackViewModel = new AttackViewModel { Attack = grellAttack };
			Utility.FullyObservableCollection<AttackViewModel> grellAttacks = new Utility.FullyObservableCollection<AttackViewModel>();
			grellAttacks.Add(grellAttackViewModel);
			Model.Creature grell = new Model.Creature { DisplayName = "Grell 1", ActorName = "Grell", ArmourClass = 14, HitPoints = 24, Attacks = grellAttacks };
			ActorInitiativeViewModel grellViewModel = ActorInitiativeViewModelFactory.GetActorViewModel(grell);
			InitiativeValueViewModel grellInit = new InitiativeValueViewModel { InitiativeScore = "18", InitiativeAdjust = "0", InitiativeMod = "6", InitiativeRoll = "5" };
			InitiativeCardViewModel grellCard = new InitiativeCardViewModel { ActorViewModel = grellViewModel, InitiativeValueViewModel = grellInit };
			Encounter.AddInitiativeCard(grellCard);

			Model.Creature troll = new Model.Creature { DisplayName = "Troll 1", ActorName = "Troll", ArmourClass = 16, HitPoints = 52 };
			ActorInitiativeViewModel trollViewModel = ActorInitiativeViewModelFactory.GetActorViewModel(troll);
			InitiativeValueViewModel trollInit = new InitiativeValueViewModel { InitiativeScore = "15", InitiativeAdjust = "0", InitiativeMod = "3", InitiativeRoll = "9" };
			InitiativeCardViewModel trollCard = new InitiativeCardViewModel { ActorViewModel = trollViewModel, InitiativeValueViewModel = trollInit };
			Encounter.AddInitiativeCard(trollCard);

			Model.Creature troll2 = new Model.Creature { DisplayName = "Troll 2", ActorName = "Troll", ArmourClass = 16, HitPoints = 52 };
			ActorInitiativeViewModel troll2ViewModel = ActorInitiativeViewModelFactory.GetActorViewModel(troll2);
			InitiativeValueViewModel troll2Init = new InitiativeValueViewModel { InitiativeScore = "15", InitiativeAdjust = "0", InitiativeMod = "3", InitiativeRoll = "3" };
			InitiativeCardViewModel troll2Card = new InitiativeCardViewModel { ActorViewModel = troll2ViewModel, InitiativeValueViewModel = troll2Init };
			Encounter.AddInitiativeCard(troll2Card);
		}
	}
}
