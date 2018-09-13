using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Dungeoneer.Utility;

namespace Dungeoneer.Model.Effect
{
	public class AbilityDamagePerTurnEffect : CreatureEffect
	{
		public AbilityDamagePerTurnEffect(Types.Ability ability, int damage)
			: base(true)
		{
			Ability = ability;
			Value = damage;
		}
		
		private Types.Ability _ability;

		public Types.Ability Ability
		{
			get { return _ability; }
			private set { _ability = value; }
		}

		public override Creature ApplyTo(Creature creature)
		{
			creature = Methods.DoAbilityDamage(creature, Value, _ability);
			return creature;
		}

		public override string ToString()
		{
			return Value.ToString() + " " + Methods.GetAbilityString(Ability) + " damage per turn";
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("AbilityDamagePerTurnEffect");
		}

		public override void WritePropertyXML(XmlWriter xmlWriter)
		{
			base.WritePropertyXML(xmlWriter);

			xmlWriter.WriteStartElement("Ability");
			xmlWriter.WriteString(_ability.ToString());
			xmlWriter.WriteEndElement();
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			base.ReadXML(xmlNode);

			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Ability")
					{
						Ability = Methods.GetAbilityFromString(childNode.InnerText);
					}
				}
			}
			catch (XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}
	}
}
