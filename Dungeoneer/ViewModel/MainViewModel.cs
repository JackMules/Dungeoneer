using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Dungeoneer.Utility;
using System.Windows.Data;

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
			_deleteCard = new Command(ExecuteDeleteCard);
			_createPlayerActor = new Command(ExecuteCreatePlayerActor);
			_createCreature = new Command(ExecuteCreateCreature);

			SaveTimer = new System.Threading.Timer(new TimerCallback(DoChangeRefresh), null, Timeout.Infinite, Timeout.Infinite);
			//			CreateTestData();

			_enemyFilter = "";
			EnemiesCVS = new CollectionViewSource();
			EnemiesCVS.Source = ActorLibrary.Enemies;
			EnemiesCVS.Filter += ApplyFilter;
			EnemiesCVS.SortDescriptions.Add(new SortDescription("ActorName", ListSortDirection.Ascending));
			EnemiesCVS.IsLiveSortingRequested = true;
		}

		private System.Threading.Timer SaveTimer;
		private Model.ActorLibrary _actorLibrary;
		private EncounterViewModel _encounter;
		private Command _addActor;
		private Command _editActor;
		private Command _loadActorLibrary;
		private Command _saveActorLibrary;
		private Command _exit;
		private Command _createPlayerActor;
		private Command _createCreature;
		private Command _deleteCard;
		private string _enemyFilter;

		internal CollectionViewSource EnemiesCVS { get; set; }
		public ICollectionView EnemiesView
		{
			get { return EnemiesCVS.View; }
		}

		public string EnemyFilter
		{
			get { return _enemyFilter; }
			set
			{
				SetField(ref _enemyFilter, value);
				OnEnemyFilterChanged();
			}
		}

		private void OnEnemyFilterChanged()
		{
			EnemiesCVS.View.Refresh();
		}

		public void ApplyFilter(object sender, FilterEventArgs e)
		{
			Model.Creature enemy = (Model.Creature)e.Item;

			if (String.IsNullOrWhiteSpace(EnemyFilter) || EnemyFilter.Length == 0)
			{
				e.Accepted = true;
			}
			else
			{
				e.Accepted = enemy.ActorName.Contains(EnemyFilter, StringComparison.OrdinalIgnoreCase);
			}
		}

		public Command Exit
		{
			get { return _exit; }
		}

		private void ExecuteExit()
		{
			System.Windows.Application.Current.Shutdown();
		}
		
		public EncounterViewModel Encounter
		{
			get { return _encounter; }
			set
			{
				SetField(ref _encounter, value);
			}
		}

		public Model.ActorLibrary ActorLibrary
		{
			get { return _actorLibrary; }
			set
			{
				SetField(ref _actorLibrary, value);
			}
		}

		public Command DeleteCard
		{
			get { return _deleteCard; }
		}

		public void ExecuteDeleteCard(object initCardObj)
		{
			if (initCardObj is InitiativeCardViewModel)
			{
				Encounter.Delete(initCardObj as InitiativeCardViewModel);
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
					Model.PlayerActor playerActor = actorObj as Model.PlayerActor;
					Encounter.AddActor(playerActor, playerActor.ActorName);
				}
				else
				{
					Model.Actor actor = actorObj as Model.Actor;
					string defaultActorName = actor.ActorName + " " + (Encounter.GetNumberOfActorsWithName(actor.ActorName) + 1);
					Encounter.AddActor(actor, defaultActorName);
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
				CreateActorWindowViewModel createActorWindowViewModel = new CreateActorWindowViewModel();
				if (actorObj is Model.PlayerActor)
				{
					createActorWindowViewModel.LoadPlayerActor(actorObj as Model.PlayerActor);
					Model.PlayerActor playerActor = createActorWindowViewModel.GetPlayerActor();
					if (playerActor != null)
					{
						ActorLibrary.EditActor(actorObj as Model.PlayerActor, playerActor);
						Encounter.UpdateActor(actorObj as Model.PlayerActor);
					}
				}
				else if (actorObj is Model.Creature)
				{
					createActorWindowViewModel.LoadCreature(actorObj as Model.Creature);
					Model.Creature creature = createActorWindowViewModel.GetCreature();
					if (creature != null)
					{
						ActorLibrary.EditActor(actorObj as Model.Creature, creature);
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
				ActorLibrary.AddActor(playerActor);
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
				ActorLibrary.AddActor(creature);
			}
		}
		
		public double WindowWidth
		{
			get
			{
				return Properties.Settings.Default.WindowWidth;
			}
			set
			{
				if (Properties.Settings.Default.WindowWidth != value)
				{
					Properties.Settings.Default.WindowWidth = value;
					NotifyPropertyChanged("WindowWidth");
					RestartTimer();
				}
			}
		}

		public double WindowHeight
		{
			get
			{
				return Properties.Settings.Default.WindowHeight;
			}
			set
			{
				if (Properties.Settings.Default.WindowHeight != value)
				{
					Properties.Settings.Default.WindowHeight = value;
					NotifyPropertyChanged("WindowHeight");
					RestartTimer();
				}
			}
		}

		public double WindowTop
		{
			get
			{
				return Properties.Settings.Default.WindowTop;
			}
			set
			{
				if (Properties.Settings.Default.WindowTop != value)
				{
					Properties.Settings.Default.WindowTop = value;
					NotifyPropertyChanged("WindowTop");
					RestartTimer();
				}
			}
		}

		public double WindowLeft
		{
			get
			{
				return Properties.Settings.Default.WindowLeft;
			}
			set
			{
				if (Properties.Settings.Default.WindowLeft != value)
				{
					Properties.Settings.Default.WindowLeft = value;
					NotifyPropertyChanged("WindowLeft");
					RestartTimer();
				}
			}
		}

		public WindowState WindowState
		{
			get
			{
				return (WindowState)Enum.Parse(typeof(WindowState), Properties.Settings.Default.WindowState);
			}
			set
			{
				if (Properties.Settings.Default.WindowState != value.ToString())
				{
					Properties.Settings.Default.WindowState = value.ToString();
					Properties.Settings.Default.Save();
					NotifyPropertyChanged("WindowState");
				}
			}
		}

		void DoChangeRefresh(object state)
		{
			System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
			{
				Properties.Settings.Default.Save();
			}));
		}

		void RestartTimer()
		{
			SaveTimer.Change(200, Timeout.Infinite);
		}
	}
}
