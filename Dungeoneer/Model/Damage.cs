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
	public class Damage : BaseModel
	{
		public Damage()
		{

		}

		private int _numDice;
		private Types.Die _die;
		private int _modifier;
		private Types.Damage _type;

		public int NumDice
		{
			get { return _numDice; }
			set
			{
				_numDice = value;
				NotifyPropertyChanged("NumDice");
			}
		}

		public Types.Die Die
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

		public Types.Damage Type
		{
			get { return _type; }
			set
			{
				_type = value;
				NotifyPropertyChanged("Type");
			}
		}

		public override string ToString()
		{
			return NumDice.ToString() + Methods.GetDieTypeString(Die) + Methods.GetSignedNumberString(Modifier) + " " + Methods.GetDamageTypeString(Type);
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Damage");

			xmlWriter.WriteStartElement("NumDice");
			xmlWriter.WriteString(NumDice.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Die");
			xmlWriter.WriteString(Methods.GetDieTypeString(Die));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Modifier");
			xmlWriter.WriteString(Modifier.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Type");
			xmlWriter.WriteString(Methods.GetDamageTypeString(Type));
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
						Die = Methods.GetDieTypeFromString(childNode.InnerText);
					}
					else if (childNode.Name == "Modifier")
					{
						Modifier = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Type")
					{
						Type = Methods.GetDamageTypeFromString(childNode.InnerText);
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
