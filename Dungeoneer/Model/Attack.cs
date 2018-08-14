using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class Attack
	{
		public int AttackMod { get; set; }
		public Utility.Types.AttackType AttackType { get; set; }
		public int NumDamageDice { get; set; }
		public Utility.Types.DieType DamageDie { get; set; }
		public int DamageMod { get; set; }
		public int ThreatRangeMin { get; set; }
		public int CritMultiplier { get; set; }

		public Attack(){}

		public Attack(
			int attackMod,
			Utility.Types.AttackType attackType,
			int numDamageDice,
			Utility.Types.DieType damageDie,
			int damageMod,
			int threatRangeMin,
			int critMultiplier)
		{
			AttackMod = attackMod;
			AttackType = attackType;
			NumDamageDice = numDamageDice;
			DamageDie = damageDie;
			DamageMod = damageMod;
			ThreatRangeMin = threatRangeMin;
			CritMultiplier = critMultiplier;
		}
	}
}
