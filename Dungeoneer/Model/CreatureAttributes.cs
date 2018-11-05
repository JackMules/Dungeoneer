using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;
using System.Collections.ObjectModel;

namespace Dungeoneer.Model
{
	public class CreatureAttributes : NonPlayerActorAttributes
	{
		public CreatureAttributes()
			: base()
		{
			Strength = 10;
			Dexterity = 10;
			Constitution = 10;
			Intelligence = 10;
			Wisdom = 10;
			Charisma = 10;
			BaseAttackBonus = 0;
			GrappleModifier = 0;
			HitPoints = 3;
			HitDice = 1;
			HitDieType = Types.Die.d3;
			ArmorClass = 10;
			TouchArmorClass = 10;
			FlatFootedArmorClass = 10;
			Speed = 30;
			FortitudeSave = 0;
			ReflexSave = 0;
			WillSave = 0;
			Feats = new List<string>();
			Space = 5;
			Reach = 5;
			Size = Types.Size.Medium;
			DamageReductions = new ObservableCollection<DamageReduction>();
			Immunities = new DamageDescriptorSet();
		}

		public CreatureAttributes(CreatureAttributes other)
			: base(other)
		{
			Strength = other.Strength;
			Dexterity = other.Dexterity;
			Constitution = other.Constitution;
			Intelligence = other.Intelligence;
			Wisdom = other.Wisdom;
			Charisma = other.Charisma;
			BaseAttackBonus = other.BaseAttackBonus;
			GrappleModifier = other.GrappleModifier;
			HitPoints = other.HitPoints;
			HitDice = other.HitDice;
			HitDieType = other.HitDieType;
			ArmorClass = other.ArmorClass;
			TouchArmorClass = other.TouchArmorClass;
			FlatFootedArmorClass = other.FlatFootedArmorClass;
			Speed = other.Speed;
			FortitudeSave = other.FortitudeSave;
			ReflexSave = other.ReflexSave;
			WillSave = other.WillSave;
			Feats = new List<string>(other.Feats);
			Space = other.Space;
			Reach = other.Reach;
			Size = other.Size;
			DamageReductions = new ObservableCollection<DamageReduction>(other.DamageReductions);
			Immunities = new DamageDescriptorSet(other.Immunities);
		}

		private int _strength;
		private int _dexterity;
		private int _constitution;
		private int _intelligence;
		private int _wisdom;
		private int _charisma;

		private int _baseAttackBonus;
		private int _grappleModifier;
		private int _hitPoints;
		private int _hitDice;
		private Types.Die _hitDieType;

		private int _armorClass;
		private int _touchArmorClass;
		private int _flatFootedArmorClass;

		private int _speed;

		private int _fortitudeSave;
		private int _reflexSave;
		private int _willSave;

		private List<string> _feats;

		private int _space;
		private int _reach;
		private Types.Size _size;
		private ObservableCollection<DamageReduction> _damageReductions;
		private DamageDescriptorSet _immunities;

		public int Strength
		{
			get
			{
				return _strength;
			}
			set
			{
				_strength = value;
				NotifyPropertyChanged("Strength");
			}
		}

		public int Dexterity
		{
			get { return _dexterity; }
			set
			{
				_dexterity = value;
				NotifyPropertyChanged("Dexterity");
			}
		}

		public int Constitution
		{
			get { return _constitution; }
			set
			{
				_constitution = value;
				NotifyPropertyChanged("Constitution");
			}
		}

		public int Intelligence
		{
			get { return _intelligence; }
			set
			{
				_intelligence = value;
				NotifyPropertyChanged("Intelligence");
			}
		}

		public int Wisdom
		{
			get { return _wisdom; }
			set
			{
				_wisdom = value;
				NotifyPropertyChanged("Wisdom");
			}
		}

		public int Charisma
		{
			get { return _charisma; }
			set
			{
				_charisma = value;
				NotifyPropertyChanged("Charisma");
			}
		}

		public int BaseAttackBonus
		{
			get { return _baseAttackBonus; }
			set
			{
				_baseAttackBonus = value;
				NotifyPropertyChanged("BaseAttackBonus");
			}
		}

		public int GrappleModifier
		{
			get { return _grappleModifier; }
			set
			{
				_grappleModifier = value;
				NotifyPropertyChanged("BaseGrappleModifierAttackBonus");
			}
		}

		public int HitPoints
		{
			get { return _hitPoints; }
			set
			{
				_hitPoints = value;
				NotifyPropertyChanged("HitPoints");
			}
		}

		public int HitDice
		{
			get { return _hitDice; }
			set
			{
				_hitDice = value;
				NotifyPropertyChanged("HitDice");
			}
		}

		public Types.Die HitDieType
		{
			get { return _hitDieType; }
			set
			{
				_hitDieType = value;
				NotifyPropertyChanged("HitDiceType");
			}
		}

		public int ArmorClass
		{
			get { return _armorClass; }
			set
			{
				_armorClass = value;
				NotifyPropertyChanged("ArmorClass");
			}
		}

		public int TouchArmorClass
		{
			get { return _touchArmorClass; }
			set
			{
				_touchArmorClass = value;
				NotifyPropertyChanged("TouchArmorClass");
			}
		}

		public int FlatFootedArmorClass
		{
			get { return _flatFootedArmorClass; }
			set
			{
				_flatFootedArmorClass = value;
				NotifyPropertyChanged("FlatFootedArmorClass");
			}
		}

