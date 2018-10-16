using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class DamageSet : BaseModel
	{
		public DamageSet(int amount, DamageDescriptorSet damageDescriptorSet)
		{
			_amount = amount;
			_damageDescriptorSet = damageDescriptorSet;
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
		}
	}
}
