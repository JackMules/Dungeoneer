using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Utility
{
	public static class Constants
	{
		public static readonly string DieTypeD3 = "d3";
		public static readonly string DieTypeD4 = "d4";
		public static readonly string DieTypeD6 = "d6";
		public static readonly string DieTypeD8 = "d8";
		public static readonly string DieTypeD10 = "d10";
		public static readonly string DieTypeD12 = "d12";

		public static readonly string SizeFine = "Fine";
		public static readonly string SizeDiminuative = "Diminuative";
		public static readonly string SizeTiny = "Tiny";
		public static readonly string SizeSmall = "Small";
		public static readonly string SizeMedium = "Medium";
		public static readonly string SizeLarge = "Large";
		public static readonly string SizeHuge = "Huge";
		public static readonly string SizeGargantuan = "Gargantuan";
		public static readonly string SizeColossal = "Colossal";
		public static readonly string SizeColossalPlus = "Colossal+";

		public static readonly string AttackTypePrimary = "Melee Primary";
		public static readonly string AttackTypeSecondary = "Melee Secondary";
		public static readonly string AttackTypeRanged = "Ranged";
		public static readonly string AttackTypeTouch = "Touch";
		public static readonly string AttackTypeRangedTouch = "Ranged Touch";
		public static readonly string AttackTypeIncorporealTouch = "Incorporeal Touch";

		public static readonly string DamageTypeAcid = "Acid";
		public static readonly string DamageTypeAdamantine = "Adamantine";
		public static readonly string DamageTypeBludgeoning = "Bludgeoning";
		public static readonly string DamageTypeChaos = "Chaos";
		public static readonly string DamageTypeCold = "Cold";
		public static readonly string DamageTypeColdIron = "Cold Iron";
		public static readonly string DamageTypeDivine = "Divine";
		public static readonly string DamageTypeElectricity = "Electricity";
		public static readonly string DamageTypeEpic = "Epic";
		public static readonly string DamageTypeEvil = "Evil";
		public static readonly string DamageTypeFire = "Fire";
		public static readonly string DamageTypeForce = "Force";
		public static readonly string DamageTypeGood = "Good";
		public static readonly string DamageTypeLaw = "Law";
		public static readonly string DamageTypeMagic = "Magic";
		public static readonly string DamageTypeNegativeEnergy = "Negative Energy";
		public static readonly string DamageTypePiercing = "Piercing";
		public static readonly string DamageTypePositiveEnergy = "Positive Energy";
		public static readonly string DamageTypeSilver = "Silver";
		public static readonly string DamageTypeSlashing = "Slashing";
		public static readonly string DamageTypeSonic = "Sonic";
		public static readonly string DamageTypeSubdual = "Subdual";
		
		public static readonly List<string> SizeStrings = new List<string>
		{
			Methods.GetSizeString(Types.Size.Fine),
			Methods.GetSizeString(Types.Size.Diminuative),
			Methods.GetSizeString(Types.Size.Tiny),
			Methods.GetSizeString(Types.Size.Small),
			Methods.GetSizeString(Types.Size.Medium),
			Methods.GetSizeString(Types.Size.Large),
			Methods.GetSizeString(Types.Size.Huge),
			Methods.GetSizeString(Types.Size.Gargantuan),
			Methods.GetSizeString(Types.Size.Colossal),
			Methods.GetSizeString(Types.Size.ColossalPlus),
		};

		public static readonly List<string> DieTypeStrings = new List<string>
		{
			Methods.GetDieTypeString(Types.Die.d3),
			Methods.GetDieTypeString(Types.Die.d4),
			Methods.GetDieTypeString(Types.Die.d6),
			Methods.GetDieTypeString(Types.Die.d8),
			Methods.GetDieTypeString(Types.Die.d10),
			Methods.GetDieTypeString(Types.Die.d12),
		};
		
		public static readonly List<string> AttackTypeStrings = new List<string>
		{
			Methods.GetAttackTypeString(Types.Attack.Primary),
			Methods.GetAttackTypeString(Types.Attack.Secondary),
			Methods.GetAttackTypeString(Types.Attack.Ranged),
			Methods.GetAttackTypeString(Types.Attack.Touch),
			Methods.GetAttackTypeString(Types.Attack.RangedTouch),
			Methods.GetAttackTypeString(Types.Attack.IncorporealTouch),
		};

		public static readonly List<string> ThreatRangeStrings = new List<string>
		{
			Methods.GetThreatRangeString(20),
			Methods.GetThreatRangeString(19),
			Methods.GetThreatRangeString(18),
			Methods.GetThreatRangeString(17),
			Methods.GetThreatRangeString(16),
			Methods.GetThreatRangeString(15),
			Methods.GetThreatRangeString(14),
			Methods.GetThreatRangeString(13),
			Methods.GetThreatRangeString(12),
			Methods.GetThreatRangeString(11),
			Methods.GetThreatRangeString(10),
		};

		public static readonly List<string> CritMultiplierStrings = new List<string>
		{
			Methods.GetCritMultiplierString(2),
			Methods.GetCritMultiplierString(3),
			Methods.GetCritMultiplierString(4),
			Methods.GetCritMultiplierString(5),
		};
	}

	public static class Types
	{
		public enum Die
		{
			d3,
			d4,
			d6,
			d8,
			d10,
			d12,
		}

		public enum Size
		{
			Fine,
			Diminuative,
			Tiny,
			Small,
			Medium,
			Large,
			Huge,
			Gargantuan,
			Colossal,
			ColossalPlus,
		}

		public enum Attack
		{
			Primary,
			Secondary,
			Ranged,
			Touch,
			RangedTouch,
			IncorporealTouch,
		}

		public enum Damage
		{
			Acid,
			Adamantine,
			Bludgeoning,
			Chaos,
			Cold,
			ColdIron,
			Divine,
			Electricity,
			Epic,
			Evil,
			Fire,
			Force,
			Good,
			Law,
			Magic,
			NegativeEnergy,
			Piercing,
			PositiveEnergy,
			Silver,
			Slashing,
			Sonic,
			Subdual,
		}

		public enum Effect
		{
			DamagePerTurn,
			TimedDamagePerTurn,
		}

		public enum Ability
		{
			Strength,
			Dexterity,
			Constitution,
			Intelligence,
			Wisdom,
			Charisma,
		}

		public enum Attribute
		{
			HitPoints,
			SubdualHitPoints,
		}
	}

	public static class Methods
	{
		public static string GetDamageString(FullyObservableCollection<Model.Damage> damages)
		{
			List<string> damageStrings = new List<string>();

			foreach (Model.Damage damage in damages)
			{
				damageStrings.Add(damage.NumDice.ToString() + GetDieTypeString(damage.Die) + GetSignedNumberString(damage.Modifier) + " " + GetDamageTypeString(damage.Type));
			}

			return String.Join(" + ", damageStrings);
		}

		public static string GetSignedNumberString(int num)
		{
			if (num < 0)
			{
				return num.ToString();
			}
			else
			{
				return "+" + num.ToString();
			}
		}

		public static string GetThreatRangeString(int minValue)
		{
			string threatRange = "20";
			if (minValue != 20)
			{
				threatRange = minValue.ToString() + "-" + threatRange;
			}
			return threatRange;
		}

		public static int GetThreatRangeMinFromString(string threatRange)
		{
			string subStr = threatRange.Substring(0, 2);
			int min = 20;
			try
			{
				min = Convert.ToInt32(subStr);
			}
			catch (FormatException e)
			{
				throw e;
			}

			return min;
		}

		public static string GetCritMultiplierString(int multiplier)
		{
			return "x" + multiplier.ToString();
		}

		public static int GetCritMultiplierFromString(string multiplier)
		{
			return Convert.ToInt32(multiplier.Substring(1,1));
		}

		public static string GetDieTypeString(Types.Die dieType)
		{
			switch (dieType)
			{
				case Types.Die.d3:	return Constants.DieTypeD3;
				case Types.Die.d4:	return Constants.DieTypeD4;
				case Types.Die.d6:	return Constants.DieTypeD6;
				case Types.Die.d8:	return Constants.DieTypeD8;
				case Types.Die.d10: return Constants.DieTypeD10;
				case Types.Die.d12: return Constants.DieTypeD12;
				default: return "Unrecognised die type";
			}
		}

		public static Types.Die GetDieTypeFromString(string str)
		{
			if (str == Constants.DieTypeD3)
			{
				return Types.Die.d3;
			}
			else if (str == Constants.DieTypeD4)
			{
				return Types.Die.d4;
			}
			else if (str == Constants.DieTypeD6)
			{
				return Types.Die.d6;
			}
			else if (str == Constants.DieTypeD8)
			{
				return Types.Die.d8;
			}
			else if (str == Constants.DieTypeD10)
			{
				return Types.Die.d10;
			}
			else if (str == Constants.DieTypeD12)
			{
				return Types.Die.d12;
			}
			else
			{
				throw new FormatException("Die type \'" + str + "\' not recognised.");
			}
		}

		public static string GetSizeString(Types.Size size)
		{
			switch (size)
			{
				case Types.Size.Fine: return Constants.SizeFine;
				case Types.Size.Diminuative: return Constants.SizeDiminuative;
				case Types.Size.Tiny: return Constants.SizeTiny;
				case Types.Size.Small: return Constants.SizeSmall;
				case Types.Size.Medium: return Constants.SizeMedium;
				case Types.Size.Large: return Constants.SizeLarge;
				case Types.Size.Huge: return Constants.SizeHuge;
				case Types.Size.Gargantuan: return Constants.SizeGargantuan;
				case Types.Size.Colossal: return Constants.SizeColossal;
				case Types.Size.ColossalPlus: return Constants.SizeColossalPlus;
				default: return "Unrecognised size";
			}
		}

		public static Types.Size GetSizeFromString(string str)
		{
			if (str == Constants.SizeFine)
			{
				return Types.Size.Fine;
			}
			else if (str == Constants.SizeDiminuative)
			{
				return Types.Size.Diminuative;
			}
			else if (str == Constants.SizeTiny)
			{
				return Types.Size.Tiny;
			}
			else if (str == Constants.SizeSmall)
			{
				return Types.Size.Small;
			}
			else if (str == Constants.SizeMedium)
			{
				return Types.Size.Medium;
			}
			else if (str == Constants.SizeLarge)
			{
				return Types.Size.Large;
			}
			else if (str == Constants.SizeHuge)
			{
				return Types.Size.Huge;
			}
			else if (str == Constants.SizeGargantuan)
			{
				return Types.Size.Gargantuan;
			}
			else if (str == Constants.SizeColossal)
			{
				return Types.Size.Colossal;
			}
			else if (str == Constants.SizeColossalPlus)
			{
				return Types.Size.ColossalPlus;
			}
			else
			{
				throw new FormatException("Size type \'" + str + "\' not recognised.");
			}
		}

		public static string GetAttackTypeString(Types.Attack attackType)
		{
			switch (attackType)
			{
				case Types.Attack.Primary:					return Constants.AttackTypePrimary;
				case Types.Attack.Secondary:				return Constants.AttackTypeSecondary;
				case Types.Attack.Ranged:						return Constants.AttackTypeRanged;
				case Types.Attack.Touch:						return Constants.AttackTypeTouch;
				case Types.Attack.RangedTouch:			return Constants.AttackTypeRangedTouch;
				case Types.Attack.IncorporealTouch: return Constants.AttackTypeIncorporealTouch;
				default: return "Unrecognised attack type";
			}
		}

		public static Types.Attack GetAttackTypeFromString(string str)
		{
			if (str == Constants.AttackTypePrimary)
			{
				return Types.Attack.Primary;
			}
			else if (str == Constants.AttackTypeSecondary)
			{
				return Types.Attack.Secondary;
			}
			else if (str == Constants.AttackTypeRanged)
			{
				return Types.Attack.Ranged;
			}
			else
			{
				throw new FormatException("Attack type \'" + str + "\' not recognised.");
			}
		}

		public static string GetDamageTypeString(Types.Damage damageType)
		{
			switch (damageType)
			{
				case Types.Damage.Acid:						return Constants.DamageTypeAcid;
				case Types.Damage.Adamantine:			return Constants.DamageTypeAdamantine;
				case Types.Damage.Bludgeoning:		return Constants.DamageTypeBludgeoning;
				case Types.Damage.Chaos:					return Constants.DamageTypeChaos;
				case Types.Damage.Cold:						return Constants.DamageTypeCold;
				case Types.Damage.ColdIron:				return Constants.DamageTypeColdIron;
				case Types.Damage.Divine:					return Constants.DamageTypeDivine;
				case Types.Damage.Epic:						return Constants.DamageTypeEpic;
				case Types.Damage.Electricity:		return Constants.DamageTypeElectricity;
				case Types.Damage.Evil:						return Constants.DamageTypeEvil;
				case Types.Damage.Fire:						return Constants.DamageTypeFire;
				case Types.Damage.Force:					return Constants.DamageTypeForce;
				case Types.Damage.Good:						return Constants.DamageTypeGood;
				case Types.Damage.Law:						return Constants.DamageTypeLaw;
				case Types.Damage.NegativeEnergy:	return Constants.DamageTypeNegativeEnergy;
				case Types.Damage.Piercing:				return Constants.DamageTypePiercing;
				case Types.Damage.PositiveEnergy:	return Constants.DamageTypePositiveEnergy;
				case Types.Damage.Silver:					return Constants.DamageTypeSilver;
				case Types.Damage.Slashing:				return Constants.DamageTypeSlashing;
				case Types.Damage.Sonic:					return Constants.DamageTypeSonic;
				case Types.Damage.Subdual:				return Constants.DamageTypeSubdual;
				default:													return "Unrecognised damage type";
			}
		}

		public static Types.Damage GetDamageTypeFromString(string str)
		{
			if (str == Constants.DamageTypeAcid)
			{
				return Types.Damage.Acid;
			}
			else if (str == Constants.DamageTypeAdamantine)
			{
				return Types.Damage.Adamantine;
			}
			else if (str == Constants.DamageTypeBludgeoning)
			{
				return Types.Damage.Bludgeoning;
			}
			else if (str == Constants.DamageTypeChaos)
			{
				return Types.Damage.Chaos;
			}
			else if (str == Constants.DamageTypeCold)
			{
				return Types.Damage.Cold;
			}
			else if (str == Constants.DamageTypeColdIron)
			{
				return Types.Damage.ColdIron;
			}
			else if (str == Constants.DamageTypeDivine)
			{
				return Types.Damage.Divine;
			}
			else if (str == Constants.DamageTypeEpic)
			{
				return Types.Damage.Epic;
			}
			else if (str == Constants.DamageTypeElectricity)
			{
				return Types.Damage.Electricity;
			}
			else if (str == Constants.DamageTypeEvil)
			{
				return Types.Damage.Evil;
			}
			else if (str == Constants.DamageTypeFire)
			{
				return Types.Damage.Fire;
			}
			else if (str == Constants.DamageTypeForce)
			{
				return Types.Damage.Force;
			}
			else if (str == Constants.DamageTypeGood)
			{
				return Types.Damage.Good;
			}
			else if (str == Constants.DamageTypeLaw)
			{
				return Types.Damage.Law;
			}
			else if (str == Constants.DamageTypeNegativeEnergy)
			{
				return Types.Damage.NegativeEnergy;
			}
			else if (str == Constants.DamageTypePiercing)
			{
				return Types.Damage.Piercing;
			}
			else if (str == Constants.DamageTypePositiveEnergy)
			{
				return Types.Damage.PositiveEnergy;
			}
			else if (str == Constants.DamageTypeSilver)
			{
				return Types.Damage.Silver;
			}
			else if (str == Constants.DamageTypeSlashing)
			{
				return Types.Damage.Slashing;
			}
			else if (str == Constants.DamageTypeSonic)
			{
				return Types.Damage.Sonic;
			}
			else if (str == Constants.DamageTypeSubdual)
			{
				return Types.Damage.Subdual;
			}
			else
			{
				throw new FormatException("Damage type \'" + str + "\' not recognised.");
			}
		}
		
		public static int CalculateXP(int challengeRating)
		{
			if (challengeRating == 1)
			{
				return 300;
			}
			else if (challengeRating == 2)
			{
				return 2 * CalculateXP(1);
			}
			else if (challengeRating == 3)
			{
				return CalculateXP(2) + CalculateXP(1);
			}
			else
			{
				return 2 * CalculateXP(challengeRating - 2);
			}
		}

		public static int CalculateNewHitPoints(Model.Creature creature, int damage, Model.Weapon weapon)
		{
			List<Model.DamageReduction> damageReductions = creature.DamageReductions;
			damageReductions.Sort((dr1, dr2) => dr2.Value.CompareTo(dr1.Value));

			foreach (Model.DamageReduction dr in damageReductions)
			{
				bool bypassed = true;
				foreach (Types.Damage drDamageType in dr.DamageTypes)
				{
					bool matched = false;
					foreach (Types.Damage weaponDamageType in weapon.DamageQualities)
					{
						if (weaponDamageType == drDamageType)
						{
							matched = true;
							break;
						}
					}

					// If none of the weapon's damage qualities match this part of the damage type, then 
					if (!matched)
					{
						bypassed = false;
						break;
					}
				}

				if (!bypassed)
				{
					damage -= dr.Value;
					break;
				}
			}

			if (damage < 0)
			{
				damage = 0;
			}

			return creature.HitPoints - damage;
		}
	}
}
