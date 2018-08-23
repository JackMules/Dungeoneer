using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Dungeoneer.Model
{
	public class Damage : BaseModel
	{
		public Damage()
		{

		}

		private int _numDice;
		private Utility.Types.DieType _die;
		private int _modifier;
		private Utility.Types.DamageType _type;

		public int NumDice
		{
			get { return _numDice; }
			set
			{
				_numDice = value;
				NotifyPropertyChanged("NumDice");
			}
		}

		public Utility.Types.DieType Die
		{
			get { return _die; }
			set
			{
				_die = value;
				NotifyPropertyChanged("Die");
			}
		}

		public int Modifier
		{
			get { return _modifier; }
			set
			{
				_modifier = value;
				NotifyPropertyChanged("Modifier");
			}
		}

		public Utility.Types.DamageType Type
		{
			get { return _type; }
			set
			{
				_type = value;
				NotifyPropertyChanged("Type");
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Damage");

			xmlWriter.WriteStartElement("NumDice");
			xmlWriter.WriteString(NumDice.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Die");
			xmlWriter.WriteString(Utility.Methods.GetDieTypeString(Die));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Modifier");
			xmlWriter.WriteString(Modifier.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Type");
			xmlWriter.WriteString(Utility.Methods.GetDamageTypeString(Type));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "NumDice")
					{
						NumDice = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Die")
					{
						Die = Utility.Methods.GetDieTypeFromString(childNode.InnerText);
					}
					else if (childNode.Name == "Modifier")
					{
						Modifier = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Type")
					{
						Type = Utility.Methods.GetDamageTypeFromString(childNode.InnerText);
					}
				}
			}
			catch (System.Xml.XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}
	}
}
