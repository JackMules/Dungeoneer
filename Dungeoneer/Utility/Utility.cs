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

		public static readonly string AbilityStrength = "Strength";
		public static readonly string AbilityDexterity = "Dexterity";
		public static readonly string AbilityConstitution = "Constitution";
		public static readonly string AbilityIntelligence = "Intelligence";
		public static readonly string AbilityWisdom = "Wisdom";
		public static readonly string AbilityCharisma = "Charisma";

		public static readonly string EffectDamagePerTurn = "Damage Per Turn";
		public static readonly string EffectTimedDamagePerTurn = "Timed Damage Per Turn";
		public static readonly string EffectEnergyResistance = "";
		public static readonly string EffectBlinded = "Blinded";
		public static readonly string EffectConfused = "Confused";
		public static readonly string EffectCowering = "Cowering";
		public static readonly string EffectDazed = "Dazed";
		public static readonly string EffectDazzled = "Dazzled";
		public static readonly string EffectDead = "Dead";
		public static readonly string EffectDeafened = "Deafened";
		public static readonly string EffectDisabled = "Disabled";
		public static readonly string EffectDying = "Dying";
		public static readonly string EffectEnergyDrained = "EnergyDrained";
		public static readonly string EffectEntangled = "Entangled";
		public static readonly string EffectExhausted = "Exhausted";
		public static readonly string EffectFascinated = "Fascinated";
		public static readonly string EffectFatigued = "Fatigued";
		public static readonly string EffectFlatFooted = "FlatFooted";
		public static readonly string EffectFrightened = "Frightened";
		public static readonly string EffectGrappling = "Grappling";
		public static readonly string EffectHelpless = "Helpless";
		public static readonly string EffectIncorporeal = "Incorporeal";
		public static readonly string EffectInvisible = "Invisible";
		public static readonly string EffectKnockedDown = "KnockedDown";
		public static readonly string EffectNauseated = "Nauseated";
		public static readonly string EffectPanicked = "Panicked";
		public static readonly string EffectParalysed = "Paralysed";
		public static readonly string EffectPetrified = "Petrified";
		public static readonly string EffectPinned = "Pinned";
		public static readonly string EffectProne = "Prone";
		public static readonly string EffectShaken = "Shaken";
		public static readonly string EffectSickened = "Sickened";
		public static readonly string EffectStable = "Stable";
		public static readonly string EffectStaggered = "Staggered";
		public static readonly string EffectStunned = "Stunned";
		public static readonly string EffectTurned = "Turned";
		public static readonly string EffectUnconscious = "Unconscious";

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

		public static readonly List<string> AbilityStrings = new List<string>
		{
			Methods.GetAbilityString(Types.Ability.Strength),
			Methods.GetAbilityString(Types.Ability.Dexterity),
			Methods.GetAbilityString(Types.Ability.Constitution),
			Methods.GetAbilityString(Types.Ability.Intelligence),
			Methods.GetAbilityString(Types.Ability.Wisdom),
			Methods.GetAbilityString(Types.Ability.Charisma),
		};

		public static readonly List<string> EffectStrings = new List<string>
		{
			Methods.GetEffectTypeString(Types.Effect.DamagePerTurn),
			Methods.GetEffectTypeString(Types.Effect.TimedDamagePerTurn),
			Methods.GetEffectTypeString(Types.Effect.EnergyResistance),
			Methods.GetEffectTypeString(Types.Effect.Blinded),
			Methods.GetEffectTypeString(Types.Effect.Confused),
			Methods.GetEffectTypeString(Types.Effect.Cowering),
			Methods.GetEffectTypeString(Types.Effect.Dazed),
			Methods.GetEffectTypeString(Types.Effect.Dazzled),
			Methods.GetEffectTypeString(Types.Effect.Dead),
			Methods.GetEffectTypeString(Types.Effect.Deafened),
			Methods.GetEffectTypeString(Types.Effect.Disabled),
			Methods.GetEffectTypeString(Types.Effect.Dying),
			Methods.GetEffectTypeString(Types.Effect.EnergyDrained),
			Methods.GetEffectTypeString(Types.Effect.Entangled),
			Methods.GetEffectTypeString(Types.Effect.Exhausted),
			Methods.GetEffectTypeString(Types.Effect.Fascinated),
			Methods.GetEffectTypeString(Types.Effect.Fatigued),
			Methods.GetEffectTypeString(Types.Effect.FlatFooted),
			Methods.GetEffectTypeString(Types.Effect.Frightened),
			Methods.GetEffectTypeString(Types.Effect.Grappling),
			Methods.GetEffectTypeString(Types.Effect.Helpless),
			Methods.GetEffectTypeString(Types.Effect.Incorporeal),
			Methods.GetEffectTypeString(Types.Effect.Invisible),
			Methods.GetEffectTypeString(Types.Effect.KnockedDown),
			Methods.GetEffectTypeString(Types.Effect.Nauseated),
			Methods.GetEffectTypeString(Types.Effect.Panicked),
			Methods.GetEffectTypeString(Types.Effect.Paralysed),
			Methods.GetEffectTypeString(Types.Effect.Petrified),
			Methods.GetEffectTypeString(Types.Effect.Pinned),
			Methods.GetEffectTypeString(Types.Effect.Prone),
			Methods.GetEffectTypeString(Types.Effect.Shaken),
			Methods.GetEffectTypeString(Types.Effect.Sickened),
			Methods.GetEffectTypeString(Types.Effect.Stable),
			Methods.GetEffectTypeString(Types.Effect.Staggered),
			Methods.GetEffectTypeString(Types.Effect.Stunned),
			Methods.GetEffectTypeString(Types.Effect.Turned),
			Methods.GetEffectTypeString(Types.Effect.Unconscious),
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
			EnergyResistance,
			Blinded,
			Confused,
			Cowering,
			Dazed,
			Dazzled,
			Dead,
			Deafened,
			Disabled,
			Dying,
			EnergyDrained,
			Entangled,
			Exhausted,
			Fascinated,
			Fatigued,
			FlatFooted,
			Frightened,
			Grappling,
			Helpless,
			Incorporeal,
			Invisible,
			KnockedDown,
			Nauseated,
			Panicked, 
			Paralysed,
			Petrified,
			Pinned, 
			Prone,
			Shaken,
			Sickened,
			Stable,
			Staggered,
			Stunned,
			Turned,
			Unconscious,
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
				damageStrings.Add(damage.NumDice.ToString() + GetDieTypeString(damage.Die) + GetSignedNumberString(damage.Modifier) + " " + damage.DamageDescriptorSet.ToString());
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
				default:						return "Unrecognised die type";
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
				case Types.Size.Fine:					return Constants.SizeFine;
				case Types.Size.Diminuative:	return Constants.SizeDiminuative;
				case Types.Size.Tiny:					return Constants.SizeTiny;
				case Types.Size.Small:				return Constants.SizeSmall;
				case Types.Size.Medium:				return Constants.SizeMedium;
				case Types.Size.Large:				return Constants.SizeLarge;
				case Types.Size.Huge:					return Constants.SizeHuge;
				case Types.Size.Gargantuan:		return Constants.SizeGargantuan;
				case Types.Size.Colossal:			return Constants.SizeColossal;
				case Types.Size.ColossalPlus: return Constants.SizeColossalPlus;
				default:											return "Unrecognised size";
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

		public static string GetAbilityString(Types.Ability ability)
		{
			switch (ability)
			{
			case Types.Ability.Strength:			return Constants.AbilityStrength;
			case Types.Ability.Dexterity:			return Constants.AbilityDexterity;
			case Types.Ability.Constitution:	return Constants.AbilityConstitution;
			case Types.Ability.Intelligence:	return Constants.AbilityIntelligence;
			case Types.Ability.Wisdom:				return Constants.AbilityWisdom;
			case Types.Ability.Charisma:			return Constants.AbilityCharisma;
			default:													return "Unrecognised ability";
			}
		}

		public static Types.Ability GetAbilityFromString(string str)
		{
			if (str == Constants.AbilityStrength)
			{
				return Types.Ability.Strength;
			}
			else if (str == Constants.AbilityDexterity)
			{
				return Types.Ability.Dexterity;
			}
			else if (str == Constants.AbilityConstitution)
			{
				return Types.Ability.Constitution;
			}
			else if (str == Constants.AbilityIntelligence)
			{
				return Types.Ability.Intelligence;
			}
			else if (str == Constants.AbilityWisdom)
			{
				return Types.Ability.Wisdom;
			}
			else if (str == Constants.AbilityCharisma)
			{
				return Types.Ability.Charisma;
			}
			else
			{
				throw new FormatException("Ability \'" + str + "\' not recognised.");
			}
		}

		public static string GetEffectTypeString(Types.Effect effect)
		{
			switch (effect)
			{
			case Types.Effect.DamagePerTurn:			return Constants.EffectDamagePerTurn;
			case Types.Effect.TimedDamagePerTurn:	return Constants.EffectTimedDamagePerTurn;
			case Types.Effect.EnergyResistance:		return Constants.EffectEnergyResistance;
			case Types.Effect.Blinded:						return Constants.EffectBlinded;
			case Types.Effect.Confused:						return Constants.EffectConfused;
			case Types.Effect.Cowering:						return Constants.EffectCowering;
			case Types.Effect.Dazed:							return Constants.EffectDazed;
			case Types.Effect.Dazzled:						return Constants.EffectDazzled;
			case Types.Effect.Dead:								return Constants.EffectDead;
			case Types.Effect.Deafened:						return Constants.EffectDeafened;
			case Types.Effect.Disabled:						return Constants.EffectDisabled;
			case Types.Effect.Dying:							return Constants.EffectDying;
			case Types.Effect.EnergyDrained:			return Constants.EffectEnergyDrained;
			case Types.Effect.Entangled:					return Constants.EffectEntangled;
			case Types.Effect.Exhausted:					return Constants.EffectExhausted;
			case Types.Effect.Fascinated:					return Constants.EffectFascinated;
			case Types.Effect.Fatigued:						return Constants.EffectFatigued;
			case Types.Effect.FlatFooted:					return Constants.EffectFlatFooted;
			case Types.Effect.Frightened:					return Constants.EffectFrightened;
			case Types.Effect.Grappling:					return Constants.EffectGrappling;
			case Types.Effect.Helpless:						return Constants.EffectHelpless;
			case Types.Effect.Incorporeal:				return Constants.EffectIncorporeal;
			case Types.Effect.Invisible:					return Constants.EffectInvisible;
			case Types.Effect.KnockedDown:				return Constants.EffectKnockedDown;
			case Types.Effect.Nauseated:					return Constants.EffectNauseated;
			case Types.Effect.Panicked:						return Constants.EffectPanicked;
			case Types.Effect.Paralysed:					return Constants.EffectParalysed;
			case Types.Effect.Petrified:					return Constants.EffectPetrified;
			case Types.Effect.Pinned:							return Constants.EffectPinned;
			case Types.Effect.Prone:							return Constants.EffectProne;
			case Types.Effect.Shaken:							return Constants.EffectShaken;
			case Types.Effect.Sickened:						return Constants.EffectSickened;
			case Types.Effect.Stable:							return Constants.EffectStable;
			case Types.Effect.Staggered:					return Constants.EffectStaggered;
			case Types.Effect.Stunned:						return Constants.EffectStunned;
			case Types.Effect.Turned:							return Constants.EffectTurned;
			case Types.Effect.Unconscious:				return Constants.EffectUnconscious;
			default:															return "Unrecognised effect type";
			}
		}

		public static Types.Effect GetEffectTypeFromString(string effect)
		{
			if (effect == Constants.EffectDamagePerTurn)
			{
				return Types.Effect.DamagePerTurn;
			}
			else if (effect == Constants.EffectTimedDamagePerTurn)
			{
				return Types.Effect.TimedDamagePerTurn;
			}
			else if (effect == Constants.EffectEnergyResistance)
			{
				return Types.Effect.EnergyResistance;
			}
			else if (effect == Constants.EffectBlinded)
			{
				return Types.Effect.Blinded;
			}
			else if (effect == Constants.EffectConfused)
			{
				return Types.Effect.Confused;
			}
			else if (effect == Constants.EffectCowering)
			{
				return Types.Effect.Cowering;
			}
			else if (effect == Constants.EffectDazed)
			{
				return Types.Effect.Dazed;
			}
			else if (effect == Constants.EffectDazzled)
			{
				return Types.Effect.Dazzled;
			}
			else if (effect == Constants.EffectDead)
			{
				return Types.Effect.Dead;
			}
			else if (effect == Constants.EffectDeafened)
			{
				return Types.Effect.Deafened;
			}
			else if (effect == Constants.EffectDisabled)
			{
				return Types.Effect.Disabled;
			}
			else if (effect == Constants.EffectDying)
			{
				return Types.Effect.Dying;
			}
			else if (effect == Constants.EffectEnergyDrained)
			{
				return Types.Effect.EnergyDrained;
			}
			else if (effect == Constants.EffectEntangled)
			{
				return Types.Effect.Entangled;
			}
			else if (effect == Constants.EffectExhausted)
			{
				return Types.Effect.Exhausted;
			}
			else if (effect == Constants.EffectFascinated)
			{
				return Types.Effect.Fascinated;
			}
			else if (effect == Constants.EffectFatigued)
			{
				return Types.Effect.Fatigued;
			}
			else if (effect == Constants.EffectFlatFooted)
			{
				return Types.Effect.FlatFooted;
			}
			else if (effect == Constants.EffectFrightened)
			{
				return Types.Effect.Frightened;
			}
			else if (effect == Constants.EffectGrappling)
			{
				return Types.Effect.Grappling;
			}
			else if (effect == Constants.EffectHelpless)
			{
				return Types.Effect.Helpless;
			}
			else if (effect == Constants.EffectIncorporeal)
			{
				return Types.Effect.Incorporeal;
			}
			else if (effect == Constants.EffectInvisible)
			{
				return Types.Effect.Invisible;
			}
			else if (effect == Constants.EffectKnockedDown)
			{
				return Types.Effect.KnockedDown;
			}
			else if (effect == Constants.EffectNauseated)
			{
				return Types.Effect.Nauseated;
			}
			else if (effect == Constants.EffectPanicked)
			{
				return Types.Effect.Panicked;
			}
			else if (effect == Constants.EffectParalysed)
			{
				return Types.Effect.Paralysed;
			}
			else if (effect == Constants.EffectPetrified)
			{
				return Types.Effect.Petrified;
			}
			else if (effect == Constants.EffectPinned)
			{
				return Types.Effect.Pinned;
			}
			else if (effect == Constants.EffectProne)
			{
				return Types.Effect.Prone;
			}
			else if (effect == Constants.EffectShaken)
			{
				return Types.Effect.Shaken;
			}
			else if (effect == Constants.EffectSickened)
			{
				return Types.Effect.Sickened;
			}
			else if (effect == Constants.EffectStable)
			{
				return Types.Effect.Stable;
			}
			else if (effect == Constants.EffectStaggered)
			{
				return Types.Effect.Staggered;
			}
			else if (effect == Constants.EffectStunned)
			{
				return Types.Effect.Stunned;
			}
			else if (effect == Constants.EffectTurned)
			{
				return Types.Effect.Turned;
			}
			else if (effect == Constants.EffectUnconscious)
			{
				return Types.Effect.Unconscious;
			}
			else
			{
				throw new FormatException("Effect type \'" + effect + "\' not recognised");
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
				default:														return "Unrecognised attack type";
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
			case Types.Damage.Magic:					return Constants.DamageTypeMagic;
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
			else if (str == Constants.DamageTypeMagic)
			{
				return Types.Damage.Magic;
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

		public static Model.Creature DoDamage(Model.Creature creature, List<int> damages, Model.Weapon weapon, ref FullyObservableCollection<Model.Effect.Effect> effects)
		{
			creature = DoHitPointDamage(creature, damages, weapon, ref effects);

			if (weapon.AbilityDamage)
			{
				creature = DoAbilityDamage(creature, weapon.AbilityDamageValue, weapon.Ability);
			}

			return creature;
		}

		public static Model.Creature DoHitPointDamage(Model.Creature creature, List<int> damages, Model.Weapon weapon, ref FullyObservableCollection<Model.Effect.Effect> effects)
		{
			for (int d = 0; d < damages.Count; ++d)
			{
				foreach (Model.Effect.Effect effect in effects)
				{
					if (effect is Model.Effect.EnergyResistance)
					{
						Model.Effect.EnergyResistance energyResistance = effect as Model.Effect.EnergyResistance;
						if (weapon.DamageDescriptorSets[d].Contains(energyResistance.EnergyType) &&
							weapon.DamageDescriptorSets[d].Count == 1)
						{
							int newEnergyResistanceValue = energyResistance.Value - damages[d];
							if (newEnergyResistanceValue > 0)
							{
								damages[d] = 0;
								energyResistance.Value = newEnergyResistanceValue;
							}
							else
							{
								damages[d] = newEnergyResistanceValue * -1;
								energyResistance.Value = 0;
							}
						}
					}
				}
			}

			List<Model.DamageReduction> damageReductions = creature.DamageReductions.ToList();
			damageReductions.Sort((dr1, dr2) => dr2.Value.CompareTo(dr1.Value));

			for (int d = 0; d < damages.Count; ++d)
			{
				foreach (Model.DamageReduction dr in damageReductions)
				{
					bool bypassed = true;
					foreach (Types.Damage drDamageType in dr.DamageTypes)
					{
						bool matched = weapon.DamageDescriptorSets[d].Contains(drDamageType);

						// If none of the weapon's damage qualities match this part of the damage type, then 
						if (!matched)
						{
							bypassed = false;
							break;
						}
					}

					if (!bypassed)
					{
						damages[d] -= dr.Value;
						break;
					}
				}
				if (damages[d] < 0)
				{
					damages[d] = 0;
				}
			}

			foreach (int damage in damages)
			{
				creature.HitPoints -= damage;
			}

			return creature;
		}
		
		public static Model.Creature DoAbilityDamage(Model.Creature creature, int damage, Types.Ability ability)
		{
			if (ability == Types.Ability.Constitution)
			{
				int oldModifier = GetAbilityModifier(creature.Constitution);
				creature.Constitution -= damage;
				int newModifier = GetAbilityModifier(creature.Constitution);

				int change = oldModifier - newModifier;
				creature.HitPoints -= creature.HitDice * change;
			}

			return creature;
		}

		public static int GetAbilityModifier(int abilityScore)
		{
			return (abilityScore - 10) / 2;
		}
	}
}