		public int Speed
		{
			get { return _speed; }
			set
			{
				_speed = value;
				NotifyPropertyChanged("Speed");
			}
		}

		public int FortitudeSave
		{
			get { return _fortitudeSave; }
			set
			{
				_fortitudeSave = value;
				NotifyPropertyChanged("FortitudeSave");
			}
		}

		public int ReflexSave
		{
			get { return _reflexSave; }
			set
			{
				_reflexSave = value;
				NotifyPropertyChanged("ReflexSave");
			}
		}

		public int WillSave
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
			get
			{
				return Feats.Contains("Power Attack", StringComparer.CurrentCultureIgnoreCase) &&
					Strength >= 13;
			}
		}

		public int Space
		{
			get { return _space; }
			set
			{
				_space = value;
				NotifyPropertyChanged("Space");
			}
		}

		public int Reach
		{
			get { return _reach; }
			set
			{
				_reach = value;
				NotifyPropertyChanged("Reach");
			}
		}

		public List<string> Feats
		{
			get { return _feats; }
			set
			{
				_feats = value;
				NotifyPropertyChanged("Feats");
				NotifyPropertyChanged("PowerAttack");
			}
		}

		public Types.Size Size
		{
			get { return _size; }
			set
			{
				_size = value;
				NotifyPropertyChanged("Size");
			}
		}

		public ObservableCollection<DamageReduction> DamageReductions
		{
			get { return _damageReductions; }
			set
			{
				_damageReductions = value;
				NotifyPropertyChanged("DamageReductions");
			}
		}

		public DamageDescriptorSet Immunities
		{
			get { return _immunities; }
			set
			{
				_immunities = value;
				NotifyPropertyChanged("Immunities");
			}
		}

		public void ModifyArmorClass(int change)
		{
			ArmorClass += change;
			FlatFootedArmorClass += change;
			TouchArmorClass += change;
		}

		public void SetFlatFooted()
		{
			ArmorClass = FlatFootedArmorClass;
			TouchArmorClass -= Methods.GetAbilityModifier(Dexterity);
		}

		public void ModifySaves(int change)
		{
			FortitudeSave += change;
			ReflexSave += change;
			WillSave += change;
		}

		public void ModifyAbilityScore(Types.Ability ability, int change)
		{
			int oldModifier = GetAbilityModifier(ability);
			SetAbilityScore(ability, GetAbilityScore(ability) + change);
			int newModifier = GetAbilityModifier(ability);

			int modifierDifference = newModifier - oldModifier;

			if (ability == Types.Ability.Strength ||
				ability == Types.Ability.Dexterity)
			{
				ChangeAttackModifier(ability, modifierDifference);

				if (ability == Types.Ability.Dexterity)
				{
					ReflexSave += modifierDifference;
				}
			}
			else if (ability == Types.Ability.Constitution)
			{
				HitPoints += HitDice * modifierDifference;
				FortitudeSave += modifierDifference;
			}
			else
			{
				// Modify spell DCs

				if (ability == Types.Ability.Wisdom)
				{
					WillSave += modifierDifference;
				}
			}
		}

		public int GetAbilityScore(Types.Ability ability)
		{
			switch (ability)
			{
			case Types.Ability.Strength:
				return Strength;
			case Types.Ability.Dexterity:
				return Dexterity;
			case Types.Ability.Constitution:
				return Constitution;
			case Types.Ability.Intelligence:
				return Intelligence;
			case Types.Ability.Wisdom:
				return Wisdom;
			case Types.Ability.Charisma:
				return Charisma;
			}
			return 0;
		}

		public int GetAbilityModifier(Types.Ability ability)
		{
			return Methods.GetAbilityModifier(GetAbilityScore(ability));
		}

		public void SetAbilityScore(Types.Ability ability, int score)
		{
			switch (ability)
			{
			case Types.Ability.Strength:
				Strength = score;
				break;
			case Types.Ability.Dexterity:
				Dexterity = score;
				break;
			case Types.Ability.Constitution:
				Constitution = score;
				break;
			case Types.Ability.Intelligence:
				Intelligence = score;
				break;
			case Types.Ability.Wisdom:
				Wisdom = score;
				break;
			case Types.Ability.Charisma:
				Charisma = score;
				break;
			}
		}

		public int DoHitPointDamage(Hit hit)
		{
			int hp = HitPoints;

			List<DamageReduction> damageReductions = DamageReductions.ToList();
			damageReductions.Sort((dr1, dr2) => dr2.Value.CompareTo(dr1.Value));

			foreach (DamageSet damageSet in hit.DamageSets)
			{
				foreach (Types.Damage damageType in damageSet.DamageDescriptorSet.ToList())
				{
					if (Immunities.Contains(damageType))
					{
						damageSet.Amount = 0;
					}
				}
				foreach (DamageReduction dr in damageReductions)
				{
					if (!dr.IsBypassedBy(damageSet.DamageDescriptorSet))
					{
						damageSet.Amount -= dr.Value;
						break;
					}
				}
				if (damageSet.Amount < 0)
				{
					damageSet.Amount = 0;
				}
			}

			foreach (DamageSet damageSet in hit.DamageSets)
			{
				HitPoints -= damageSet.Amount;
			}

			return hp - HitPoints;
		}
	}
}
