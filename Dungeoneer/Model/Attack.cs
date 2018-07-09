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
		public Utility.AttackType AttackType { get; set; }
		public uint NumDamageDice { get; set; }
		public Utility.DieType DamageDie { get; set; }
		public int DamageMod { get; set; }
		public uint ThreatRangeMin { get; set; }
		public uint CritMultiplier { get; set; }

		public Attack(){}

		public Attack(
			int attackMod,
			Utility.AttackType attackType,
			uint numDamageDice,
			Utility.DieType damageDie,
			int damageMod,
			uint threatRangeMin,
			uint critMultiplier)
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
