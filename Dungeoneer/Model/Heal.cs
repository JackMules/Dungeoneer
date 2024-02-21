using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dungeoneer.Model
{
	[Serializable]
	public class Heal : BaseModel, IHitPointChange
	{
		public Heal(int amount)
		{
			_amount = amount;
		}

		private int _amount;

		public int Amount
		{
			get { return _amount; }
			set
			{
				_amount = value;
				NotifyPropertyChanged("Amount");
			}
		}

		public int GetHitPointChange()
		{
			return Amount;
		}

		public override string ToString()
		{
			return "+" + Amount.ToString() + "hp (healing)";
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Heal");
			xmlWriter.WriteString(Amount.ToString());
			xmlWriter.WriteEndElement();
		}
	}
}
