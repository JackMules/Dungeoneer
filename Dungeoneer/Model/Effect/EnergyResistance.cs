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
		public EnergyResistance()
			: base(false)
		{

		}

		private Types.Damage _energyType;

		public Types.Damage EnergyType
		{
			get { return _energyType; }
			set
			{
				_energyType = value;
				NotifyPropertyChanged("EnergyType");
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
