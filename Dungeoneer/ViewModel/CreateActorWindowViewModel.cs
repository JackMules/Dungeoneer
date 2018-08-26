using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class CreateActorWindowViewModel : BaseViewModel
	{
		public CreateActorWindowViewModel()
		{
			_actorName = "";
			_initiativeMod = "0";
			_type = "";
			_challengeRating = "1";
			_attacks = new Utility.FullyObservableCollection<AttackViewModel>();
			_addAttack = new Command(ExecuteAddAttack);
			_removeAttack = new Command(ExecuteRemoveAttack);
		}

		private string _actorName;
		private string _initiativeMod;
		private string _type;
		private string _challengeRating;
		private Utility.FullyObservableCollection<AttackViewModel> _attacks;
		private Command _addAttack;
		private Command _removeAttack;

		public int SelectedAttack { get; set; }

		public string ActorName
		{
			get { return _actorName; }
			set
			{
				_actorName = value;
				NotifyPropertyChanged("ActorName");
			}
		}

		public string InitiativeMod
		{
			get { return _initiativeMod; }
			set
			{
				_initiativeMod = value;
				NotifyPropertyChanged("InitiativeMod");
			}
		}

		public string Type
		{
			get { return _type; }
			set
			{
				_type = value;
				NotifyPropertyChanged("Type");
			}
		}

		public string ChallengeRating
		{
			get { return _challengeRating; }
			set
			{
				_challengeRating = value;
				NotifyPropertyChanged("ChallengeRating");
			}
		}

		public Utility.FullyObservableCollection<AttackViewModel> Attacks
		{
			get { return _attacks; }
			set
			{
				_attacks = value;
				NotifyPropertyChanged("Attacks");
			}
		}

		public Model.PlayerActor GetPlayerActor()
		{
			bool askForInput = true;
			string feedback = null;
			Model.PlayerActor playerActor = null;
			while (askForInput)
			{
				View.CreatePlayerActorWindow createActorWindow = new View.CreatePlayerActorWindow(feedback);
				createActorWindow.DataContext = this;
				if (createActorWindow.ShowDialog() == true)
				{
					try
					{
						playerActor = new Model.PlayerActor
						{
							ActorName = ActorName,
							InitiativeMod = Convert.ToInt32(InitiativeMod)
						};
						askForInput = false;
					}
					catch (FormatException)
					{
						feedback = "Invalid format";
					}
				}
				else
				{
					askForInput = false;
				}
			}

			return playerActor;
		}

		public Model.NonPlayerActor GetNonPlayerActor()
		{
			bool askForInput = true;
			string feedback = null;
			Model.NonPlayerActor nonPlayerActor = null;
			while (askForInput)
			{
				View.CreateNonPlayerActorWindow createActorWindow = new View.CreateNonPlayerActorWindow(feedback);
				createActorWindow.DataContext = this;
				if (createActorWindow.ShowDialog() == true)
				{
					try
					{
						nonPlayerActor = new Model.NonPlayerActor
						{
							ActorName = ActorName,
							InitiativeMod = Convert.ToInt32(InitiativeMod),
							Type = Type,
							ChallengeRating = Convert.ToInt32(ChallengeRating),
							Attacks = Attacks,
						};
						askForInput = false;
					}
					catch (FormatException)
					{
						feedback = "Invalid format";
					}
				}
				else
				{
					askForInput = false;
				}
			}

			return nonPlayerActor;
		}

		public Model.Creature GetCreature()
		{
			bool askForInput = true;
			string feedback = null;
			Model.Creature creature = null;
			while (askForInput)
			{
				View.CreateCreatureWindow createCreatureWindow = new View.CreateCreatureWindow(feedback);
				createCreatureWindow.DataContext = this;
				createCreatureWindow.HDTypeComboBox.ItemsSource = Constants.DieTypes;
				createCreatureWindow.SizeComboBox.ItemsSource = Constants.Sizes;
				if (createCreatureWindow.ShowDialog() == true)
				{
					try
					{
						creature = new Model.Creature
						{
							ActorName = ActorName,
							InitiativeMod = Convert.ToInt32(InitiativeMod),
							Type = Type,
							ChallengeRating = Convert.ToInt32(ChallengeRating),
							Attacks = Attacks,
						};
						askForInput = false;
					}
					catch (FormatException)
					{
						feedback = "Invalid format";
					}
				}
				else
				{
					askForInput = false;
				}
			}

			return creature;
		}

		public Command AddAttack
		{
			get { return _addAttack; }
		}

		public Command RemoveAttack
		{
			get { return _removeAttack; }
		}

		private void ExecuteAddAttack()
		{
			AddAttackWindowViewModel addAttackWindowViewModel = new AddAttackWindowViewModel();
			Model.Attack attack = addAttackWindowViewModel.GetAttack();
			if (attack != null)
			{
				AttackViewModel attackViewModel = new AttackViewModel { Attack = attack };
				Attacks.Add(attackViewModel);
			}
		}

		private void ExecuteRemoveAttack()
		{
			Attacks.RemoveAt(SelectedAttack);
		}
	}
}
