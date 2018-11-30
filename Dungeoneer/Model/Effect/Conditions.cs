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

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).SetFlatFooted();
				(attributes as CreatureAttributes).ModifyArmorClass(-2);
				(attributes as CreatureAttributes).ModifySpeed(1/2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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
	}

	[Serializable]
	public class Cowering : TimedEffect
	{
		public Cowering()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).SetFlatFooted();
				(attributes as CreatureAttributes).ModifyArmorClass(-2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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
	}

	[Serializable]
	public class Dazzled : TimedEffect
	{
		public Dazzled()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Strength, -2);
				(attributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Dexterity, -2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).HitPoints = (attributes as CreatureAttributes).Constitution * -1;
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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

		public override void ApplyTo(ActorAttributes attributes)
		{
			attributes.InitiativeMod -= 4;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).ModifySpeed(1/2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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
	}

	[Serializable]
	public class Entangled : TimedEffect
	{
		public Entangled()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Strength, -2);
				(attributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Dexterity, -2);
				(attributes as CreatureAttributes).ModifySpeed(1/2);
				(attributes as CreatureAttributes).ModifyAbilityScore(Types.Ability.Dexterity, -4);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).ModifySpeed(1/2);
				(attributes as CreatureAttributes).ModifyAbilityScore(Types.Ability.Strength, -6);
				(attributes as CreatureAttributes).ModifyAbilityScore(Types.Ability.Dexterity, -6);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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
	}

	[Serializable]
	public class Fatigued : TimedEffect
	{
		public Fatigued()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).ModifyAbilityScore(Types.Ability.Strength, -2);
				(attributes as CreatureAttributes).ModifyAbilityScore(Types.Ability.Dexterity, -2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).SetFlatFooted();
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Strength, -2);
				(attributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Dexterity, -2);
				(attributes as CreatureAttributes).ModifySaves(-2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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
	}

	[Serializable]
	public class Helpless : TimedEffect
	{
		public Helpless()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).Dexterity = 0;
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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
	}

	[Serializable]
	public class NegativeLevel : TimedEffect
	{
		public NegativeLevel()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Strength, -1);
				(attributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Dexterity, -1);
				(attributes as CreatureAttributes).HitPoints -= 5;
				(attributes as CreatureAttributes).ModifySaves(-1);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).ModifySaves(-2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).Strength = 0;
				(attributes as CreatureAttributes).Dexterity = 0;
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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
	}

	[Serializable]
	public class Shaken : TimedEffect
	{
		public Shaken()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Strength, -2);
				(attributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Dexterity, -2);
				(attributes as CreatureAttributes).ModifySaves(-2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Strength, -2);
				(attributes as CreatureAttributes).ChangeAttackModifier(Types.Ability.Dexterity, -2);
				(attributes as CreatureAttributes).ModifySaves(-2);
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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
	}

	[Serializable]
	public class Stunned : TimedEffect
	{
		public Stunned()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override void ApplyTo(ActorAttributes attributes)
		{
			if (attributes is CreatureAttributes)
			{
				(attributes as CreatureAttributes).ModifyArmorClass(-2);
				(attributes as CreatureAttributes).SetFlatFooted();
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
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
	}
}
