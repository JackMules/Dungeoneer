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
			_damageDescriptorSet = new DamageDescriptorSet();
		}

		private int _numDice;
		private Types.Die _die;
		private int _modifier;
		private DamageDescriptorSet _damageDescriptorSet;

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

		public DamageDescriptorSet DamageDescriptorSet
		{
			get { return _damageDescriptorSet; }
			set
			{
				_damageDescriptorSet = value;
				NotifyPropertyChanged("DamageDescriptorSet");
			}
		}

		public override string ToString()
		{
			return NumDice.ToString() + Methods.GetDieTypeString(Die) + Methods.GetSignedNumberString(Modifier) + " " + DamageDescriptorSet.ToString();
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

			xmlWriter.WriteStartElement("DamageDescriptorSet");
			DamageDescriptorSet.WriteXML(xmlWriter);
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
					else if (childNode.Name == "DamageDescriptorSet")
					{
						DamageDescriptorSet damageDescriptorSet = new DamageDescriptorSet();
						damageDescriptorSet.ReadXML(childNode);
						DamageDescriptorSet = damageDescriptorSet;
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
