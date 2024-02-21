using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dungeoneer.Model
{
	[Serializable]
	public class DamageSet : BaseModel
	{
		public DamageSet(int amount, DamageDescriptorSet damageDescriptorSet)
		{
			_amount = amount;
			_damageDescriptorSet = damageDescriptorSet;
		}

		public DamageSet(DamageSet other)
		{
			Amount = other.Amount;
			DamageDescriptorSet = new DamageDescriptorSet(other.DamageDescriptorSet);
		}

		public DamageSet(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
		}

		private int _amount;
		private DamageDescriptorSet _damageDescriptorSet;

		public int Amount
		{
			get { return _amount; }
			set
			{
				_amount = value;
				NotifyPropertyChanged("Amount");
			}
		}

		public DamageDescriptorSet DamageDescriptorSet
		{
			get { return _damageDescriptorSet; }
			private set
			{
				_damageDescriptorSet = value;
				NotifyPropertyChanged("DamageSet");
			}
		}

		public override string ToString()
		{
			return Amount.ToString() + " " + DamageDescriptorSet.ToString();
		}

		public virtual void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("DamageSet");
			
			xmlWriter.WriteStartElement("Amount");
			xmlWriter.WriteString(Amount.ToString());
			xmlWriter.WriteEndElement();

			DamageDescriptorSet.WriteXML(xmlWriter);

			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			foreach (XmlNode childNode in xmlNode.ChildNodes)
			{
				if (childNode.Name == "Amount")
				{
					Amount = Convert.ToInt32(childNode.InnerText);
				}
				else if (childNode.Name == "DamageDescriptorSet")
				{
					DamageDescriptorSet = new DamageDescriptorSet(childNode);
				}
			}
		}
	}
}
