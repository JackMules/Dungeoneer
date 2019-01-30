﻿using System;
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
			_feats = new List<string>();
			_attackSets = new FullyObservableCollection<Model.AttackSet>();
			_addSpeed = new Command(ExecuteAddSpeed);
			_editSpeed = new Command(ExecuteEditSpeed);
			_removeSpeed = new Command(ExecuteRemoveSpeed);
			_addAttackSet = new Command(ExecuteAddAttackSet);
			_editAttackSet = new Command(ExecuteEditAttackSet);
			_removeAttackSet = new Command(ExecuteRemoveAttackSet);
			_addWeapon = new Command(ExecuteAddWeapon);
			_editWeapon = new Command(ExecuteEditWeapon);
			_removeWeapon = new Command(ExecuteRemoveWeapon);
			_addDamageReduction = new Command(ExecuteAddDamageReduction);
			_editDamageReduction = new Command(ExecuteEditDamageReduction);
			_removeDamageReduction = new Command(ExecuteRemoveDamageReduction);
			_editImmunities = new Command(ExecuteEditImmunities);
			_openImportWindow = new Command(ExecuteOpenImportWindow);
			_weapons = new ObservableCollection<Model.Weapon>();
			_damageReductions = new ObservableCollection<Model.DamageReduction>();

			SelectedCreatureType = CreatureTypes.IndexOf(Methods.GetCreatureTypeString(Types.Creature.Humanoid));
			SelectedSize = Sizes.IndexOf(Methods.GetSizeString(Types.Size.Medium));
		}

		private string _actorName;
		private string _initiativeMod;
		private string _challengeRating;
		private FullyObservableCollection<Model.AttackSet> _attackSets;
		private string _strength;
		private string _dexterity;
		private string _constitution;
		private string _intelligence;
		private string _wisdom;
		private string _charisma;

		private string _baseAttackBonus;
		private string _grappleModifier;
		private string _hitPoints;
		private string _hitDice;
		private int _selectedHitDie;

		private string _armorClass;
		private string _touchArmorClass;
		private string _flatFootedArmorClass;

		private string _space;
		private string _reach;

		private string _fortitudeSave;
		private string _reflexSave;
		private string _willSave;

		private string _spellResistance;
		private string _fastHealing;

		private string _specialAttacks;
		private string _specialQualities;

		private List<string> _feats;

		private int _selectedSize;
		private int _selectedCreatureType;
		private ObservableCollection<Model.DamageReduction> _damageReductions;
		private ObservableCollection<Model.Weapon> _weapons;
		private Model.DamageDescriptorSet _immunities;
		private Model.SpeedSet _speeds;

		private Command _addSpeed;
		private Command _editSpeed;
		private Command _removeSpeed;
		private Command _addAttackSet;
		private Command _editAttackSet;
		private Command _removeAttackSet;
		private Command _addWeapon;
		private Command _editWeapon;
		private Command _removeWeapon;
		private Command _addDamageReduction;
		private Command _editDamageReduction;
		private Command _removeDamageReduction;
		private Command _editImmunities;
		private Command _openImportWindow;

		public int SelectedSpeed { get; set; }
		public int SelectedAttackSet { get; set; }
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
		public string GrappleModifier
		{
			get { return _grappleModifier; }
			set
			{
				_grappleModifier = value;
				NotifyPropertyChanged("GrappleModifier");
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

		public string ArmorClass
		{
			get { return _armorClass; }
			set
			{
				_armorClass = value;
				NotifyPropertyChanged("ArmorClass");
			}
		}

		public string TouchArmorClass
		{
			get { return _touchArmorClass; }
			set
			{
				_touchArmorClass = value;
				NotifyPropertyChanged("TouchArmorClass");
			}
		}

		public string FlatFootedArmorClass
		{
			get { return _flatFootedArmorClass; }
			set
			{
				_flatFootedArmorClass = value;
				NotifyPropertyChanged("FlatFootedArmorClass");
			}
		}

		public Model.SpeedSet Speeds
		{
			get { return _speeds; }
			set
			{
				_speeds = value;
				NotifyPropertyChanged("Speeds");
			}
		}

		public string Space
		{
			get { return _space; }
			set
			{
				_space = value;
				NotifyPropertyChanged("Space");
			}
		}

		public string Reach
		{
			get { return _reach; }
			set
			{
				_reach = value;
				NotifyPropertyChanged("Reach");
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

		public List<string> Feats
		{
			get { return _feats; }
			set
			{
				_feats = value;
				NotifyPropertyChanged("Feats");
				NotifyPropertyChanged("FeatsText");
			}
		}

		public string FeatsText
		{
			get
			{
				string featsText = null;
				if (Feats.Count > 0)
				{
					featsText = Feats.Aggregate((i, j) => i + ", " + j);
				}
				return featsText;
			}
			set
			{
				string[] tokens = value.Split(',');
				List<string> strings = new List<string>();
				foreach (string token in tokens)
				{
					strings.Add(token.Trim());
				}
				Feats = strings;
				NotifyPropertyChanged("FeatsText");
			}
		}

		public FullyObservableCollection<Model.AttackSet> AttackSets
		{
			get { return _attackSets; }
			set
			{
				_attackSets = value;
				NotifyPropertyChanged("AttackSets");
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

		public Model.DamageDescriptorSet Immunities
		{
			get { return _immunities; }
			set
			{
				_immunities = value;
				NotifyPropertyChanged("Immunities");
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

		public string SpellResistance
		{
			get { return _spellResistance; }
			set
			{
				_spellResistance = value;
				NotifyPropertyChanged("SpellResistance");
			}
		}

		public string FastHealing
		{
			get { return _fastHealing; }
			set
			{
				_fastHealing = value;
				NotifyPropertyChanged("FastHealing");
			}
		}

		public string SpecialAttacks
		{
			get { return _specialAttacks; }
			set
			{
				_specialAttacks = value;
				NotifyPropertyChanged("SpecialAttacks");
			}
		}

		public string SpecialQualities
		{
			get { return _specialQualities; }
			set
			{
				_specialQualities = value;
				NotifyPropertyChanged("SpecialQualities");
			}
		}

		public int SelectedCreatureType
		{
			get { return _selectedCreatureType; }
			set
			{
				_selectedCreatureType = value;
				NotifyPropertyChanged("SelectedCreatureType");
			}
		}

		public List<string> CreatureTypes
		{
			get { return Constants.CreatureTypeStrings; }
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
			InitiativeMod = Methods.GetSignedNumberString(playerActor.InitiativeMod);
			Weapons = playerActor.Weapons;
		}
		
		public void LoadCreature(Model.Creature creature)
		{
			ActorName = creature.ActorName;
			InitiativeMod = Methods.GetSignedNumberString(creature.InitiativeMod);
			SelectedCreatureType = CreatureTypes.IndexOf(Methods.GetCreatureTypeString(creature.Type));
			ChallengeRating = creature.ChallengeRating.ToString();
			AttackSets = creature.AttackSets;
			Strength = creature.Strength.ToString();
			Dexterity = creature.Dexterity.ToString();
			Constitution = creature.Constitution.ToString();
			Intelligence = creature.Intelligence.ToString();
			Wisdom = creature.Wisdom.ToString();
			Charisma = creature.Charisma.ToString();
			BaseAttackBonus = Methods.GetSignedNumberString(creature.BaseAttackBonus);
			GrappleModifier = Methods.GetSignedNumberString(creature.GrappleModifier);
			HitPoints = creature.HitPoints.ToString();
			HitDice = creature.HitDice.ToString();
			SelectedHitDie = DieTypes.IndexOf(Methods.GetDieTypeString(creature.HitDieType));
			ArmorClass = creature.ArmorClass.ToString();
			TouchArmorClass = creature.TouchArmorClass.ToString();
			FlatFootedArmorClass = creature.FlatFootedArmorClass.ToString();
			Speeds = creature.Speed;
			Space = creature.Space.ToString();
			Reach = creature.Reach.ToString();
			FortitudeSave = Methods.GetSignedNumberString(creature.FortitudeSave);
			ReflexSave = Methods.GetSignedNumberString(creature.ReflexSave);
			WillSave = Methods.GetSignedNumberString(creature.WillSave);
			Feats = creature.Feats;
			SelectedSize = Sizes.IndexOf(Methods.GetSizeString(creature.Size));
			DamageReductions = creature.DamageReductions;
			Immunities = creature.Immunities;
			SpellResistance = creature.SpellResistance.ToString();
			FastHealing = creature.FastHealing.ToString();
			SpecialAttacks = creature.SpecialAttacks;
			SpecialQualities = creature.SpecialQualities;
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
						Model.ActorAttributes attributes = new Model.ActorAttributes
						{
							InitiativeMod = Convert.ToInt32(InitiativeMod),
						};
						playerActor = new Model.PlayerActor(attributes)
						{
							ActorName = ActorName,
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
						Model.CreatureAttributes creatureAttributes = new Model.CreatureAttributes
						{
							InitiativeMod = Convert.ToInt32(InitiativeMod),
							Type = Methods.GetCreatureTypeFromString(CreatureTypes.ElementAt(SelectedCreatureType)),
							ChallengeRating = Convert.ToSingle(ChallengeRating),
							AttackSets = AttackSets,
							Strength = Convert.ToInt32(Strength),
							Dexterity = Convert.ToInt32(Dexterity),
							Constitution = Convert.ToInt32(Constitution),
							Intelligence = Convert.ToInt32(Intelligence),
							Wisdom = Convert.ToInt32(Wisdom),
							Charisma = Convert.ToInt32(Charisma),
							BaseAttackBonus = Convert.ToInt32(BaseAttackBonus),
							GrappleModifier = Convert.ToInt32(GrappleModifier),
							HitPoints = Convert.ToInt32(HitPoints),
							HitDice = Convert.ToInt32(HitDice),
							HitDieType = Methods.GetDieTypeFromString(DieTypes.ElementAt(SelectedHitDie)),
							ArmorClass = Convert.ToInt32(ArmorClass),
							TouchArmorClass = Convert.ToInt32(TouchArmorClass),
							FlatFootedArmorClass = Convert.ToInt32(FlatFootedArmorClass),
							Speed = Speeds,
							Space = Convert.ToInt32(Space),
							Reach = Convert.ToInt32(Reach),
							FortitudeSave = Convert.ToInt32(FortitudeSave),
							ReflexSave = Convert.ToInt32(ReflexSave),
							WillSave = Convert.ToInt32(WillSave),
							Feats = Feats,
							Size = Methods.GetSizeFromString(Sizes.ElementAt(SelectedSize)),
							DamageReductions = DamageReductions,
							Immunities = Immunities,
							SpellResistance = Convert.ToInt32(SpellResistance),
							FastHealing = Convert.ToUInt32(FastHealing),
							SpecialAttacks = SpecialAttacks,
							SpecialQualities = SpecialQualities,
						};
						creature = new Model.Creature(creatureAttributes)
						{
							ActorName = ActorName,
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

		public Command AddSpeed
		{
			get { return _addSpeed; }
		}

		public Command EditSpeed
		{
			get { return _editSpeed; }
		}

		public Command RemoveSpeed
		{
			get { return _removeSpeed; }
		}

		private void ExecuteAddSpeed()
		{
			AddSpeedWindowViewModel addSpeedWindowViewModel = new AddSpeedWindowViewModel();
			Model.Speed Speed = addSpeedWindowViewModel.GetSpeed();
			if (Speed != null)
			{
				Speeds.Speeds.Add(Speed);
			}
		}

		private void ExecuteEditSpeed()
		{
			if (SelectedSpeed < Speeds.Speeds.Count && SelectedSpeed >= 0)
			{
				AddSpeedWindowViewModel addSpeedWindowViewModel = new AddSpeedWindowViewModel(Speeds.Speeds[SelectedSpeed]);
				Model.Speed Speed = addSpeedWindowViewModel.GetSpeed();
				if (Speed != null)
				{
					Speeds.Speeds[SelectedSpeed] = Speed;
				}
			}
		}

		private void ExecuteRemoveSpeed()
		{
			if (SelectedSpeed < Speeds.Speeds.Count)
			{
				Speeds.Speeds.RemoveAt(SelectedSpeed);
			}
		}

		public Command AddAttackSet
		{
			get { return _addAttackSet; }
		}

		public Command EditAttackSet
		{
			get { return _editAttackSet; }
		}

		public Command RemoveAttackSet
		{
			get { return _removeAttackSet; }
		}

		private void ExecuteAddAttackSet()
		{
			AddAttackSetWindowViewModel addAttackSetWindowViewModel = new AddAttackSetWindowViewModel();
			Model.AttackSet attackSet = addAttackSetWindowViewModel.GetAttackSet();
			if (attackSet != null)
			{
				AttackSets.Add(attackSet);
			}
		}

		private void ExecuteEditAttackSet()
		{
			if (SelectedAttackSet < AttackSets.Count && SelectedAttackSet >= 0)
			{
				AddAttackSetWindowViewModel addAttackSetWindowViewModel = new AddAttackSetWindowViewModel(AttackSets[SelectedAttackSet]);
				Model.AttackSet attackSet = addAttackSetWindowViewModel.GetAttackSet();
				if (attackSet != null)
				{
					AttackSets[SelectedAttackSet] = attackSet;
				}
			}
		}

		private void ExecuteRemoveAttackSet()
		{
			if (SelectedAttackSet < AttackSets.Count)
			{
				AttackSets.RemoveAt(SelectedAttackSet);
			}
		}

		public Command AddWeapon
		{
			get { return _addWeapon; }
		}

		public Command EditWeapon
		{
			get { return _editWeapon; }
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

		private void ExecuteEditWeapon()
		{
			if (SelectedWeapon < Weapons.Count && SelectedWeapon >= 0)
			{
				AddWeaponWindowViewModel addWeaponWindowViewModel = new AddWeaponWindowViewModel(Weapons[SelectedWeapon]);
				Model.Weapon weapon = addWeaponWindowViewModel.GetWeapon();
				if (weapon != null)
				{
					Weapons[SelectedWeapon] = weapon;
				}
			}
		}

		private void ExecuteRemoveWeapon()
		{
			if (SelectedWeapon < Weapons.Count)
			{
				Weapons.RemoveAt(SelectedWeapon);
			}
		}

		public Command AddDamageReduction
		{
			get { return _addDamageReduction; }
		}

		public Command EditDamageReduction
		{
			get { return _editDamageReduction; }
		}

		public Command RemoveDamageReduction
		{
			get { return _removeDamageReduction; }
		}

		private void ExecuteAddDamageReduction()
		{
			AddDamageReductionWindowViewModel addDamageReductionWindowViewModel = new AddDamageReductionWindowViewModel();
			Model.DamageReduction dr = addDamageReductionWindowViewModel.GetDamageReduction();
			if (dr != null)
			{
				DamageReductions.Add(dr);
			}
		}

		private void ExecuteEditDamageReduction()
		{
			if (SelectedDamageReduction < DamageReductions.Count && SelectedDamageReduction >= 0)
			{
				AddDamageReductionWindowViewModel addDamageReductionWindowViewModel = new AddDamageReductionWindowViewModel(DamageReductions[SelectedDamageReduction]);
				Model.DamageReduction dr = addDamageReductionWindowViewModel.GetDamageReduction();
				if (dr != null)
				{
					DamageReductions[SelectedDamageReduction] = dr;
				}
			}
		}

		private void ExecuteRemoveDamageReduction()
		{
			if (SelectedDamageReduction < DamageReductions.Count)
			{
				DamageReductions.RemoveAt(SelectedDamageReduction);
			}
		}

		public Command EditImmunities
		{
			get { return _editImmunities; }
		}

		private void ExecuteEditImmunities()
		{
			AddImmunityWindowViewModel addImmunityWindowViewModel = new AddImmunityWindowViewModel(Immunities);
			Model.DamageDescriptorSet immunity = addImmunityWindowViewModel.GetImmunity();
			if (immunity != null)
			{
				Immunities = immunity;
			}
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
