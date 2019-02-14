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
		public static Effect GetEffect(XmlNode xmlNode)
		{
			string effectName = xmlNode.Name;
			Effect effect = null;
			try
			{
				Types.Effect effectType = Methods.GetEffectTypeFromString(effectName);
				effect = GetEffect(effectType);
				effect.ReadXML(xmlNode);
			}
			catch (FormatException e)
			{
				throw e;
			}
			return effect;
		}

		public static Effect GetEffect(Types.Effect effectType)
		{
			switch (effectType)
			{
				case Types.Effect.AbilityModifier:		return new AbilityModifier();
				case Types.Effect.Blinded:						return new Conditions.Blinded();
				case Types.Effect.Confused:						return new Conditions.Confused();
				case Types.Effect.Cowering:						return new Conditions.Cowering();
				case Types.Effect.Dazed:							return new Conditions.Dazed();
				case Types.Effect.Dazzled:						return new Conditions.Dazzled();
				case Types.Effect.Dead:								return new Conditions.Dead();
				case Types.Effect.Deafened:						return new Conditions.Deafened();
				case Types.Effect.Disabled:						return new Conditions.Disabled();
				case Types.Effect.Dying:							return new Conditions.Dying();
				case Types.Effect.NegativeLevel:			return new Conditions.NegativeLevel();
				case Types.Effect.Entangled:					return new Conditions.Entangled();
				case Types.Effect.Exhausted:					return new Conditions.Exhausted();
				case Types.Effect.Fascinated:					return new Conditions.Fascinated();
				case Types.Effect.FastHealing:				return new FastHealing();
				case Types.Effect.Fatigued:						return new Conditions.Fatigued();
				case Types.Effect.FlatFooted:					return new Conditions.FlatFooted();
				case Types.Effect.Frightened:					return new Conditions.Frightened();
				case Types.Effect.Grappling:					return new Conditions.Grappling();
				case Types.Effect.Helpless:						return new Conditions.Helpless();
				case Types.Effect.Incorporeal:				return new Conditions.Incorporeal();
				case Types.Effect.Invisible:					return new Conditions.Invisible();
				case Types.Effect.Nauseated:					return new Conditions.Nauseated();
				case Types.Effect.Panicked:						return new Conditions.Panicked();
				case Types.Effect.Paralysed:					return new Conditions.Paralysed();
				case Types.Effect.Petrified:					return new Conditions.Petrified();
				case Types.Effect.Pinned:							return new Conditions.Pinned();
				case Types.Effect.Prone:							return new Conditions.Prone();
				case Types.Effect.Raging:							return new Conditions.Raging();
				case Types.Effect.Shaken:							return new Conditions.Shaken();
				case Types.Effect.Sickened:						return new Conditions.Sickened();
				case Types.Effect.Stable:							return new Conditions.Stable();
				case Types.Effect.Staggered:					return new Conditions.Staggered();
				case Types.Effect.Stunned:						return new Conditions.Stunned();
				case Types.Effect.Turned:							return new Conditions.Turned();
				case Types.Effect.Unconscious:				return new Conditions.Unconscious();
			}
			return null;
		}
	}
}
