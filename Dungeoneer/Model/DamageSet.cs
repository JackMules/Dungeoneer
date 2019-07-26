using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	[Serializable]
	public class DamageSet : BaseModel
	{
		public DamageSet(int amount, DamageDescriptorSet damageDescriptorSet)
		{
			_amount = amount;
			_damageDescriptorSet = damageDescriptorSet;
		}

		public DamageSet(DamageSet other)
		{
			Amount = other.Amount;
			DamageDescriptorSet = new DamageDescriptorSet(other.DamageDescriptorSet);
		}

		private int _amount;
		private DamageDescriptorSet _damageDescriptorSet;

		public int Amount
		{
			get { return _amount; }
			set
			{
				_amount = value;
				NotifyPropertyChanged("Amount");
			}
		}

		public DamageDescriptorSet DamageDescriptorSet
		{
			get { return _damageDescriptorSet; }
			private set
			{
				_damageDescriptorSet = value;
				NotifyPropertyChanged("DamageSet");
			}
		}

		public override string ToString()
		{
			return Amount.ToString() + " " + DamageDescriptorSet.ToString();
		}
	}
}
