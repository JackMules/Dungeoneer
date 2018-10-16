using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class Hit : BaseModel
	{
		public Hit(List<int> damages, Weapon weapon)
		{
			_damageSets = new List<DamageSet>();

			for (int d = 0; d < damages.Count; ++d)
			{
				// If there is a corresponding descriptor set
				if (weapon.DamageDescriptorSets.Count > d)
				{
					_damageSets.Add(new DamageSet(damages[d], weapon.DamageDescriptorSets[d]));
				}
			}
		}

		private List<DamageSet> _damageSets;

		public List<DamageSet> DamageSets
		{
			get { return _damageSets; }
		}
	}
}
