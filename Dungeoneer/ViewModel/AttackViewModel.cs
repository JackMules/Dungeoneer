using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public class AttackViewModel
	{
		private Model.Attack obj = new Model.Attack();

		public string TxtAttackMod
		{
			get
			{
				string number = Convert.ToString(obj.AttackMod);
				string sign = obj.AttackMod >= 0 ? "+" : "-";
				return sign + number;
			}
			set
			{
				obj.AttackMod = Convert.ToInt16(value);
			}
		}

		public string TxtAttackType
		{
			get
			{
				return Utility.GetAttackTypeString(obj.AttackType);
			}
			set
			{
				obj.AttackType = Utility.GetAttackTypeFromString(value);
			}
		}

		public string TxtNumDamageDice
		{
			get
			{
				return Convert.ToString(obj.NumDamageDice);
			}
			set
			{
				obj.NumDamageDice = Convert.ToUInt16(value);
			}
		}

		public string TxtDamageDie
		{
			get
			{
				return Utility.GetDieTypeString(obj.DamageDie);
			}
			set
			{
				obj.DamageDie = Utility.GetDieTypeFromString(value);
			}
		}

		public string TxtDamageMod
		{
			get
			{
				string number = Convert.ToString(obj.DamageMod);
				string sign = obj.DamageMod >= 0 ? "+" : "-";
				return sign + number;
			}
			set
			{
				obj.DamageMod = Convert.ToInt16(value);
			}
		}

		public string TxtThreatRange
		{
			get
			{
				string threatRange = "20";
				if (obj.ThreatRangeMin != 20)
				{
					threatRange = Convert.ToString(obj.ThreatRangeMin) + "-" + threatRange;
				}
				return threatRange;
			}
			set
			{
				string min = value.Substring(0, 2);
				obj.ThreatRangeMin = Convert.ToUInt16(min);
			}
		}

		public string TxtCritMultiplier
		{
			get
			{
				return "x" + Convert.ToString(obj.CritMultiplier);
			}
			set
			{
				string multiplier = value.Substring(1, 1);
				obj.CritMultiplier = Convert.ToUInt16(multiplier);
			}
		}
	}
}
