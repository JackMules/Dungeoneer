using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.Model.Effect
{
	public class EnergyResistance : Effect
	{
		public EnergyResistance()
		{
			_energyType = null;
		}

		private Types.Damage? _energyType;

		public Types.Damage? EnergyType
		{
			get { return _energyType; }
			set
			{
				_energyType = value;
				NotifyPropertyChanged("EnergyType");
			}
		}

		public override Creature DoPerTurnBehaviour(Creature creature)
		{
			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartAttribute("EnergyResistance");
		}
	}
}
