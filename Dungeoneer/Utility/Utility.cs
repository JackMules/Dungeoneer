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

		public static readonly string DamageTypeFire = "Fire";
		public static readonly string DamageTypeCold = "Cold";
		public static readonly string DamageTypeElectricity = "Electricity";
		public static readonly string DamageTypeAcid = "Acid";
		public static readonly string DamageTypePositiveEnergy = "Positive Energy";
		public static readonly string DamageTypeNegativeEnergy = "Negative Energy";
		public static readonly string DamageTypePiercing = "Piercing";
		public static readonly string DamageTypeBludgeoning = "Bludgeoning";
		public static readonly string DamageTypeSlashing = "Slashing";
		public static readonly string DamageTypeForce = "Force";
		public static readonly string DamageTypeSonic = "Sonic";
		public static readonly string DamageTypeDivine = "Divine";
		public static readonly string DamageTypeSubdual = "Subdual";
		public static readonly string DamageTypeUntyped = "Untyped";

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

		public static readonly List<string> DamageTypeStrings = new List<string>
		{
			Methods.GetDamageTypeString(Types.DamageType.Fire),
			Methods.GetDamageTypeString(Types.DamageType.Cold),
			Methods.GetDamageTypeString(Types.DamageType.Electricity),
			Methods.GetDamageTypeString(Types.DamageType.Acid),
			Methods.GetDamageTypeString(Types.DamageType.PositiveEnergy),
			Methods.GetDamageTypeString(Types.DamageType.NegativeEnergy),
			Methods.GetDamageTypeString(Types.DamageType.Piercing),
			Methods.GetDamageTypeString(Types.DamageType.Bludgeoning),
			Methods.GetDamageTypeString(Types.DamageType.Slashing),
			Methods.GetDamageTypeString(Types.DamageType.Force),
			Methods.GetDamageTypeString(Types.DamageType.Sonic),
			Methods.GetDamageTypeString(Types.DamageType.Divine),
			Methods.GetDamageTypeString(Types.DamageType.Untyped),
			Methods.GetDamageTypeString(Types.DamageType.Subdual),
		};

		public static readonly List<string> DieTypeStrings = new List<string>
		{
			Methods.GetDieTypeString(Types.DieType.d3),
			Methods.GetDieTypeString(Types.DieType.d4),
			Methods.GetDieTypeString(Types.DieType.d6),
			Methods.GetDieTypeString(Types.DieType.d8),
			Methods.GetDieTypeString(Types.DieType.d10),
			Methods.GetDieTypeString(Types.DieType.d12),
		};
		
		public static readonly List<string> AttackTypeStrings = new List<string>
		{
			Methods.GetAttackTypeString(Types.AttackType.Primary),
			Methods.GetAttackTypeString(Types.AttackType.Secondary),
			Methods.GetAttackTypeString(Types.AttackType.Ranged),
			Methods.GetAttackTypeString(Types.AttackType.Touch),
			Methods.GetAttackTypeString(Types.AttackType.RangedTouch),
			Methods.GetAttackTypeString(Types.AttackType.IncorporealTouch),
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
		public enum DieType
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

		public enum AttackType
		{
			Primary,
			Secondary,
			Ranged,
			Touch,
			RangedTouch,
			IncorporealTouch,
		}

		public enum DamageType
		{
			Fire,
			Cold,
			Electricity,
			Acid,
			PositiveEnergy,
			NegativeEnergy,
			Piercing,
			Bludgeoning,
			Slashing,
			Force,
			Sonic,
			Divine,
			Untyped,
			Subdual
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

		public static string GetDieTypeString(Types.DieType dieType)
		{
			switch (dieType)
			{
				case Types.DieType.d3:	return Constants.DieTypeD3;
				case Types.DieType.d4:	return Constants.DieTypeD4;
				case Types.DieType.d6:	return Constants.DieTypeD6;
				case Types.DieType.d8:	return Constants.DieTypeD8;
				case Types.DieType.d10: return Constants.DieTypeD10;
				case Types.DieType.d12: return Constants.DieTypeD12;
				default: return "Unrecognised die type";
			}
		}

		public static Types.DieType GetDieTypeFromString(string str)
		{
			if (str == Constants.DieTypeD3)
			{
				return Types.DieType.d3;
			}
			else if (str == Constants.DieTypeD4)
			{
				return Types.DieType.d4;
			}
			else if (str == Constants.DieTypeD6)
			{
				return Types.DieType.d6;
			}
			else if (str == Constants.DieTypeD8)
			{
				return Types.DieType.d8;
			}
			else if (str == Constants.DieTypeD10)
			{
				return Types.DieType.d10;
			}
			else if (str == Constants.DieTypeD12)
			{
				return Types.DieType.d12;
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

		public static string GetAttackTypeString(Types.AttackType attackType)
		{
			switch (attackType)
			{
				case Types.AttackType.Primary:					return Constants.AttackTypePrimary;
				case Types.AttackType.Secondary:				return Constants.AttackTypeSecondary;
				case Types.AttackType.Ranged:						return Constants.AttackTypeRanged;
				case Types.AttackType.Touch:						return Constants.AttackTypeTouch;
				case Types.AttackType.RangedTouch:			return Constants.AttackTypeRangedTouch;
				case Types.AttackType.IncorporealTouch: return Constants.AttackTypeIncorporealTouch;
				default: return "Unrecognised attack type";
			}
		}

		public static Types.AttackType GetAttackTypeFromString(string str)
		{
			if (str == Constants.AttackTypePrimary)
			{
				return Types.AttackType.Primary;
			}
			else if (str == Constants.AttackTypeSecondary)
			{
				return Types.AttackType.Secondary;
			}
			else if (str == Constants.AttackTypeRanged)
			{
				return Types.AttackType.Ranged;
			}
			else
			{
				throw new FormatException("Attack type \'" + str + "\' not recognised.");
			}
		}

		public static string GetDamageTypeString(Types.DamageType damageType)
		{
			switch (damageType)
			{
				case Types.DamageType.Fire:						return Constants.DamageTypeFire;
				case Types.DamageType.Cold:						return Constants.DamageTypeCold;
				case Types.DamageType.Electricity:		return Constants.DamageTypeElectricity;
				case Types.DamageType.Acid:						return Constants.DamageTypeAcid;
				case Types.DamageType.PositiveEnergy:	return Constants.DamageTypePositiveEnergy;
				case Types.DamageType.NegativeEnergy:	return Constants.DamageTypeNegativeEnergy;
				case Types.DamageType.Piercing:				return Constants.DamageTypePiercing;
				case Types.DamageType.Bludgeoning:		return Constants.DamageTypeBludgeoning;
				case Types.DamageType.Slashing:				return Constants.DamageTypeSlashing;
				case Types.DamageType.Force:					return Constants.DamageTypeForce;
				case Types.DamageType.Sonic:					return Constants.DamageTypeSonic;
				case Types.DamageType.Divine:					return Constants.DamageTypeDivine;
				case Types.DamageType.Subdual:				return Constants.DamageTypeSubdual;
				case Types.DamageType.Untyped:				return Constants.DamageTypeUntyped;
				default:															return "Unrecognised damage type";
			}
		}

		public static Types.DamageType GetDamageTypeFromString(string str)
		{
			if (str == Constants.DamageTypeFire)
			{
				return Types.DamageType.Fire;
			}
			else if (str == Constants.DamageTypeCold)
			{
				return Types.DamageType.Cold;
			}
			else if (str == Constants.DamageTypeElectricity)
			{
				return Types.DamageType.Electricity;
			}
			else if (str == Constants.DamageTypeAcid)
			{
				return Types.DamageType.Acid;
			}
			else if (str == Constants.DamageTypePositiveEnergy)
			{
				return Types.DamageType.PositiveEnergy;
			}
			else if (str == Constants.DamageTypeNegativeEnergy)
			{
				return Types.DamageType.NegativeEnergy;
			}
			else if (str == Constants.DamageTypePiercing)
			{
				return Types.DamageType.Piercing;
			}
			else if (str == Constants.DamageTypeBludgeoning)
			{
				return Types.DamageType.Bludgeoning;
			}
			else if (str == Constants.DamageTypeSlashing)
			{
				return Types.DamageType.Slashing;
			}
			else if (str == Constants.DamageTypeForce)
			{
				return Types.DamageType.Force;
			}
			else if (str == Constants.DamageTypeSonic)
			{
				return Types.DamageType.Sonic;
			}
			else if (str == Constants.DamageTypeDivine)
			{
				return Types.DamageType.Divine;
			}
			else if (str == Constants.DamageTypeSubdual)
			{
				return Types.DamageType.Subdual;
			}
			else if (str == Constants.DamageTypeUntyped)
			{
				return Types.DamageType.Untyped;
			}
			else
			{
				throw new FormatException("Damage type \'" + str + "\' not recognised.");
			}
		}

		public static List<string> GetDamageTypeStringList()
		{
			return new List<string> {
				Constants.DamageTypeAcid,
				Constants.DamageTypeBludgeoning,
				Constants.DamageTypeCold,
				Constants.DamageTypeDivine,
				Constants.DamageTypeElectricity,
				Constants.DamageTypeFire,
				Constants.DamageTypeForce,
				Constants.DamageTypeNegativeEnergy,
				Constants.DamageTypePiercing,
				Constants.DamageTypePositiveEnergy,
				Constants.DamageTypeSlashing,
				Constants.DamageTypeSonic,
				Constants.DamageTypeSubdual,
				Constants.DamageTypeUntyped
			};
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
	}
}
