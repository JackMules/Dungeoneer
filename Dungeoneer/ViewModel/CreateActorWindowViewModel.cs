using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
			_attacks = new FullyObservableCollection<AttackViewModel>();
			_addAttack = new Command(ExecuteAddAttack);
			_removeAttack = new Command(ExecuteRemoveAttack);
			_addWeapon = new Command(ExecuteAddWeapon);
			_removeWeapon = new Command(ExecuteRemoveWeapon);
			_addDamageReduction = new Command(ExecuteAddDamageReduction);
			_removeDamageReduction = new Command(ExecuteRemoveDamageReduction);
			_openImportWindow = new Command(ExecuteOpenImportWindow);
			_weapons = new ObservableCollection<Model.Weapon>();
			_damageReductions = new ObservableCollection<Model.DamageReduction>();
		}

		private string _actorName;
		private string _initiativeMod;
		private string _type;
		private string _challengeRating;
		private FullyObservableCollection<AttackViewModel> _attacks;
		private string _strength;
		private string _dexterity;
		private string _constitution;
		private string _intelligence;
		private string _wisdom;
		private string _charisma;

		private string _baseAttackBonus;
		private string _hitPoints;
		private string _hitDice;
		private int _selectedHitDie;

		private string _armourClass;
		private string _touchArmourClass;
		private string _flatFootedArmourClass;

		private string _speed;

		private string _fortitudeSave;
		private string _reflexSave;
		private string _willSave;

		private bool _powerAttack;

		private int _selectedSize;
		private ObservableCollection<Model.DamageReduction> _damageReductions;
		private ObservableCollection<Model.Weapon> _weapons;

		private Command _addAttack;
		private Command _removeAttack;
		private Command _addWeapon;
		private Command _removeWeapon;
		private Command _addDamageReduction;
		private Command _removeDamageReduction;
		private Command _openImportWindow;

		public int SelectedAttack { get; set; }
		public int SelectedWeapon { get; set; }
		public int SelectedDamageReduction { get; set; }

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

		public string Strength
		{
			get { return _strength; }
			set
			{
				_strength = value;
				NotifyPropertyChanged("Strength");
			}
		}

		public string Dexterity
		{
			get { return _dexterity; }
			set
			{
				_dexterity = value;
				NotifyPropertyChanged("Dexterity");
			}
		}

		public string Constitution
		{
			get { return _constitution; }
			set
			{
				_constitution = value;
				NotifyPropertyChanged("Constitution");
			}
		}

		public string Intelligence
		{
			get { return _intelligence; }
			set
			{
				_intelligence = value;
				NotifyPropertyChanged("Intelligence");
			}
		}

		public string Wisdom
		{
			get { return _wisdom; }
			set
			{
				_wisdom = value;
				NotifyPropertyChanged("Wisdom");
			}
		}

		public string Charisma
		{
			get { return _charisma; }
			set
			{
				_charisma = value;
				NotifyPropertyChanged("Charisma");
			}
		}

		public string BaseAttackBonus
		{
			get { return _baseAttackBonus; }
			set
			{
				_baseAttackBonus = value;
				NotifyPropertyChanged("BaseAttackBonus");
			}
		}

		public string HitPoints
		{
			get { return _hitPoints; }
			set
			{
				_hitPoints = value;
				NotifyPropertyChanged("HitPoints");
			}
		}

		public string HitDice
		{
			get { return _hitDice; }
			set
			{
				_hitDice = value;
				NotifyPropertyChanged("HitDice");
			}
		}

		public int SelectedHitDie
		{
			get { return _selectedHitDie; }
			set
			{
				_selectedHitDie = value;
				NotifyPropertyChanged("SelectedHitDie");
			}
		}

		public string ArmourClass
		{
			get { return _armourClass; }
			set
			{
				_armourClass = value;
				NotifyPropertyChanged("ArmourClass");
			}
		}

		public string TouchArmourClass
		{
			get { return _touchArmourClass; }
			set
			{
				_touchArmourClass = value;
				NotifyPropertyChanged("TouchArmourClass");
			}
		}

		public string FlatFootedArmourClass
		{
			get { return _flatFootedArmourClass; }
			set
			{
				_flatFootedArmourClass = value;
				NotifyPropertyChanged("FlatFootedArmourClass");
			}
		}

		public string Speed
		{
			get { return _speed; }
			set
			{
				_speed = value;
				NotifyPropertyChanged("Speed");
			}
		}

		public string FortitudeSave
		{
			get { return _fortitudeSave; }
			set
			{
				_fortitudeSave = value;
				NotifyPropertyChanged("FortitudeSave");
			}
		}

		public string ReflexSave
		{
			get { return _reflexSave; }
			set
			{
				_reflexSave = value;
				NotifyPropertyChanged("ReflexSave");
			}
		}

		public string WillSave
		{
			get { return _willSave; }
			set
			{
				_willSave = value;
				NotifyPropertyChanged("WillSave");
			}
		}

		public bool PowerAttack
		{
			get { return _powerAttack; }
			set
			{
				_powerAttack = value;
				NotifyPropertyChanged("PowerAttack");
			}
		}

		public FullyObservableCollection<AttackViewModel> Attacks
		{
			get { return _attacks; }
			set
			{
				_attacks = value;
				NotifyPropertyChanged("Attacks");
			}
		}

		public int SelectedSize
		{
			get { return _selectedSize; }
			set
			{
				_selectedSize = value;
				NotifyPropertyChanged("SelectedSize");
			}
		}

		public ObservableCollection<Model.DamageReduction> DamageReductions
		{
			get { return _damageReductions; }
			set
			{
				_damageReductions = value;
				NotifyPropertyChanged("DamageReductions");
			}
		}

		public ObservableCollection<Model.Weapon> Weapons
		{
			get { return _weapons; }
			set
			{
				_weapons = value;
				NotifyPropertyChanged("Weapons");
			}
		}

		public List<string> DieTypes
		{
			get { return Constants.DieTypeStrings; }
		}

		public List<string> Sizes
		{
			get { return Constants.SizeStrings; }
		}

		public void LoadPlayerActor(Model.PlayerActor playerActor)
		{
			ActorName = playerActor.ActorName;
			InitiativeMod = playerActor.InitiativeMod.ToString();
			Weapons = playerActor.Weapons;
		}

		public void LoadNonPlayerActor(Model.NonPlayerActor nonPlayerActor)
		{
			ActorName = nonPlayerActor.ActorName;
			InitiativeMod = nonPlayerActor.InitiativeMod.ToString();
			Type = nonPlayerActor.Type;
			ChallengeRating = nonPlayerActor.ChallengeRating.ToString();
			Attacks = nonPlayerActor.Attacks;
		}

		public void LoadCreature(Model.Creature creature)
		{
			LoadNonPlayerActor(creature);

			Strength = creature.Strength.ToString();
			Dexterity = creature.Dexterity.ToString();
			Constitution = creature.Constitution.ToString();
			Intelligence = creature.Intelligence.ToString();
			Wisdom = creature.Wisdom.ToString();
			Charisma = creature.Charisma.ToString();
			BaseAttackBonus = creature.BaseAttackBonus.ToString();
			HitPoints = creature.HitPoints.ToString();
			HitDice = creature.HitDice.ToString();
			SelectedHitDie = DieTypes.IndexOf(Methods.GetDieTypeString(creature.HitDieType));
			ArmourClass = creature.ArmourClass.ToString();
			TouchArmourClass = creature.TouchArmourClass.ToString();
			FlatFootedArmourClass = creature.FlatFootedArmourClass.ToString();
			Speed = creature.Speed.ToString();
			FortitudeSave = creature.FortitudeSave.ToString();
			ReflexSave = creature.ReflexSave.ToString();
			WillSave = creature.WillSave.ToString();
			PowerAttack = creature.PowerAttack;
			SelectedSize = Sizes.IndexOf(Methods.GetSizeString(creature.Size));
			DamageReductions = creature.DamageReductions;
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
							InitiativeMod = Convert.ToInt32(InitiativeMod),
							Weapons = Weapons,
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
				if (createCreatureWindow.ShowDialog() == true)
				{
					try
					{
						creature = new Model.Creature
						{
							ActorName = ActorName,
							InitiativeMod = Convert.ToInt32(InitiativeMod),
							Type = Type,
							ChallengeRating = Convert.ToSingle(ChallengeRating),
							Attacks = Attacks,
							Strength = Convert.ToInt32(Strength),
							Dexterity = Convert.ToInt32(Dexterity),
							Constitution = Convert.ToInt32(Constitution),
							Intelligence = Convert.ToInt32(Intelligence),
							Wisdom = Convert.ToInt32(Wisdom),
							Charisma = Convert.ToInt32(Charisma),
							BaseAttackBonus = Convert.ToInt32(BaseAttackBonus),
							HitPoints = Convert.ToInt32(HitPoints),
							HitDice = Convert.ToInt32(HitDice),
							HitDieType = Methods.GetDieTypeFromString(DieTypes.ElementAt(SelectedHitDie)),
							ArmourClass = Convert.ToInt32(ArmourClass),
							TouchArmourClass = Convert.ToInt32(TouchArmourClass),
							FlatFootedArmourClass = Convert.ToInt32(FlatFootedArmourClass),
							Speed = Convert.ToInt32(Speed),
							FortitudeSave = Convert.ToInt32(FortitudeSave),
							ReflexSave = Convert.ToInt32(ReflexSave),
							WillSave = Convert.ToInt32(WillSave),
							PowerAttack = PowerAttack,
							Size = Methods.GetSizeFromString(Sizes.ElementAt(SelectedSize)),
							DamageReductions = new ObservableCollection<Model.DamageReduction>(),
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

		public Command AddWeapon
		{
			get { return _addWeapon; }
		}

		public Command RemoveWeapon
		{
			get { return _removeWeapon; }
		}

		private void ExecuteAddWeapon()
		{
			AddWeaponWindowViewModel addWeaponWindowViewModel = new AddWeaponWindowViewModel();
			Model.Weapon weapon = addWeaponWindowViewModel.GetWeapon();
			if (weapon != null)
			{
				Weapons.Add(weapon);
			}
		}

		private void ExecuteRemoveWeapon()
		{
			Weapons.RemoveAt(SelectedWeapon);
		}

		public Command AddDamageReduction
		{
			get { return _addDamageReduction; }
		}

		public Command RemoveDamageReduction
		{
			get { return _removeDamageReduction; }
		}

		private void ExecuteAddDamageReduction()
		{
			/*
			AddDamageReductionWindowViewModel addDamageReductionWindowViewModel = new AddDamageReductionWindowViewModel();
			Model.DamageReduction dr = addDamageReductionWindowViewModel.GetDamageReduction();
			if (dr != null)
			{
				DamageReductions.Add(dr);
			}
			*/
		}

		private void ExecuteRemoveDamageReduction()
		{
			DamageReductions.RemoveAt(SelectedWeapon);
		}

		public Command Import
		{
			get { return _openImportWindow; }
		}

		private void ExecuteOpenImportWindow()
		{
			ImportStatBlockWindowViewModel importVM = new ImportStatBlockWindowViewModel();

			Model.Creature creature = importVM.GetCreature();
			if (creature != null)
			{
				LoadCreature(creature);
			}
		}
	}
}
