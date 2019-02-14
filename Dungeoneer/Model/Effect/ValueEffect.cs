using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.Model.Effect
{
	public interface ValueEffect
	{
		int Value
		{
			get;
			set;
		}
	}

	public interface AbilityEffect
	{
		Types.Ability Ability
		{
			get;
			set;
		}
	}

	public class FastHealing : Effect, ValueEffect
	{
		public FastHealing()
			: base(true)
		{
			Name = GetType().Name;
		}

		private int _value;

		public int Value
		{
			get { return _value; }
			set
			{
				_value = value;
				NotifyPropertyChanged("Value");
			}
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).HitPoints += Value;

				if ((modifiedAttributes as CreatureAttributes).HitPoints > 
						(baseAttributes as CreatureAttributes).HitPoints)
				{
					(modifiedAttributes as CreatureAttributes).HitPoints = (baseAttributes as CreatureAttributes).HitPoints;
				}
			}
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.FastHealing);
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override void WritePropertyXML(XmlWriter xmlWriter)
		{
			base.WritePropertyXML(xmlWriter);

			xmlWriter.WriteStartElement("Value");
			xmlWriter.WriteString(Value.ToString());
			xmlWriter.WriteEndElement();
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			base.ReadXML(xmlNode);

			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Value")
					{
						Value = Convert.ToInt32(childNode.InnerText);
					}
				}
			}
			catch (XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}
	}

	public class AbilityModifier : TimedEffect, ValueEffect, AbilityEffect
	{
		public AbilityModifier()
			: base(false)
		{
			Name = GetType().Name;
		}

		private int _value;
		private Types.Ability _ability;

		public int Value
		{
			get { return _value; }
			set
			{
				_value = value;
				NotifyPropertyChanged("Value");
			}
		}

		public Types.Ability Ability
		{
			get { return _ability; }
			set
			{
				_ability = value;
				NotifyPropertyChanged("Ability");
			}
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ModifyAbilityScore(Ability, Value);
			}
		}

		public override string ToString()
		{
			return Methods.GetAbilityString(Ability) + " " + Methods.GetSignedNumberString(Value);
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override void WritePropertyXML(XmlWriter xmlWriter)
		{
			base.WritePropertyXML(xmlWriter);

			xmlWriter.WriteStartElement("Value");
			xmlWriter.WriteString(Value.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Ability");
			xmlWriter.WriteString(Methods.GetAbilityString(Ability));
			xmlWriter.WriteEndElement();
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			base.ReadXML(xmlNode);

			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Value")
					{
						Value = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Ability")
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
