using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	[Serializable]
	public class Heal : HitPointChange
	{
		public Heal(int amount)
		{
			_amount = amount;
		}

		private int _amount;

		public int Amount
		{
			get { return _amount; }
			set
			{
				_amount = value;
				NotifyPropertyChanged("Amount");
			}
		}

		public override int GetHitPointChange()
		{
			return Amount;
		}

		public override string ToString()
		{
			return "+" + Amount.ToString() + "hp (healing)";
		}
	}
}
