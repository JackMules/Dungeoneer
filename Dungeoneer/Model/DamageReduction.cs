using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Dungeoneer.Utility;
using System.Collections.ObjectModel;

namespace Dungeoneer.Model
{
	public class DamageReduction : BaseModel
	{
		public DamageReduction()
		{
			_types = new DamageDescriptorSet();
		}

		private int _value;
		private DamageDescriptorSet _types;

		public int Value
		{
			get { return _value; }
			set
			{
				_value = value;
				NotifyPropertyChanged("Value");
			}
		}

		public DamageDescriptorSet DamageTypes
		{
			get { return _types; }
			set
			{
				_types = value;
				NotifyPropertyChanged("Types");
			}
		}

		public bool IsBypassedBy(DamageDescriptorSet damage)
		{
			bool bypassed = true;
			foreach (Types.Damage drDamageType in DamageTypes.ToList())
			{
				bool matched = damage.Contains(drDamageType);

				// If none of the weapon's damage qualities match this part of the damage type, then 
				if (!matched)
				{
					bypassed = false;
					break;
				}
			}
			return bypassed;
		}

		public override string ToString()
		{
			string damageTypes = string.Join(" and ", DamageTypes.ToString().Split(' '));
			return Value.ToString() + "/" + damageTypes;
		}
		
		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("DamageReduction");

			xmlWriter.WriteStartElement("Value");
			xmlWriter.WriteString(Value.ToString());
			xmlWriter.WriteEndElement();

			DamageTypes.WriteXML(xmlWriter);

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
					else if (childNode.Name == "DamageDescriptorSet")
					{
						DamageTypes.ReadXML(childNode);
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
