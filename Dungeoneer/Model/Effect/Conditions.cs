using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.Model.Effect.Conditions
{
	[Serializable]
	public class Blinded : TimedEffect
	{
		public Blinded()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).SetFlatFooted();
				(modifiedAttributes as CreatureAttributes).ModifyArmorClass(-2);
				(modifiedAttributes as CreatureAttributes).ModifySpeed(1/2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Blinded);
		}
	}

	[Serializable]
	public class Confused : TimedEffect
	{
		public Confused()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Confused);
		}
	}

	[Serializable]
	public class Cowering : TimedEffect
	{
		public Cowering()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).SetFlatFooted();
				(modifiedAttributes as CreatureAttributes).ModifyArmorClass(-2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Cowering);
		}
	}

	[Serializable]
	public class Dazed : TimedEffect
	{
		public Dazed()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Dazed);
		}
	}

	[Serializable]
	public class Dazzled : TimedEffect
	{
		public Dazzled()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Strength, -2);
				(modifiedAttributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Dexterity, -2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Dazzled);
		}
	}

	[Serializable]
	public class Dead : Effect
	{
		public Dead()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).HitPoints = (modifiedAttributes as CreatureAttributes).Constitution * -1;
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Dead);
		}
	}

	[Serializable]
	public class Deafened : TimedEffect
	{
		public Deafened()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			modifiedAttributes.InitiativeMod -= 4;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Deafened);
		}
	}

	[Serializable]
	public class Disabled : TimedEffect
	{
		public Disabled()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ModifySpeed(1/2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Disabled);
		}
	}

	[Serializable]
	public class Dying : TimedEffect
	{
		public Dying()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Dying);
		}
	}

	[Serializable]
	public class Entangled : TimedEffect
	{
		public Entangled()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Strength, -2);
				(modifiedAttributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Dexterity, -2);
				(modifiedAttributes as CreatureAttributes).ModifySpeed(1/2);
				(modifiedAttributes as CreatureAttributes).ModifyAbilityScore(Types.Ability.Dexterity, -4);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Entangled);
		}
	}

	[Serializable]
	public class Exhausted : TimedEffect
	{
		public Exhausted()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ModifySpeed(1/2);
				(modifiedAttributes as CreatureAttributes).ModifyAbilityScore(Types.Ability.Strength, -6);
				(modifiedAttributes as CreatureAttributes).ModifyAbilityScore(Types.Ability.Dexterity, -6);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Exhausted);
		}
	}

	[Serializable]
	public class Fascinated : TimedEffect
	{
		public Fascinated()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Fascinated);
		}
	}

	[Serializable]
	public class Fatigued : TimedEffect
	{
		public Fatigued()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ModifyAbilityScore(Types.Ability.Strength, -2);
				(modifiedAttributes as CreatureAttributes).ModifyAbilityScore(Types.Ability.Dexterity, -2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Fatigued);
		}
	}

	[Serializable]
	public class FlatFooted : TimedEffect
	{
		public FlatFooted()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).SetFlatFooted();
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.FlatFooted);
		}
	}

	[Serializable]
	public class Frightened : TimedEffect
	{
		public Frightened()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Strength, -2);
				(modifiedAttributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Dexterity, -2);
				(modifiedAttributes as CreatureAttributes).ModifySaves(-2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Frightened);
		}
	}

	[Serializable]
	public class Grappling : TimedEffect
	{
		public Grappling()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Grappling);
		}
	}

	[Serializable]
	public class Helpless : TimedEffect
	{
		public Helpless()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).Dexterity = 0;
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Helpless);
		}
	}

	[Serializable]
	public class Incorporeal : TimedEffect
	{
		public Incorporeal()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Incorporeal);
		}
	}

	[Serializable]
	public class Invisible : TimedEffect
	{
		public Invisible()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Invisible);
		}
	}

	[Serializable]
	public class Nauseated : TimedEffect
	{
		public Nauseated()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Nauseated);
		}
	}

	[Serializable]
	public class NegativeLevel : TimedEffect
	{
		public NegativeLevel()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Strength, -1);
				(modifiedAttributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Dexterity, -1);
				(modifiedAttributes as CreatureAttributes).HitPoints -= 5;
				(modifiedAttributes as CreatureAttributes).ModifySaves(-1);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.NegativeLevel);
		}
	}

	[Serializable]
	public class Panicked : TimedEffect
	{
		public Panicked()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ModifySaves(-2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Panicked);
		}
	}

	[Serializable]
	public class Paralysed : TimedEffect
	{
		public Paralysed()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).Strength = 0;
				(modifiedAttributes as CreatureAttributes).Dexterity = 0;
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Paralysed);
		}
	}

	[Serializable]
	public class Petrified : TimedEffect
	{
		public Petrified()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Petrified);
		}
	}

	[Serializable]
	public class Pinned : TimedEffect
	{
		public Pinned()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Pinned);
		}
	}

	[Serializable]
	public class Prone : TimedEffect
	{
		public Prone()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Prone);
		}
	}

	[Serializable]
	public class Raging : TimedEffect
	{
		public Raging()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ModifyAbilityScore(Types.Ability.Strength, 4);
				(modifiedAttributes as CreatureAttributes).ModifyAbilityScore(Types.Ability.Constitution, 4);
				(modifiedAttributes as CreatureAttributes).ModifyArmorClass(-2);
				(modifiedAttributes as CreatureAttributes).ModifyWillSave(2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Raging);
		}
	}

		[Serializable]
	public class Shaken : TimedEffect
	{
		public Shaken()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Strength, -2);
				(modifiedAttributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Dexterity, -2);
				(modifiedAttributes as CreatureAttributes).ModifySaves(-2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Shaken);
		}
	}

	[Serializable]
	public class Sickened : TimedEffect
	{
		public Sickened()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Strength, -2);
				(modifiedAttributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Dexterity, -2);
				(modifiedAttributes as CreatureAttributes).ModifySaves(-2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Sickened);
		}
	}

	[Serializable]
	public class Stable : TimedEffect
	{
		public Stable()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Stable);
		}
	}

	[Serializable]
	public class Staggered : TimedEffect
	{
		public Staggered()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Staggered);
		}
	}

	[Serializable]
	public class Stunned : TimedEffect
	{
		public Stunned()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ModifyArmorClass(-2);
				(modifiedAttributes as CreatureAttributes).SetFlatFooted();
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Stunned);
		}
	}

	[Serializable]
	public class Turned : TimedEffect
	{
		public Turned()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Turned);
		}
	}

	[Serializable]
	public class Unconscious : TimedEffect
	{
		public Unconscious()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.Unconscious);
		}
	}
}
