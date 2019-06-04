using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Dungeoneer.Utility;

namespace Dungeoneer.Model
{
	[Serializable]
	public class EnergyResistance : BaseModel
	{
		public EnergyResistance()
		{

		}

		public EnergyResistance(EnergyResistance other)
		{
			_value = other._value;
			_energyType = other._energyType;
		}

		private int _value;
		private Types.Damage _energyType;

		public int Value
		{
			get { return _value; }
			set
			{
				_value = value;
				NotifyPropertyChanged("Value");
			}
		}

		public Types.Damage EnergyType
		{
			get { return _energyType; }
			set
			{
				_energyType = value;
				NotifyPropertyChanged("EnergyType");
			}
		}

		public override string ToString()
		{
			return "Resist " + Methods.GetDamageTypeString(EnergyType) + " " + Value.ToString();
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("EnergyResistance");

			xmlWriter.WriteStartElement("Value");
			xmlWriter.WriteString(Value.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("EnergyType");
			xmlWriter.WriteString(Methods.GetDamageTypeString(EnergyType));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Value")
					{
						Value = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "EnergyType")
					{
						EnergyType = Methods.GetDamageTypeFromString(childNode.InnerText);
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
