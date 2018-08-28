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
			_types = new ObservableCollection<Types.DamageType>();
		}

		private int _value;
		private ObservableCollection<Types.DamageType> _types;

		public int Value
		{
			get { return _value; }
			set
			{
				_value = value;
				NotifyPropertyChanged("Value");
			}
		}

		public ObservableCollection<Types.DamageType> DamageTypes
		{
			get { return _types; }
			set
			{
				_types = value;
				NotifyPropertyChanged("Types");
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("DamageReduction");

			xmlWriter.WriteStartElement("Value");
			xmlWriter.WriteString(Value.ToString());
			xmlWriter.WriteEndElement();

			foreach (Types.DamageType type in DamageTypes)
			{
				xmlWriter.WriteStartElement("DamageType");
				xmlWriter.WriteString(Methods.GetDamageTypeString(type));
				xmlWriter.WriteEndElement();
			}
			
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
					else if (childNode.Name == "DamageType")
					{
						DamageTypes.Add(Methods.GetDamageTypeFromString(childNode.InnerText));
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
