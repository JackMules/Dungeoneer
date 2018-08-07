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
	}

	public class Methods
	{
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
			if (str == Constants.dieTypeD4)
			{
				return Types.DieType.d4;
			}
			if (str == Constants.dieTypeD6)
			{
				return Types.DieType.d6;
			}
			if (str == Constants.dieTypeD8)
			{
				return Types.DieType.d8;
			}
			if (str == Constants.dieTypeD10)
			{
				return Types.DieType.d10;
			}
			else
			{
				return Types.DieType.d12;
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
			else
			{
				return Types.Size.ColossalPlus;
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
			if (str == Constants.attackTypeSecondary)
			{
				return Types.AttackType.Secondary;
			}
			else if (str == Constants.attackTypeRanged)
			{
				return Types.AttackType.Ranged;
			}
			else
			{
				return Types.AttackType.Primary;
			}
		}

		public static uint CalculateXP(uint challengeRating)
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
