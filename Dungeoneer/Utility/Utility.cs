using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Utility
{
	public class Constants
	{
		public static readonly string dieTypeD3 = "d3";
		public static readonly string dieTypeD4 = "d4";
		public static readonly string dieTypeD6 = "d6";
		public static readonly string dieTypeD8 = "d8";
		public static readonly string dieTypeD10 = "d10";
		public static readonly string dieTypeD12 = "d12";

		public static readonly string sizeFine = "Fine";
		public static readonly string sizeDiminuative = "Diminuative";
		public static readonly string sizeTiny = "Tiny";
		public static readonly string sizeSmall = "Small";
		public static readonly string sizeMedium = "Medium";
		public static readonly string sizeLarge = "Large";
		public static readonly string sizeHuge = "Huge";
		public static readonly string sizeGargantuan = "Gargantuan";
		public static readonly string sizeColossal = "Colossal";
		public static readonly string sizeColossalPlus = "Colossal+";

		public static readonly string attackTypePrimary = "Melee Primary";
		public static readonly string attackTypeSecondary = "Melee Secondary";
		public static readonly string attackTypeRanged = "Ranged";
		public static readonly string[] attackTypes =
		{
			attackTypePrimary,
			attackTypeSecondary,
			attackTypeRanged,
		};

		public static readonly string damageTypeFire = "Fire";
		public static readonly string damageTypeCold = "Cold";
		public static readonly string damageTypeElectricity = "Electricity";
		public static readonly string damageTypeAcid = "Acid";
		public static readonly string damageTypePositiveEnergy = "Positive Energy";
		public static readonly string damageTypeNegativeEnergy = "Negative Energy";
		public static readonly string damageTypePiercing = "Piercing";
		public static readonly string damageTypeBludgeoning = "Bludgeoning";
		public static readonly string damageTypeSlashing = "Slashing";
		public static readonly string damageTypeForce = "Force";
		public static readonly string damageTypeSonic = "Sonic";
		public static readonly string damageTypeDivine = "Divine";
		public static readonly string damageTypeSubdual = "Subdual";
		public static readonly string damageTypeUntyped = "Untyped";
	}

	public class Types
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

	public class Methods
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
				threatRange = Convert.ToString(minValue) + "-" + threatRange;
			}
			return threatRange;
		}

		public static string GetDieTypeString(Types.DieType dieType)
		{
			switch (dieType)
			{
				case Types.DieType.d3:	return Constants.dieTypeD3;
				case Types.DieType.d4:	return Constants.dieTypeD4;
				case Types.DieType.d6:	return Constants.dieTypeD6;
				case Types.DieType.d8:	return Constants.dieTypeD8;
				case Types.DieType.d10: return Constants.dieTypeD10;
				case Types.DieType.d12: return Constants.dieTypeD12;
				default: return "Unrecognised die type";
			}
		}

		public static Types.DieType GetDieTypeFromString(string str)
		{
			if (str == Constants.dieTypeD3)
			{
				return Types.DieType.d3;
			}
			else if (str == Constants.dieTypeD4)
			{
				return Types.DieType.d4;
			}
			else if (str == Constants.dieTypeD6)
			{
				return Types.DieType.d6;
			}
			else if (str == Constants.dieTypeD8)
			{
				return Types.DieType.d8;
			}
			else if (str == Constants.dieTypeD10)
			{
				return Types.DieType.d10;
			}
			else if (str == Constants.dieTypeD12)
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
				case Types.Size.Fine: return Constants.sizeFine;
				case Types.Size.Diminuative: return Constants.sizeDiminuative;
				case Types.Size.Tiny: return Constants.sizeTiny;
				case Types.Size.Small: return Constants.sizeSmall;
				case Types.Size.Medium: return Constants.sizeMedium;
				case Types.Size.Large: return Constants.sizeLarge;
				case Types.Size.Huge: return Constants.sizeHuge;
				case Types.Size.Gargantuan: return Constants.sizeGargantuan;
				case Types.Size.Colossal: return Constants.sizeColossal;
				case Types.Size.ColossalPlus: return Constants.sizeColossalPlus;
				default: return "Unrecognised size";
			}
		}

		public static Types.Size GetSizeFromString(string str)
		{
			if (str == Constants.sizeFine)
			{
				return Types.Size.Fine;
			}
			else if (str == Constants.sizeDiminuative)
			{
				return Types.Size.Diminuative;
			}
			else if (str == Constants.sizeTiny)
			{
				return Types.Size.Tiny;
			}
			else if (str == Constants.sizeSmall)
			{
				return Types.Size.Small;
			}
			else if (str == Constants.sizeMedium)
			{
				return Types.Size.Medium;
			}
			else if (str == Constants.sizeLarge)
			{
				return Types.Size.Large;
			}
			else if (str == Constants.sizeHuge)
			{
				return Types.Size.Huge;
			}
			else if (str == Constants.sizeGargantuan)
			{
				return Types.Size.Gargantuan;
			}
			else if (str == Constants.sizeColossal)
			{
				return Types.Size.Colossal;
			}
			else if (str == Constants.sizeColossalPlus)
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
				case Types.AttackType.Primary:		return Constants.attackTypePrimary;
				case Types.AttackType.Secondary:	return Constants.attackTypeSecondary;
				case Types.AttackType.Ranged:			return Constants.attackTypeRanged;
				default: return "Unrecognised attack type";
			}
		}

		public static Types.AttackType GetAttackTypeFromString(string str)
		{
			if (str == Constants.attackTypePrimary)
			{
				return Types.AttackType.Primary;
			}
			else if (str == Constants.attackTypeSecondary)
			{
				return Types.AttackType.Secondary;
			}
			else if (str == Constants.attackTypeRanged)
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
				case Types.DamageType.Fire:						return Constants.damageTypeFire;
				case Types.DamageType.Cold:						return Constants.damageTypeCold;
				case Types.DamageType.Electricity:		return Constants.damageTypeElectricity;
				case Types.DamageType.Acid:						return Constants.damageTypeAcid;
				case Types.DamageType.PositiveEnergy:	return Constants.damageTypePositiveEnergy;
				case Types.DamageType.NegativeEnergy:	return Constants.damageTypeNegativeEnergy;
				case Types.DamageType.Piercing:				return Constants.damageTypePiercing;
				case Types.DamageType.Bludgeoning:		return Constants.damageTypeBludgeoning;
				case Types.DamageType.Slashing:				return Constants.damageTypeSlashing;
				case Types.DamageType.Force:					return Constants.damageTypeForce;
				case Types.DamageType.Sonic:					return Constants.damageTypeSonic;
				case Types.DamageType.Divine:					return Constants.damageTypeDivine;
				case Types.DamageType.Subdual:				return Constants.damageTypeSubdual;
				case Types.DamageType.Untyped:				return Constants.damageTypeUntyped;
				default:															return "Unrecognised damage type";
			}
		}

		public static Types.DamageType GetDamageTypeFromString(string str)
		{
			if (str == Constants.damageTypeFire)
			{
				return Types.DamageType.Fire;
			}
			else if (str == Constants.damageTypeCold)
			{
				return Types.DamageType.Cold;
			}
			else if (str == Constants.damageTypeElectricity)
			{
				return Types.DamageType.Electricity;
			}
			else if (str == Constants.damageTypeAcid)
			{
				return Types.DamageType.Acid;
			}
			else if (str == Constants.damageTypePositiveEnergy)
			{
				return Types.DamageType.PositiveEnergy;
			}
			else if (str == Constants.damageTypeNegativeEnergy)
			{
				return Types.DamageType.NegativeEnergy;
			}
			else if (str == Constants.damageTypePiercing)
			{
				return Types.DamageType.Piercing;
			}
			else if (str == Constants.damageTypeBludgeoning)
			{
				return Types.DamageType.Bludgeoning;
			}
			else if (str == Constants.damageTypeSlashing)
			{
				return Types.DamageType.Slashing;
			}
			else if (str == Constants.damageTypeForce)
			{
				return Types.DamageType.Force;
			}
			else if (str == Constants.damageTypeSonic)
			{
				return Types.DamageType.Sonic;
			}
			else if (str == Constants.damageTypeDivine)
			{
				return Types.DamageType.Divine;
			}
			else if (str == Constants.damageTypeSubdual)
			{
				return Types.DamageType.Subdual;
			}
			else if (str == Constants.damageTypeUntyped)
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
				Constants.damageTypeAcid,
				Constants.damageTypeBludgeoning,
				Constants.damageTypeCold,
				Constants.damageTypeDivine,
				Constants.damageTypeElectricity,
				Constants.damageTypeFire,
				Constants.damageTypeForce,
				Constants.damageTypeNegativeEnergy,
				Constants.damageTypePiercing,
				Constants.damageTypePositiveEnergy,
				Constants.damageTypeSlashing,
				Constants.damageTypeSonic,
				Constants.damageTypeSubdual,
				Constants.damageTypeUntyped
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

		public static int CalculateNewHitPoints(Model.Creature creature, int damage, Utility.Types.DamageType damageType)
		{
			Model.DamageReduction dr = creature.DamageReductions?.SingleOrDefault(i => i.DamageType == damageType);

			if (dr != null)
			{
				damage -= dr.Value;

				if (damage < 0)
				{
					damage = 0;
				}
			}

			return creature.HitPoints - damage;
		}
	}
}
