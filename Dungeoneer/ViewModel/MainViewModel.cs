using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	class MainViewModel : BaseViewModel
	{
		public MainViewModel()
		{
			_actorLibrary = new Model.ActorLibrary();
			_encounter = new EncounterViewModel();

			_addActor = new Command(ExecuteAddActorToEncounter);
			_editActor = new Command(ExecuteEditActor);
			_loadActorLibrary = new Command(ExecuteLoadActorLibrary);
			_saveActorLibrary = new Command(ExecuteSaveActorLibrary);
			_exit = new Command(ExecuteExit);
			_createPlayerActor = new Command(ExecuteCreatePlayerActor);
			_createNonPlayerActor = new Command(ExecuteCreateNonPlayerActor);
			_createCreature = new Command(ExecuteCreateCreature);

			CreateTestData();
		}

		private Model.ActorLibrary _actorLibrary;
		private EncounterViewModel _encounter;
		private Command _addActor;
		private Command _editActor;
		private Command _loadActorLibrary;
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

		private void ExecuteAddActorToEncounter(object actorObj)
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

		public Command EditActor
		{
			get { return _editActor; }
		}

		private void ExecuteEditActor(object actorObj)
		{
			if (actorObj is Model.Actor)
			{
				if (actorObj is Model.PlayerActor)
				{
					CreateActorWindowViewModel createActorWindowViewModel = new CreateActorWindowViewModel();
					createActorWindowViewModel.LoadPlayerActor(actorObj as Model.PlayerActor);
					Model.PlayerActor playerActor = createActorWindowViewModel.GetPlayerActor();
					if (playerActor != null)
					{
						ActorLibrary.EditActor(actorObj as Model.PlayerActor, playerActor);
					}
				}
				else if (actorObj is Model.NonPlayerActor)
				{
					if (actorObj is Model.Creature)
					{
						CreateActorWindowViewModel createActorWindowViewModel = new CreateActorWindowViewModel();
						createActorWindowViewModel.LoadCreature(actorObj as Model.Creature);
						Model.Creature creature = createActorWindowViewModel.GetCreature();
						if (creature != null)
						{
							ActorLibrary.EditActor(actorObj as Model.Creature, creature);
						}
					}
					else
					{
						CreateActorWindowViewModel createActorWindowViewModel = new CreateActorWindowViewModel();
						createActorWindowViewModel.LoadNonPlayerActor(actorObj as Model.NonPlayerActor);
						Model.NonPlayerActor nonPlayerActor = createActorWindowViewModel.GetNonPlayerActor();
						if (nonPlayerActor != null)
						{
							ActorLibrary.EditActor(actorObj as Model.Creature, nonPlayerActor);
						}
					}
				}
			}
		}

		public Command LoadActorLibrary
		{
			get { return _loadActorLibrary; }
		}

		private void ExecuteLoadActorLibrary()
		{
			ActorLibrary.ReadXML();
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
			CreateActorWindowViewModel createActorWindowViewModel = new CreateActorWindowViewModel();
			Model.PlayerActor playerActor = createActorWindowViewModel.GetPlayerActor();
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
			CreateActorWindowViewModel createActorWindowViewModel = new CreateActorWindowViewModel();
			Model.Creature creature = createActorWindowViewModel.GetCreature();
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

			FullyObservableCollection<Model.Damage> damages = new FullyObservableCollection<Model.Damage>();
			damages.Add(new Model.Damage { NumDice = 1, Die = Types.Die.d6, Modifier = 3, Type = Types.Damage.Bludgeoning });
			damages.Add(new Model.Damage { NumDice = 1, Die = Types.Die.d4, Modifier = 2, Type = Types.Damage.Acid });

			Model.Attack grellAttack = new Model.Attack
			{
				Name = "Slam",
				Modifier = 5,
				Type = Types.Attack.Primary,
				Damages = damages,
				CritMultiplier = 2,
				ThreatRangeMin = 19
			};

			AttackViewModel grellAttackViewModel = new AttackViewModel { Attack = grellAttack };
			FullyObservableCollection<AttackViewModel> grellAttacks = new FullyObservableCollection<AttackViewModel>();
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
