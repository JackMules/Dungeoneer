using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Dungeoneer.Model
{
	public class DamageReduction : INotifyPropertyChanged
	{
		private int _value;
		private Utility.Types.DamageType _type;

		public int Value
		{
			get { return _value; }
			set
			{
				_value = value;
				OnPropertyChanged("Value");
			}
		}

		public Utility.Types.DamageType DamageType
		{
			get { return _type; }
			set
			{
				_type = value;
				OnPropertyChanged("Type");
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("DamageReduction");

			xmlWriter.WriteStartElement("Value");
			xmlWriter.WriteString(Value.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("DamageType");
			xmlWriter.WriteString(Utility.Methods.GetDamageTypeString(DamageType));
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
						Value = Convert.ToInt32(childNode.Value);
					}
					else if (childNode.Name == "DamageType")
					{
						DamageType = Utility.Methods.GetDamageTypeFromString(childNode.Value);
					}
				}
			}
			catch (System.Xml.XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
