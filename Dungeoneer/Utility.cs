using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer
{
	public class Utility
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

		public enum DieType
		{
			d3,
			d4,
			d6,
			d8,
			d10,
			d12,
		};

		public static readonly string dieTypeD3 = "d3";
		public static readonly string dieTypeD4 = "d4";
		public static readonly string dieTypeD6 = "d6";
		public static readonly string dieTypeD8 = "d8";
		public static readonly string dieTypeD10 = "d10";
		public static readonly string dieTypeD12 = "d12";

		public static string GetDieTypeString(DieType dieType)
		{
			switch (dieType)
			{
				case DieType.d3:	return dieTypeD3;
				case DieType.d4:	return dieTypeD4;
				case DieType.d6:	return dieTypeD6;
				case DieType.d8:	return dieTypeD8;
				case DieType.d10: return dieTypeD10;
				case DieType.d12: return dieTypeD12;
				default: return "Unrecognised die type";
			}
		}

		public static DieType GetDieTypeFromString(string str)
		{
			if (str == dieTypeD3)
			{
				return DieType.d3;
			}
			if (str == dieTypeD4)
			{
				return DieType.d4;
			}
			if (str == dieTypeD6)
			{
				return DieType.d6;
			}
			if (str == dieTypeD8)
			{
				return DieType.d8;
			}
			if (str == dieTypeD10)
			{
				return DieType.d10;
			}
			else
			{
				return DieType.d12;
			}
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

		public static string GetSizeString(Size size)
		{
			switch (size)
			{
				case Size.Fine: return sizeFine;
				case Size.Diminuative: return sizeDiminuative;
				case Size.Tiny: return sizeTiny;
				case Size.Small: return sizeSmall;
				case Size.Medium: return sizeMedium;
				case Size.Large: return sizeLarge;
				case Size.Huge: return sizeHuge;
				case Size.Gargantuan: return sizeGargantuan;
				case Size.Colossal: return sizeColossal;
				case Size.ColossalPlus: return sizeColossalPlus;

				default: return "Unrecognised size";
			}
		}

		public static Size GetSizeFromString(string str)
		{
			if (str == sizeFine)
			{
				return Size.Fine;
			}
			else if (str == sizeDiminuative)
			{
				return Size.Diminuative;
			}
			else if (str == sizeTiny)
			{
				return Size.Tiny;
			}
			else if (str == sizeSmall)
			{
				return Size.Small;
			}
			else if (str == sizeMedium)
			{
				return Size.Medium;
			}
			else if (str == sizeLarge)
			{
				return Size.Large;
			}
			else if (str == sizeHuge)
			{
				return Size.Huge;
			}
			else if (str == sizeGargantuan)
			{
				return Size.Gargantuan;
			}
			else if (str == sizeColossal)
			{
				return Size.Colossal;
			}
			else
			{
				return Size.ColossalPlus;
			}
		}

		public enum AttackType
		{
			Primary,
			Secondary,
			Ranged,
		}

		public static readonly string attackTypePrimary = "Melee Primary";
		public static readonly string attackTypeSecondary = "Melee Secondary";
		public static readonly string attackTypeRanged = "Ranged";
		public static readonly string[] attackTypes =
		{
			attackTypePrimary,
			attackTypeSecondary,
			attackTypeRanged,
		};

		public static string GetAttackTypeString(AttackType attackType)
		{
			switch (attackType)
			{
				case AttackType.Primary:		return attackTypePrimary;
				case AttackType.Secondary:	return attackTypeSecondary;
				case AttackType.Ranged:			return attackTypeRanged;
				default: return "Unrecognised attack type";
			}
		}

		public static AttackType GetAttackTypeFromString(string str)
		{
			if (str == attackTypeSecondary)
			{
				return AttackType.Secondary;
			}
			else if (str == attackTypeRanged)
			{
				return AttackType.Ranged;
			}
			else
			{
				return AttackType.Primary;
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
