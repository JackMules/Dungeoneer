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

		public static readonly string AttackTypeMelee = "melee";
		public static readonly string AttackTypeRanged = "ranged";
		public static readonly string AttackTypeMeleeTouch = "melee touch";
		public static readonly string AttackTypeRangedTouch = "ranged touch";
		public static readonly string AttackTypeIncorporealTouch = "incorporeal touch";

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
		public static readonly string EffectAbilityModifier = "Ability Modifier";
		public static readonly string EffectBlinded = "Blinded";
		public static readonly string EffectConfused = "Confused";
		public static readonly string EffectCowering = "Cowering";
		public static readonly string EffectCustom = "Custom";
		public static readonly string EffectDazed = "Dazed";
		public static readonly string EffectDazzled = "Dazzled";
		public static readonly string EffectDeafened = "Deafened";
		public static readonly string EffectDisabled = "Disabled";
		public static readonly string EffectDying = "Dying";
		public static readonly string EffectNegativeLevel = "Negative Level";
		public static readonly string EffectEntangled = "Entangled";
		public static readonly string EffectExhausted = "Exhausted";
		public static readonly string EffectFascinated = "Fascinated";
		public static readonly string EffectFastHealing = "Fast Healing";
		public static readonly string EffectFatigued = "Fatigued";
		public static readonly string EffectFlatFooted = "Flat-Footed";
		public static readonly string EffectFrightened = "Frightened";
		public static readonly string EffectGrappling = "Grappling";
		public static readonly string EffectHelpless = "Helpless";
		public static readonly string EffectIncorporeal = "Incorporeal";
		public static readonly string EffectInvisible = "Invisible";
		public static readonly string EffectNauseated = "Nauseated";
		public static readonly string EffectPanicked = "Panicked";
		public static readonly string EffectParalysed = "Paralysed";
		public static readonly string EffectPetrified = "Petrified";
		public static readonly string EffectPinned = "Pinned";
		public static readonly string EffectPowerAttack = "Power Attack";
		public static readonly string EffectProne = "Prone";
		public static readonly string EffectRaging = "Raging";
		public static readonly string EffectShaken = "Shaken";
		public static readonly string EffectSickened = "Sickened";
		public static readonly string EffectStable = "Stable";
		public static readonly string EffectStaggered = "Staggered";
		public static readonly string EffectStunned = "Stunned";
		public static readonly string EffectTurned = "Turned";
		public static readonly string EffectUnconscious = "Unconscious";

		public static readonly string TurnStateNotStarted = "Not Started";
		public static readonly string TurnStateStarted = "Started";
		public static readonly string TurnStateEnded = "Ended";

		public static readonly string ManouverabilityPerfect = "Perfect";
		public static readonly string ManouverabilityGood = "Good";
		public static readonly string ManouverabilityAverage = "Average";
		public static readonly string ManouverabilityPoor = "Poor";
		public static readonly string ManouverabilityClumsy = "Clumsy";
		public static readonly string ManouverabilityNone = "None";

		public static readonly string MovementBurrow = "Burrow";
		public static readonly string MovementClimb = "Climb";
		public static readonly string MovementFly = "Fly";
		public static readonly string MovementSwim = "Swim";

		public static readonly string CreatureAberration = "Aberration";
		public static readonly string CreatureAnimal = "Animal";
		public static readonly string CreatureConstruct = "Construct";
		public static readonly string CreatureDragon = "Dragon";
		public static readonly string CreatureElemental = "Elemental";
		public static readonly string CreatureFey = "Fey";
		public static readonly string CreatureGiant = "Giant";
		public static readonly string CreatureHumanoid = "Humanoid";
		public static readonly string CreatureMagicalBeast = "Magical Beast";
		public static readonly string CreatureMonstrousHumanoid = "Monstrous Humanoid";
		public static readonly string CreatureOoze = "Ooze";
		public static readonly string CreatureOutsider = "Outsider";
		public static readonly string CreaturePlant = "Plant";
		public static readonly string CreatureUndead = "Undead";
		public static readonly string CreatureVermin = "Vermin";

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
			Methods.GetAttackTypeString(Types.Attack.Melee),
			Methods.GetAttackTypeString(Types.Attack.Ranged),
			Methods.GetAttackTypeString(Types.Attack.MeleeTouch),
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
			Methods.GetEffectTypeString(Types.Effect.AbilityModifier),
			Methods.GetEffectTypeString(Types.Effect.Blinded),
			Methods.GetEffectTypeString(Types.Effect.Confused),
			Methods.GetEffectTypeString(Types.Effect.Cowering),
			Methods.GetEffectTypeString(Types.Effect.Custom),
			Methods.GetEffectTypeString(Types.Effect.Dazed),
			Methods.GetEffectTypeString(Types.Effect.Dazzled),
			Methods.GetEffectTypeString(Types.Effect.Deafened),
			Methods.GetEffectTypeString(Types.Effect.Disabled),
			Methods.GetEffectTypeString(Types.Effect.Dying),
			Methods.GetEffectTypeString(Types.Effect.NegativeLevel),
			Methods.GetEffectTypeString(Types.Effect.Entangled),
			Methods.GetEffectTypeString(Types.Effect.Exhausted),
			Methods.GetEffectTypeString(Types.Effect.Fascinated),
			Methods.GetEffectTypeString(Types.Effect.FastHealing),
			Methods.GetEffectTypeString(Types.Effect.Fatigued),
			Methods.GetEffectTypeString(Types.Effect.FlatFooted),
			Methods.GetEffectTypeString(Types.Effect.Frightened),
			Methods.GetEffectTypeString(Types.Effect.Grappling),
			Methods.GetEffectTypeString(Types.Effect.Helpless),
			Methods.GetEffectTypeString(Types.Effect.Incorporeal),
			Methods.GetEffectTypeString(Types.Effect.Invisible),
			Methods.GetEffectTypeString(Types.Effect.Nauseated),
			Methods.GetEffectTypeString(Types.Effect.Panicked),
			Methods.GetEffectTypeString(Types.Effect.Paralysed),
			Methods.GetEffectTypeString(Types.Effect.Petrified),
			Methods.GetEffectTypeString(Types.Effect.Pinned),
			Methods.GetEffectTypeString(Types.Effect.PowerAttack),
			Methods.GetEffectTypeString(Types.Effect.Prone),
			Methods.GetEffectTypeString(Types.Effect.Raging),
			Methods.GetEffectTypeString(Types.Effect.Shaken),
			Methods.GetEffectTypeString(Types.Effect.Sickened),
			Methods.GetEffectTypeString(Types.Effect.Stable),
			Methods.GetEffectTypeString(Types.Effect.Staggered),
			Methods.GetEffectTypeString(Types.Effect.Stunned),
			Methods.GetEffectTypeString(Types.Effect.Turned),
			Methods.GetEffectTypeString(Types.Effect.Unconscious),
		};

		public static List<string> EnergyTypeStrings = new List<string>
		{
			Methods.GetDamageTypeString(Types.Damage.Acid),
			Methods.GetDamageTypeString(Types.Damage.Cold),
			Methods.GetDamageTypeString(Types.Damage.Electricity),
			Methods.GetDamageTypeString(Types.Damage.Fire),
			Methods.GetDamageTypeString(Types.Damage.Sonic),
		};

		public static List<string> ManouverabilityStrings = new List<string>
		{
			 Methods.GetManouverabilityString(Types.Manouverability.Perfect),
			 Methods.GetManouverabilityString(Types.Manouverability.Good),
			 Methods.GetManouverabilityString(Types.Manouverability.Average),
			 Methods.GetManouverabilityString(Types.Manouverability.Poor),
			 Methods.GetManouverabilityString(Types.Manouverability.Clumsy),
			 Methods.GetManouverabilityString(Types.Manouverability.None),
		};

		public static List<string> MovementTypeStrings = new List<string>
		{
			 Methods.GetMovementTypeString(Types.Movement.Burrow),
			 Methods.GetMovementTypeString(Types.Movement.Climb),
			 Methods.GetMovementTypeString(Types.Movement.Fly),
			 Methods.GetMovementTypeString(Types.Movement.Swim),
		};

		public static List<string> CreatureTypeStrings = new List<string>
		{
			Methods.GetCreatureTypeString(Types.Creature.Aberration),
			Methods.GetCreatureTypeString(Types.Creature.Animal),
			Methods.GetCreatureTypeString(Types.Creature.Construct),
			Methods.GetCreatureTypeString(Types.Creature.Dragon),
			Methods.GetCreatureTypeString(Types.Creature.Elemental),
			Methods.GetCreatureTypeString(Types.Creature.Fey),
			Methods.GetCreatureTypeString(Types.Creature.Giant),
			Methods.GetCreatureTypeString(Types.Creature.Humanoid),
			Methods.GetCreatureTypeString(Types.Creature.MagicalBeast),
			Methods.GetCreatureTypeString(Types.Creature.MonstrousHumanoid),
			Methods.GetCreatureTypeString(Types.Creature.Ooze),
			Methods.GetCreatureTypeString(Types.Creature.Outsider),
			Methods.GetCreatureTypeString(Types.Creature.Plant),
			Methods.GetCreatureTypeString(Types.Creature.Undead),
			Methods.GetCreatureTypeString(Types.Creature.Vermin),
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
			Melee,
			Ranged,
			MeleeTouch,
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
			AbilityModifier,
			Blinded,
			Confused,
			Cowering,
			Custom,
			Dazed,
			Dazzled,
			Deafened,
			Disabled,
			Dying,
			NegativeLevel,
			Entangled,
			Exhausted,
			Fascinated,
			FastHealing,
			Fatigued,
			FlatFooted,
			Frightened,
			Grappling,
			Helpless,
			Incorporeal,
			Invisible,
			Nauseated,
			Panicked, 
			Paralysed,
			Petrified,
			Pinned,
			PowerAttack,
			Prone,
			Raging,
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

		public enum TurnState
		{
			NotStarted,
			Started,
			Ended,
		}

		public enum Movement
		{
			Burrow,
			Climb,
			Fly,
			Swim,
		}

		public enum Manouverability
		{
			Perfect, 
			Good, 
			Average, 
			Poor, 
			Clumsy,
			None,
		}

		public enum Creature
		{
			Aberration,
			Animal,
			Construct,
			Dragon,
			Elemental,
			Fey,
			Giant,
			Humanoid,
			MagicalBeast,
			MonstrousHumanoid,
			Ooze,
			Outsider,
			Plant,
			Undead,
			Vermin,
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
			if (String.Equals(str, Constants.DieTypeD3, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Die.d3;
			}
			else if (String.Equals(str, Constants.DieTypeD4, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Die.d4;
			}
			else if (String.Equals(str, Constants.DieTypeD6, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Die.d6;
			}
			else if (String.Equals(str, Constants.DieTypeD8, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Die.d8;
			}
			else if (String.Equals(str, Constants.DieTypeD10, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Die.d10;
			}
			else if (String.Equals(str, Constants.DieTypeD12, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Die.d12;
			}
			else
			{
				throw new FormatException("Die type \'" + str + "\' not recognised.");
			}
		}

		public static Types.Die GetDieTypeFromInt(int sides)
		{
			if (sides == 3)
			{
				return Types.Die.d3;
			}
			else if (sides == 4)
			{
				return Types.Die.d4;
			}
			else if (sides == 6)
			{
				return Types.Die.d6;
			}
			else if (sides == 8)
			{
				return Types.Die.d8;
			}
			else if (sides == 10)
			{
				return Types.Die.d10;
			}
			else if (sides == 12)
			{
				return Types.Die.d12;
			}
			else
			{
				throw new FormatException("Die type d\'" + sides.ToString() + "\' not recognised.");
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
			if (String.Equals(str, Constants.SizeFine, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Size.Fine;
			}
			else if (String.Equals(str, Constants.SizeDiminuative, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Size.Diminuative;
			}
			else if (String.Equals(str, Constants.SizeTiny, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Size.Tiny;
			}
			else if (String.Equals(str, Constants.SizeSmall, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Size.Small;
			}
			else if (String.Equals(str, Constants.SizeMedium, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Size.Medium;
			}
			else if (String.Equals(str, Constants.SizeLarge, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Size.Large;
			}
			else if (String.Equals(str, Constants.SizeHuge, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Size.Huge;
			}
			else if (String.Equals(str, Constants.SizeGargantuan, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Size.Gargantuan;
			}
			else if (String.Equals(str, Constants.SizeColossal, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Size.Colossal;
			}
			else if (String.Equals(str, Constants.SizeColossalPlus, StringComparison.OrdinalIgnoreCase))
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
			if (String.Equals(str, Constants.AbilityStrength, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Ability.Strength;
			}
			else if (String.Equals(str, Constants.AbilityDexterity, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Ability.Dexterity;
			}
			else if (String.Equals(str, Constants.AbilityConstitution, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Ability.Constitution;
			}
			else if (String.Equals(str, Constants.AbilityIntelligence, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Ability.Intelligence;
			}
			else if (String.Equals(str, Constants.AbilityWisdom, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Ability.Wisdom;
			}
			else if (String.Equals(str, Constants.AbilityCharisma, StringComparison.OrdinalIgnoreCase))
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
			case Types.Effect.AbilityModifier:		return Constants.EffectAbilityModifier;
			case Types.Effect.Blinded:						return Constants.EffectBlinded;
			case Types.Effect.Confused:						return Constants.EffectConfused;
			case Types.Effect.Cowering:						return Constants.EffectCowering;
			case Types.Effect.Custom:							return Constants.EffectCustom;
			case Types.Effect.Dazed:							return Constants.EffectDazed;
			case Types.Effect.Dazzled:						return Constants.EffectDazzled;
			case Types.Effect.Deafened:						return Constants.EffectDeafened;
			case Types.Effect.Disabled:						return Constants.EffectDisabled;
			case Types.Effect.Dying:							return Constants.EffectDying;
			case Types.Effect.NegativeLevel:			return Constants.EffectNegativeLevel;
			case Types.Effect.Entangled:					return Constants.EffectEntangled;
			case Types.Effect.Exhausted:					return Constants.EffectExhausted;
			case Types.Effect.Fascinated:					return Constants.EffectFascinated;
			case Types.Effect.FastHealing:				return Constants.EffectFastHealing;
			case Types.Effect.Fatigued:						return Constants.EffectFatigued;
			case Types.Effect.FlatFooted:					return Constants.EffectFlatFooted;
			case Types.Effect.Frightened:					return Constants.EffectFrightened;
			case Types.Effect.Grappling:					return Constants.EffectGrappling;
			case Types.Effect.Helpless:						return Constants.EffectHelpless;
			case Types.Effect.Incorporeal:				return Constants.EffectIncorporeal;
			case Types.Effect.Invisible:					return Constants.EffectInvisible;
			case Types.Effect.Nauseated:					return Constants.EffectNauseated;
			case Types.Effect.Panicked:						return Constants.EffectPanicked;
			case Types.Effect.Paralysed:					return Constants.EffectParalysed;
			case Types.Effect.Petrified:					return Constants.EffectPetrified;
			case Types.Effect.Pinned:							return Constants.EffectPinned;
			case Types.Effect.PowerAttack:				return Constants.EffectPowerAttack;
			case Types.Effect.Prone:							return Constants.EffectProne;
			case Types.Effect.Raging:							return Constants.EffectRaging;
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
			if (effect == Constants.EffectAbilityModifier)
			{
				return Types.Effect.AbilityModifier;
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
			else if (effect == Constants.EffectCustom)
			{
				return Types.Effect.Custom;
			}
			else if (effect == Constants.EffectDazed)
			{
				return Types.Effect.Dazed;
			}
			else if (effect == Constants.EffectDazzled)
			{
				return Types.Effect.Dazzled;
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
			else if (effect == Constants.EffectNegativeLevel)
			{
				return Types.Effect.NegativeLevel;
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
			else if (effect == Constants.EffectFastHealing)
			{
				return Types.Effect.FastHealing;
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
			else if (effect == Constants.EffectPowerAttack)
			{
				return Types.Effect.PowerAttack;
			}
			else if (effect == Constants.EffectProne)
			{
				return Types.Effect.Prone;
			}
			else if (effect == Constants.EffectRaging)
			{
				return Types.Effect.Raging;
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
				case Types.Attack.Melee:									return Constants.AttackTypeMelee;
				case Types.Attack.Ranged:									return Constants.AttackTypeRanged;
				case Types.Attack.MeleeTouch:							return Constants.AttackTypeMeleeTouch;
				case Types.Attack.RangedTouch:						return Constants.AttackTypeRangedTouch;
				case Types.Attack.IncorporealTouch:				return Constants.AttackTypeIncorporealTouch;
				default:																	return "Unrecognised attack type";
			}
		}

		public static Types.Attack GetAttackTypeFromString(string str)
		{
			if (str.Equals(Constants.AttackTypeMelee, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Attack.Melee;
			}
			else if (str.Equals(Constants.AttackTypeRanged, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Attack.Ranged;
			}
			else if (str.Equals(Constants.AttackTypeMeleeTouch, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Attack.MeleeTouch;
			}
			else if (str.Equals(Constants.AttackTypeRangedTouch, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Attack.RangedTouch;
			}
			else if (str.Equals(Constants.AttackTypeIncorporealTouch, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Attack.IncorporealTouch;
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
			if (String.Equals(str, Constants.DamageTypeAcid, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Acid;
			}
			else if (String.Equals(str, Constants.DamageTypeAdamantine, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Adamantine;
			}
			else if (String.Equals(str, Constants.DamageTypeBludgeoning, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Bludgeoning;
			}
			else if (String.Equals(str, Constants.DamageTypeChaos, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Chaos;
			}
			else if (String.Equals(str, Constants.DamageTypeCold, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Cold;
			}
			else if (String.Equals(str, Constants.DamageTypeColdIron, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.ColdIron;
			}
			else if (String.Equals(str, Constants.DamageTypeDivine, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Divine;
			}
			else if (String.Equals(str, Constants.DamageTypeEpic, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Epic;
			}
			else if (String.Equals(str, Constants.DamageTypeElectricity, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Electricity;
			}
			else if (String.Equals(str, Constants.DamageTypeEvil, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Evil;
			}
			else if (String.Equals(str, Constants.DamageTypeFire, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Fire;
			}
			else if (String.Equals(str, Constants.DamageTypeForce, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Force;
			}
			else if (String.Equals(str, Constants.DamageTypeGood, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Good;
			}
			else if (String.Equals(str, Constants.DamageTypeLaw, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Law;
			}
			else if (String.Equals(str, Constants.DamageTypeMagic, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Magic;
			}
			else if (String.Equals(str, Constants.DamageTypeNegativeEnergy, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.NegativeEnergy;
			}
			else if (String.Equals(str, Constants.DamageTypePiercing, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Piercing;
			}
			else if (String.Equals(str, Constants.DamageTypePositiveEnergy, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.PositiveEnergy;
			}
			else if (String.Equals(str, Constants.DamageTypeSilver, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Silver;
			}
			else if (String.Equals(str, Constants.DamageTypeSlashing, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Slashing;
			}
			else if (String.Equals(str, Constants.DamageTypeSonic, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Sonic;
			}
			else if (String.Equals(str, Constants.DamageTypeSubdual, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Damage.Subdual;
			}
			else
			{
				throw new FormatException("Damage type \'" + str + "\' not recognised.");
			}
		}
		
		public static string GetTurnStateString(Types.TurnState turnState)
		{
			switch (turnState)
			{
			case Types.TurnState.NotStarted:	return Constants.TurnStateNotStarted;
			case Types.TurnState.Started:			return Constants.TurnStateStarted;
			case Types.TurnState.Ended:				return Constants.TurnStateEnded;
			default:													return "Unrecognised turn state!";
			}
		}

		public static Types.TurnState GetTurnStateFromString(string str)
		{
			if (str.Equals(Constants.TurnStateNotStarted, StringComparison.OrdinalIgnoreCase))
			{
				return Types.TurnState.NotStarted;
			}
			else if (str.Equals(Constants.TurnStateStarted, StringComparison.OrdinalIgnoreCase))
			{
				return Types.TurnState.Started;
			}
			else if (str.Equals(Constants.TurnStateEnded, StringComparison.OrdinalIgnoreCase))
			{
				return Types.TurnState.Ended;
			}
			else
			{
				throw new FormatException("TurnState \'" + str + "\' not recognised.");
			}
		}

		public static string GetManouverabilityString(Types.Manouverability manouverability)
		{
			switch (manouverability)
			{
			case Types.Manouverability.Perfect:	return Constants.ManouverabilityPerfect;
			case Types.Manouverability.Good:		return Constants.ManouverabilityGood;
			case Types.Manouverability.Average:	return Constants.ManouverabilityAverage;
			case Types.Manouverability.Poor:		return Constants.ManouverabilityPoor;
			case Types.Manouverability.Clumsy:	return Constants.ManouverabilityClumsy;
			case Types.Manouverability.None:		return Constants.ManouverabilityNone;
			default:														return "Unrecognised manouverability!";
			}
		}

		public static Types.Manouverability GetManouverabilityFromString(string str)
		{
			if (str.Equals(Constants.ManouverabilityPerfect, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Manouverability.Perfect;
			}
			else if (str.Equals(Constants.ManouverabilityGood, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Manouverability.Good;
			}
			else if (str.Equals(Constants.ManouverabilityAverage, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Manouverability.Average;
			}
			else if (str.Equals(Constants.ManouverabilityPoor, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Manouverability.Poor;
			}
			else if (str.Equals(Constants.ManouverabilityClumsy, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Manouverability.Clumsy;
			}
			else if (str.Equals(Constants.ManouverabilityNone, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Manouverability.None;
			}
			else
			{
				throw new FormatException("Manouverability \'" + str + "\' not recognised.");
			}
		}

		public static string GetMovementTypeString(Types.Movement movementType)
		{
			switch (movementType)
			{
			case Types.Movement.Burrow:
				return Constants.MovementBurrow;
			case Types.Movement.Climb:
				return Constants.MovementClimb;
			case Types.Movement.Fly:
				return Constants.MovementFly;
			case Types.Movement.Swim:
				return Constants.MovementSwim;
			default:
				return "Unrecognised movement type!";
			}
		}

		public static Types.Movement GetMovementTypeFromString(string str)
		{
			if (str.Equals(Constants.MovementBurrow, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Movement.Burrow;
			}
			else if (str.Equals(Constants.MovementClimb, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Movement.Climb;
			}
			else if (str.Equals(Constants.MovementFly, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Movement.Fly;
			}
			else if (str.Equals(Constants.MovementSwim, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Movement.Swim;
			}
			else
			{
				throw new FormatException("Movement type \'" + str + "\' not recognised.");
			}
		}

		public static string GetCreatureTypeString(Types.Creature creatureType)
		{
			switch (creatureType)
			{
			case Types.Creature.Aberration:
				return Constants.CreatureAberration;
			case Types.Creature.Animal:
				return Constants.CreatureAnimal;
			case Types.Creature.Construct:
				return Constants.CreatureConstruct;
			case Types.Creature.Dragon:
				return Constants.CreatureDragon;
			case Types.Creature.Elemental:
				return Constants.CreatureElemental;
			case Types.Creature.Fey:
				return Constants.CreatureFey;
			case Types.Creature.Giant:
				return Constants.CreatureGiant;
			case Types.Creature.Humanoid:
				return Constants.CreatureHumanoid;
			case Types.Creature.MagicalBeast:
				return Constants.CreatureMagicalBeast;
			case Types.Creature.MonstrousHumanoid:
				return Constants.CreatureMonstrousHumanoid;
			case Types.Creature.Ooze:
				return Constants.CreatureOoze;
			case Types.Creature.Outsider:
				return Constants.CreatureOutsider;
			case Types.Creature.Plant:
				return Constants.CreaturePlant;
			case Types.Creature.Undead:
				return Constants.CreatureUndead;
			case Types.Creature.Vermin:
				return Constants.CreatureVermin;
			default:
				return "Unrecognised creature type!";
			}
		}

		public static Types.Creature GetCreatureTypeFromString(string str)
		{
			if (str.Equals(Constants.CreatureAberration, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.Aberration;
			}
			else if (str.Equals(Constants.CreatureAnimal, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.Animal;
			}
			else if (str.Equals(Constants.CreatureConstruct, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.Construct;
			}
			else if (str.Equals(Constants.CreatureDragon, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.Dragon;
			}
			else if (str.Equals(Constants.CreatureElemental, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.Elemental;
			}
			else if (str.Equals(Constants.CreatureFey, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.Fey;
			}
			else if (str.Equals(Constants.CreatureGiant, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.Giant;
			}
			else if (str.Equals(Constants.CreatureHumanoid, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.Humanoid;
			}
			else if (str.Equals(Constants.CreatureMagicalBeast, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.MagicalBeast;
			}
			else if (str.Equals(Constants.CreatureMonstrousHumanoid, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.MonstrousHumanoid;
			}
			else if (str.Equals(Constants.CreatureOoze, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.Ooze;
			}
			else if (str.Equals(Constants.CreatureOutsider, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.Outsider;
			}
			else if (str.Equals(Constants.CreaturePlant, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.Plant;
			}
			else if (str.Equals(Constants.CreatureUndead, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.Undead;
			}
			else if (str.Equals(Constants.CreatureVermin, StringComparison.OrdinalIgnoreCase))
			{
				return Types.Creature.Vermin;
			}
			else
			{
				throw new FormatException("Creature type \'" + str + "\' not recognised.");
			}
		}

		public static int CalculateXP(float challengeRating)
		{
			if (challengeRating < 1)
			{
				return (int)(challengeRating * CalculateXP(1));
			}
			else if (challengeRating == 1)
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

		public static int GetAbilityModifier(int abilityScore)
		{
			return (abilityScore - 10) / 2;
		}

		public static bool IsWeaponDamageType(Types.Damage damageType)
		{
			switch (damageType)
			{
			case Types.Damage.Bludgeoning:	return true;
			case Types.Damage.Piercing:			return true;
			case Types.Damage.Slashing:			return true;
			default:												return false;
			}
		}

		public static bool IsEnergyDamageType(Types.Damage damageType)
		{
			switch (damageType)
			{
			case Types.Damage.Acid:						return true;
			case Types.Damage.Cold:						return true;
			case Types.Damage.Electricity:		return true;
			case Types.Damage.Fire:						return true;
			case Types.Damage.Force:					return true;
			case Types.Damage.NegativeEnergy:	return true;
			case Types.Damage.PositiveEnergy:	return true;
			case Types.Damage.Sonic:					return true;
			default:													return false;
			}
		}

		public static bool IsValueEffect(Types.Effect effectType)
		{
			switch (effectType)
			{
				case Types.Effect.AbilityModifier:
				case Types.Effect.FastHealing:
				case Types.Effect.PowerAttack:
					return true;
				default:
					return false;
			}
		}

		public static bool IsAbilityEffect(Types.Effect effectType)
		{
			switch (effectType)
			{
				case Types.Effect.AbilityModifier:
					return true;
				default:
					return false;
			}
		}

		public static bool IsTextEffect(Types.Effect effectType)
		{
			switch (effectType)
			{
				case Types.Effect.Custom:
					return true;
				default:
					return false;
			}
		}
	}

	public static class StringExtensions
	{
		public static bool Contains(this string source, string toCheck, StringComparison comp)
		{
			return source?.IndexOf(toCheck, comp) >= 0;
		}
	}
}
