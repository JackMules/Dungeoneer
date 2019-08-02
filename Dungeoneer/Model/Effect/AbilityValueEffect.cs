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
	public class AbilityValueEffect : Effect, IValueEffect, IAbilityEffect
	{
		public AbilityValueEffect(Types.Effect effectType, Types.Ability ability, int value)
			: base(effectType)
		{
			_ability = ability;
			_value = value;
		}

		public AbilityValueEffect(XmlNode xmlNode)
			: base(xmlNode)
		{
			ReadXML(xmlNode);
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

		public override string ToString()
		{
			return Methods.GetAbilityString(Ability) + " " + Methods.GetSignedNumberString(Value);
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
