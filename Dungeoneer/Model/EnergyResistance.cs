using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.Model
{
	public class EnergyResistance : Effect
	{
		public EnergyResistance()
		{
			_energyType = null;
		}

		private Types.DamageType? _energyType;

		public Types.DamageType? EnergyType
		{
			get { return _energyType; }
			set
			{
				_energyType = value;
				NotifyPropertyChanged("EnergyType");
			}
		}
	}
}
