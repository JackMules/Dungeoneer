using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public class DamageTypeSelectorViewModel : BaseViewModel
	{
		public DamageTypeSelectorViewModel()
		{
			_acid = false;
			_adamantine = false;
			_bludgeoning = false;
			_chaos = false;
			_cold = false;
			_coldIron = false;
			_divine = false;
			_electricity = false;
			_epic = false;
			_evil = false;
			_fire = false;
			_force = false;
			_good = false;
			_law = false;
			_magic = false;
			_negativeEnergy = false;
			_piercing = false;
			_positiveEnergy = false;
			_silver = false;
			_slashing = false;
			_subdual = false;
			_sonic = false;
		}

		private bool _acid;
		private bool _adamantine;
		private bool _bludgeoning;
		private bool _chaos;
		private bool _cold;
		private bool _coldIron;
		private bool _divine;
		private bool _electricity;
		private bool _epic;
		private bool _evil;
		private bool _fire;
		private bool _force;
		private bool _good;
		private bool _law;
		private bool _magic;
		private bool _negativeEnergy;
		private bool _piercing;
		private bool _positiveEnergy;
		private bool _silver;
		private bool _slashing;
		private bool _sonic;
		private bool _subdual;

		public Model.DamageDescriptorSet GetDamageDescriptorSet()
		{
			Model.DamageDescriptorSet damage = new Model.DamageDescriptorSet
			{
				Acid = Acid,
				Adamantine = Adamantine,
				Bludgeoning = Bludgeoning,
				Chaos = Chaos,
				Cold = Cold,
				ColdIron = ColdIron,
				Divine = Divine,
				Electricity = Electricity,
				Epic = Epic,
				Evil = Evil,
				Fire = Fire,
				Force = Force,
				Good = Good,
				Law = Law,
				Magic = Magic,
				NegativeEnergy = NegativeEnergy,
				Piercing = Piercing,
				PositiveEnergy = PositiveEnergy,
				Silver = Silver,
				Slashing = Slashing,
				Sonic = Sonic,
				Subdual = Subdual,
			};

			return damage;
		}

		public void SetFromDamageDescriptorSet(Model.DamageDescriptorSet damageDescriptorSet)
		{
			Acid = damageDescriptorSet.Acid;
			Adamantine = damageDescriptorSet.Adamantine;
			Bludgeoning = damageDescriptorSet.Bludgeoning;
			Chaos = damageDescriptorSet.Chaos;
			Cold = damageDescriptorSet.Cold;
			ColdIron = damageDescriptorSet.ColdIron;
			Divine = damageDescriptorSet.Divine;
			Electricity = damageDescriptorSet.Electricity;
			Epic = damageDescriptorSet.Epic;
			Evil = damageDescriptorSet.Evil;
			Fire = damageDescriptorSet.Fire;
			Force = damageDescriptorSet.Force;
			Good = damageDescriptorSet.Good;
			Law = damageDescriptorSet.Law;
			Magic = damageDescriptorSet.Magic;
			NegativeEnergy = damageDescriptorSet.NegativeEnergy;
			Piercing = damageDescriptorSet.Piercing;
			PositiveEnergy = damageDescriptorSet.PositiveEnergy;
			Silver = damageDescriptorSet.Silver;
			Slashing = damageDescriptorSet.Slashing;
			Sonic = damageDescriptorSet.Sonic;
			Subdual = damageDescriptorSet.Subdual;
		}

		public bool Acid
		{
			get { return _acid; }
			set { SetField(ref _acid, value); }
		}

		public bool Adamantine
		{
			get { return _adamantine; }
			set { SetField(ref _adamantine, value); }
		}

		public bool Bludgeoning
		{
			get { return _bludgeoning; }
			set { SetField(ref _bludgeoning, value); }
		}

		public bool Chaos
		{
			get { return _chaos; }
			set { SetField(ref _chaos, value); }
		}

		public bool Cold
		{
			get { return _cold; }
			set { SetField(ref _cold, value); }
		}

		public bool ColdIron
		{
			get { return _coldIron; }
			set { SetField(ref _coldIron, value); }
		}

		public bool Divine
		{
			get { return _divine; }
			set { SetField(ref _divine, value); }
		}

		public bool Electricity
		{
			get { return _electricity; }
			set { SetField(ref _electricity, value); }
		}
		public bool Epic
		{
			get { return _epic; }
			set { SetField(ref _epic, value); }
		}

		public bool Evil
		{
			get { return _evil; }
			set { SetField(ref _evil, value); }
		}

		public bool Fire
		{
			get { return _fire; }
			set { SetField(ref _fire, value); }
		}

		public bool Force
		{
			get { return _force; }
			set { SetField(ref _force, value); }
		}

		public bool Good
		{
			get { return _good; }
			set { SetField(ref _good, value); }
		}

		public bool Law
		{
			get { return _law; }
			set { SetField(ref _law, value); }
		}

		public bool Magic
		{
			get { return _magic; }
			set { SetField(ref _magic, value); }
		}

		public bool NegativeEnergy
		{
			get { return _negativeEnergy; }
			set { SetField(ref _negativeEnergy, value); }
		}

		public bool Piercing
		{
			get { return _piercing; }
			set { SetField(ref _piercing, value); }
		}

		public bool PositiveEnergy
		{
			get { return _positiveEnergy; }
			set { SetField(ref _positiveEnergy, value); }
		}

		public bool Silver
		{
			get { return _silver; }
			set { SetField(ref _silver, value); }
		}

		public bool Slashing
		{
			get { return _slashing; }
			set { SetField(ref _slashing, value); }
		}

		public bool Sonic
		{
			get { return _sonic; }
			set { SetField(ref _sonic, value); }
		}

		public bool Subdual
		{
			get { return _subdual; }
			set { SetField(ref _subdual, value); }
		}
	}
}
