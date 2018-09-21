using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.Model.Effect.Condition
{
	public class Blinded : TimedEffect
	{
		public Blinded()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature.ArmourClass = creature.FlatFootedArmourClass - 2;
			creature.TouchArmourClass = creature.TouchArmourClass - Methods.GetAbilityModifier(creature.Dexterity) - 2;
			creature.Speed /= 2;
			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

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

	public class Cowering : TimedEffect
	{
		public Cowering()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature.ArmourClass = creature.FlatFootedArmourClass - 2;
			creature.TouchArmourClass = creature.TouchArmourClass - Methods.GetAbilityModifier(creature.Dexterity) - 2;
			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

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

	public class Dazzled : TimedEffect
	{
		public Dazzled()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			for (int i = 0; i < creature.Attacks.Count; ++i)
			{
				int newAttackMod = Convert.ToInt32(creature.Attacks[i].Modifier) - 1;
				creature.Attacks[i].Modifier = newAttackMod.ToString();
			}
			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

	public class Dead : CreatureEffect
	{
		public Dead()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature.HitPoints = creature.Constitution * -1;
			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

	public class Deafened : TimedEffect
	{
		public Deafened()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature.InitiativeMod -= 4;
			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

	public class Disabled : TimedEffect
	{
		public Disabled()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature.Speed /= 2;
			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

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

	public class Entangled : TimedEffect
	{
		public Entangled()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature.Speed /= 2;

			for (int i = 0; i < creature.Attacks.Count; ++i)
			{
				int newAttackMod = Convert.ToInt32(creature.Attacks[i].Modifier) - 2;
				creature.Attacks[i].Modifier = newAttackMod.ToString();
			}

			creature.Dexterity -= 4;

			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

	public class Exhausted : TimedEffect
	{
		public Exhausted()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature.Speed /= 2;

			creature.Strength -= 6;
			creature.Dexterity -= 6;

			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

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

	public class Fatigued : TimedEffect
	{
		public Fatigued()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature.Strength -= 2;
			creature.Dexterity -= 2;

			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

	public class FlatFooted : TimedEffect
	{
		public FlatFooted()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature.ArmourClass = creature.FlatFootedArmourClass;
			creature.TouchArmourClass = creature.TouchArmourClass - Methods.GetAbilityModifier(creature.Dexterity);

			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

	public class Frightened : TimedEffect
	{
		public Frightened()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			for (int i = 0; i < creature.Attacks.Count; ++i)
			{
				int newAttackMod = Convert.ToInt32(creature.Attacks[i].Modifier) - 2;
				creature.Attacks[i].Modifier = newAttackMod.ToString();
			}

			creature.FortitudeSave -= 2;
			creature.ReflexSave -= 2;
			creature.WillSave -= 2;

			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

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

	public class Helpless : TimedEffect
	{
		public Helpless()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature.Dexterity = 0;

			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

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

	public class NegativeLevel : TimedEffect
	{
		public NegativeLevel()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			for (int i = 0; i < creature.Attacks.Count; ++i)
			{
				int newAttackMod = Convert.ToInt32(creature.Attacks[i].Modifier) - 1;
				creature.Attacks[i].Modifier = newAttackMod.ToString();
			}

			creature.FortitudeSave -= 1;
			creature.ReflexSave -= 1;
			creature.WillSave -= 1;

			creature.HitPoints -= 5;

			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

	public class Panicked : TimedEffect
	{
		public Panicked()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature.FortitudeSave -= 2;
			creature.ReflexSave -= 2;
			creature.WillSave -= 2;

			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

	public class Paralysed : TimedEffect
	{
		public Paralysed()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature.Strength = 0;
			creature.Dexterity = 0;

			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

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

	public class Shaken : TimedEffect
	{
		public Shaken()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			for (int i = 0; i < creature.Attacks.Count; ++i)
			{
				int newAttackMod = Convert.ToInt32(creature.Attacks[i].Modifier) - 2;
				creature.Attacks[i].Modifier = newAttackMod.ToString();
			}

			creature.FortitudeSave -= 2;
			creature.ReflexSave -= 2;
			creature.WillSave -= 2;

			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

	public class Sickened : TimedEffect
	{
		public Sickened()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			for (int i = 0; i < creature.Attacks.Count; ++i)
			{
				int newAttackMod = Convert.ToInt32(creature.Attacks[i].Modifier) - 2;
				creature.Attacks[i].Modifier = newAttackMod.ToString();
			}

			creature.FortitudeSave -= 2;
			creature.ReflexSave -= 2;
			creature.WillSave -= 2;

			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

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

	public class Stunned : TimedEffect
	{
		public Stunned()
			: base(false)
		{
			Name = GetType().Name;
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature.ArmourClass = creature.FlatFootedArmourClass - 2;
			creature.TouchArmourClass = creature.TouchArmourClass - Methods.GetAbilityModifier(creature.Dexterity) - 2;

			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}
	}

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
