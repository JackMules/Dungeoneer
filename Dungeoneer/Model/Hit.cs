using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	[Serializable]
	public class Hit : BaseModel
	{
		public Hit(Creature creature)
		{
			_damageSets = new List<DamageSet>();
			_weapon = new Weapon();
			_creature = creature;
		}

		public Hit(List<int> damages, Weapon weapon, Creature creature)
		{
			_damageSets = new List<DamageSet>();
			_weapon = weapon;
			_creature = creature;

			for (int d = 0; d < damages.Count; ++d)
			{
				// If there is a corresponding descriptor set
				if (weapon.DamageDescriptorSets.Count > d)
				{
					_damageSets.Add(new DamageSet(damages[d], weapon.DamageDescriptorSets[d]));
				}
			}
		}

		public Hit(Hit other)
		{
			DamageSets = new List<DamageSet>(other.DamageSets);
		}

		private List<DamageSet> _damageSets;
		private Weapon _weapon;
		private Creature _creature;
		
		public Weapon Weapon
		{
			get { return _weapon; }
			set
			{
				_weapon = value;
				NotifyPropertyChanged("Weapon");
			}
		}

		public Creature Creature
		{
			get { return _creature; }
			set
			{
				_creature = value;
				NotifyPropertyChanged("Creature");
			}
		}

		public List<DamageSet> DamageSets
		{
			get { return _damageSets; }
			private set
			{
				_damageSets = value;
				NotifyPropertyChanged("DamageSets");
			}
		}

		public int GetHitPointChange()
		{
			return Creature.GetEffectiveAttributes().CalculateHitPointChange(DamageSets);
		}
	}
}
