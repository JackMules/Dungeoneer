using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class Creature : NonPlayerActor
	{
		private int _strength;
		private int _dexterity;
		private int _constitution;
		private int _intelligence;
		private int _wisdom;
		private int _charisma;

		private int _baseAttackBonus;
		private int _hitPoints;
		private int _hitDice;
		private Utility.Types.DieType _hitDiceType;

		private int _armourClass;
		private int _touchArmourClass;
		private int _flatFootedArmourClass;

		private int _speed;

		private int _fortitudeSave;
		private int _reflexSave;
		private int _willSave;

		private bool _powerAttack;

		private Utility.Types.Size _size;
		private List<DamageReduction> _damageReductions;

		public int Strength
		{
			get { return _strength; }
			set
			{
				_strength = value;
				OnPropertyChanged("Strength");
			}
		}

		public int Dexterity
		{
			get { return _dexterity; }
			set
			{
				_dexterity = value;
				OnPropertyChanged("Dexterity");
			}
		}

		public int Constitution
		{
			get { return _constitution; }
			set
			{
				_constitution = value;
				OnPropertyChanged("Constitution");
			}
		}

		public int Intelligence
		{
			get { return _intelligence; }
			set
			{
				_intelligence = value;
				OnPropertyChanged("Intelligence");
			}
		}

		public int Wisdom
		{
			get { return _wisdom; }
			set
			{
				_wisdom = value;
				OnPropertyChanged("Wisdom");
			}
		}

		public int Charisma
		{
			get { return _charisma; }
			set
			{
				_charisma = value;
				OnPropertyChanged("Charisma");
			}
		}

		public int BaseAttackBonus
		{
			get { return _baseAttackBonus; }
			set
			{
				_baseAttackBonus = value;
				OnPropertyChanged("BaseAttackBonus");
			}
		}

		public int HitPoints
		{
			get { return _hitPoints; }
			set
			{
				_hitPoints = value;
				OnPropertyChanged("HitPoints");
			}
		}

		public int HitDice
		{
			get { return _hitDice; }
			set
			{
				_hitDice = value;
				OnPropertyChanged("HitDice");
			}
		}

		public Utility.Types.DieType HitDiceType
		{
			get { return _hitDiceType; }
			set
			{
				_hitDiceType = value;
				OnPropertyChanged("HitDiceType");
			}
		}

		public int ArmourClass
		{
			get { return _armourClass; }
			set
			{
				_armourClass = value;
				OnPropertyChanged("ArmourClass");
			}
		}

		public int TouchArmourClass
		{
			get { return _touchArmourClass; }
			set
			{
				_touchArmourClass = value;
				OnPropertyChanged("TouchArmourClass");
			}
		}

		public int FlatFootedArmourClass
		{
			get { return _flatFootedArmourClass; }
			set
			{
				_flatFootedArmourClass = value;
				OnPropertyChanged("FlatFootedArmourClass");
			}
		}

		public int Speed
		{
			get { return _speed; }
			set
			{
				_speed = value;
				OnPropertyChanged("Speed");
			}
		}

		public int FortitudeSave
		{
			get { return _fortitudeSave; }
			set
			{
				_fortitudeSave = value;
				OnPropertyChanged("FortitudeSave");
			}
		}

		public int ReflexSave
		{
			get { return _reflexSave; }
			set
			{
				_reflexSave = value;
				OnPropertyChanged("ReflexSave");
			}
		}

		public int WillSave
		{
			get { return _willSave; }
			set
			{
				_willSave = value;
				OnPropertyChanged("WillSave");
			}
		}

		public bool PowerAttack
		{
			get { return _powerAttack; }
			set
			{
				_powerAttack = value;
				OnPropertyChanged("PowerAttack");
			}
		}

		public Utility.Types.Size Size
		{
			get { return _size; }
			set
			{
				_size = value;
				OnPropertyChanged("Size");
			}
		}
		
		public List<DamageReduction> DamageReductions
		{
			get { return _damageReductions; }
			set
			{
				_damageReductions = value;
				OnPropertyChanged("DamageReductions");
			}
		}

		public Creature()
			: base()
		{
			Strength = 10;
			Dexterity = 10;
			Constitution = 10;
			Intelligence = 10;
			Wisdom = 10;
			Charisma = 10;
			BaseAttackBonus = 0;
			HitPoints = 3;
			HitDice = 1;
			HitDiceType = Utility.Types.DieType.d3;
			ArmourClass = 10;
			TouchArmourClass = 10;
			FlatFootedArmourClass = 10;
			Speed = 30;
			FortitudeSave = 0;
			ReflexSave = 0;
			WillSave = 0;
			PowerAttack = false;
			Size = Utility.Types.Size.Medium;
			DamageReductions = null;
		}

		public Creature(
			string displayName,
			string actorName, 
			string type, 
			int initiativeMod,
			float challengeRating,
			List<Attack> attacks,
			int strength,
			int dexterity,
			int constitution,
			int intelligence,
			int wisdom,
			int charisma,
			int baseAttackBonus,
			int hitPoints,
			int hitDice,
			Utility.Types.DieType hitDiceType,
			int armourClass,
			int touchArmourClass,
			int flatFootedArmourClass,
			int damageReduction,
			string damageReductionType,
			int speed,
			int fortitudeSave,
			int reflexSave,
			int willSave,
			bool powerAttack,
			Utility.Types.Size size,
			List<DamageReduction> damageReductions)
			: base(displayName, actorName, type, 
					initiativeMod, challengeRating, attacks)
		{
			Strength = strength;
			Dexterity = dexterity;
			Constitution = constitution;
			Intelligence = intelligence;
			Wisdom = wisdom;
			Charisma = charisma;
			BaseAttackBonus = baseAttackBonus;
			HitPoints = hitPoints; 
			HitDice = hitDice; 
			HitDiceType = hitDiceType; 
			ArmourClass = armourClass; 
			TouchArmourClass = touchArmourClass; 
			FlatFootedArmourClass = flatFootedArmourClass; 
			Speed = speed; 
			FortitudeSave = fortitudeSave; 
			ReflexSave = reflexSave; 
			WillSave = willSave;
			PowerAttack = powerAttack;
			Size = size;
			DamageReductions = damageReductions;
		}

		public void DoDamage(int damage, Utility.Types.DamageType damageType)
		{
			DamageReduction dr = null;
//			try
	//		{
				dr = DamageReductions.SingleOrDefault(i => i.DamageType == damageType);
//			}
//			catch
//			{

//			}

			if (dr != null)
			{
				damage -= dr.Value;

				if (damage < 0)
				{
					damage = 0;
				}
			}
			
			HitPoints -= damage;
		}
	}
}
