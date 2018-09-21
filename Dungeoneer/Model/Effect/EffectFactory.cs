using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;
using System.Xml;

namespace Dungeoneer.Model.Effect
{
	public static class EffectFactory
	{
		public static Effect GetEffect(ViewModel.AddEffectWindowViewModel vm)
		{
			Effect effect = null;

			effect = GetCondition(vm.SelectedEffectType, Convert.ToInt32(vm.Duration));
			
			if (effect == null)
			{
				effect = GetEffect(vm.SelectedEffectType, vm.SelectedEnergyType, Convert.ToInt32(vm.Value), Convert.ToInt32(vm.Duration));
			}

			return effect;
		}

		public static Effect GetCondition(Types.Effect effectType, int duration)
		{
			switch (effectType)
			{
				case Types.Effect.Blinded:						return new Condition.Blinded();
				case Types.Effect.Confused:						return new Condition.Confused();
				case Types.Effect.Cowering:						return new Condition.Cowering();
				case Types.Effect.Dazed:							return new Condition.Dazed();
				case Types.Effect.Dazzled:						return new Condition.Dazzled();
				case Types.Effect.Dead:								return new Condition.Dead();
				case Types.Effect.Deafened:						return new Condition.Deafened();
				case Types.Effect.Disabled:						return new Condition.Disabled();
				case Types.Effect.Dying:							return new Condition.Dying();
				case Types.Effect.NegativeLevel:			return new Condition.NegativeLevel();
				case Types.Effect.Entangled:					return new Condition.Entangled();
				case Types.Effect.Exhausted:					return new Condition.Exhausted();
				case Types.Effect.Fascinated:					return new Condition.Fascinated();
				case Types.Effect.Fatigued:						return new Condition.Fatigued();
				case Types.Effect.Frightened:					return new Condition.Frightened();
				case Types.Effect.Grappling:					return new Condition.Grappling();
				case Types.Effect.Helpless:						return new Condition.Helpless();
				case Types.Effect.Incorporeal:				return new Condition.Incorporeal();
				case Types.Effect.Invisible:					return new Condition.Invisible();
				case Types.Effect.Nauseated:					return new Condition.Nauseated();
				case Types.Effect.Panicked:						return new Condition.Panicked();
				case Types.Effect.Paralysed:					return new Condition.Paralysed();
				case Types.Effect.Petrified:					return new Condition.Petrified();
				case Types.Effect.Pinned:							return new Condition.Pinned();
				case Types.Effect.Prone:							return new Condition.Prone();
				case Types.Effect.Shaken:							return new Condition.Shaken();
				case Types.Effect.Sickened:						return new Condition.Sickened();
				case Types.Effect.Stable:							return new Condition.Stable();
				case Types.Effect.Staggered:					return new Condition.Staggered();
				case Types.Effect.Stunned:						return new Condition.Stunned();
				case Types.Effect.Turned:							return new Condition.Turned();
				case Types.Effect.Unconscious:				return new Condition.Unconscious();
			}
			return null;
		}

		public static Effect GetEffect(Types.Effect effectType, Types.Damage damage, int value, int duration)
		{
			switch (effectType)
			{
//				case Types.Effect.DamagePerTurn:			return new DamagePerTurnEffect();
//				case Types.Effect.TimedDamagePerTurn: return new TimedDamagePerTurnEffect();
				case Types.Effect.EnergyResistance:		return new EnergyResistance(damage, value);
			}
			return null;
		}

		/*
		public static Effect GetEffect(XmlNode xmlNode)
		{

			return new AbilityDamagePerTurnEffect();
		}
		*/
	}
}
