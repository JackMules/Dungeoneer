using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class EnergyTypeSelectorViewModel : BaseViewModel
	{
		public EnergyTypeSelectorViewModel()
		{
			_acid = false;
			_cold = false;
			_electricity = false;
			_fire = false;
			_force = false;
			_negativeEnergy = false;
			_positiveEnergy = false;
			_sonic = false;
		}

		private bool _acid;
		private bool _cold;
		private bool _electricity;
		private bool _fire;
		private bool _force;
		private bool _negativeEnergy;
		private bool _positiveEnergy;
		private bool _sonic;

		public Types.Damage GetEnergyType()
		{
			if (Acid) return Types.Damage.Acid;
			else if (Cold) return Types.Damage.Cold;
			else if (Electricity) return Types.Damage.Electricity;
			else if (Fire) return Types.Damage.Fire;
			else if (Force) return Types.Damage.Force;
			else if (NegativeEnergy) return Types.Damage.NegativeEnergy;
			else if (PositiveEnergy) return Types.Damage.PositiveEnergy;
			else return Types.Damage.Sonic;
		}

		public void SetEnergyType(Types.Damage energyType)
		{
			switch (energyType)
			{
			case Types.Damage.Acid:						Acid = true; break;
			case Types.Damage.Cold:						Cold = true; break;
			case Types.Damage.Electricity:		Electricity = true; break;
			case Types.Damage.Fire:						Fire = true; break;
			case Types.Damage.Force:					Force = true; break;
			case Types.Damage.NegativeEnergy: NegativeEnergy = true; break;
			case Types.Damage.PositiveEnergy: PositiveEnergy = true; break;
			case Types.Damage.Sonic:					Sonic = true; break;
			}
		}

		private void ResetAll()
		{
			Acid = false;
			Cold = false;
			Electricity = false;
			Fire = false;
			Force = false;
			NegativeEnergy = false;
			PositiveEnergy = false;
			Sonic = false;
		}

		public bool Acid
		{
			get { return _acid; }
			set
			{
				if (SetField(ref _acid, value))
				{
					ResetAll();
				}
			}
		}
		
		public bool Cold
		{
			get { return _cold; }
			set
			{
				if (SetField(ref _cold, value))
				{
					ResetAll();
				}
			}
		}

		public bool Electricity
		{
			get { return _electricity; }
			set
			{
				if (SetField(ref _electricity, value))
				{
					ResetAll();
				}
			}
		}

		public bool Fire
		{
			get { return _fire; }
			set
			{
				if (SetField(ref _fire, value))
				{
					ResetAll();
				}
			}
		}

		public bool Force
		{
			get { return _force; }
			set
			{
				if (SetField(ref _force, value))
				{
					ResetAll();
				}
			}
		}
		
		public bool NegativeEnergy
		{
			get { return _negativeEnergy; }
			set
			{
				if (SetField(ref _negativeEnergy, value))
				{
					ResetAll();
				}
			}
		}

		public bool PositiveEnergy
		{
			get { return _positiveEnergy; }
			set
			{
				if (SetField(ref _positiveEnergy, value))
				{
					ResetAll();
				}
			}
		}
		
		public bool Sonic
		{
			get { return _sonic; }
			set
			{
				if (SetField(ref _sonic, value))
				{
					ResetAll();
				}
			}
		}
	}
}
