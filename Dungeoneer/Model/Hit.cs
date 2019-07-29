using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	[Serializable]
	public class Hit : HitPointChange
	{
		public Hit(CreatureAttributes creatureAttributes)
		{
			_damageSets = new List<DamageSet>();
			_weapon = new Weapon();
			_creatureAttributes = creatureAttributes;
		}

		public Hit(List<int> damages, Weapon weapon, CreatureAttributes creatureAttributes)
		{
			_damageSets = new List<DamageSet>();
			_weapon = weapon;
			_creatureAttributes = creatureAttributes;

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
		private CreatureAttributes _creatureAttributes;
		
		public Weapon Weapon
		{
			get { return _weapon; }
			set
			{
				_weapon = value;
				NotifyPropertyChanged("Weapon");
			}
		}

		public CreatureAttributes CreatureAttributes
		{
			get { return _creatureAttributes; }
			set
			{
				_creatureAttributes = value;
				NotifyPropertyChanged("CreatureAttributes");
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

		public override int GetHitPointChange()
		{
			return CreatureAttributes.CalculateHitPointChange(DamageSets);
		}

		public override string ToString()
		{
			List<string> damageStrs = new List<string>();
			foreach (DamageSet damageSet in DamageSets)
			{
				if (damageSet.Amount != 0)
				{
					damageStrs.Add(damageSet.ToString());
				}
			}

			string outStr = GetHitPointChange().ToString() + " damage (";
			
			outStr += String.Join(" + ", damageStrs);

			return outStr + ")";
		}
	}
}
