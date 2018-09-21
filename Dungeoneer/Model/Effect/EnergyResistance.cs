using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.Model.Effect
{
	public class EnergyResistance : CreatureEffect
	{
		public EnergyResistance(Types.Damage energyType, int value)
			: base(false)
		{
			_energyType = energyType;
			_value = value;
		}

		private Types.Damage _energyType;
		private int _value;

		public Types.Damage EnergyType
		{
			get { return _energyType; }
			set
			{
				_energyType = value;
				NotifyPropertyChanged("EnergyType");
			}
		}

		public int Value
		{
			get { return _value; }
			set
			{
				_value = value;
				NotifyPropertyChanged("Value");
			}
		}

		public override bool Expired()
		{
			return (Value <= 0);
		}

		public override Creature ApplyTo(Creature creature)
		{
			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartAttribute("EnergyResistance");
		}
	}
}
