using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class DamageReduction : INotifyPropertyChanged
	{
		private int _value;
		private Utility.Types.DamageType _type;

		public int Value
		{
			get { return _value; }
			set
			{
				_value = value;
				OnPropertyChanged("Value");
			}
		}

		public Utility.Types.DamageType DamageType
		{
			get { return _type; }
			set
			{
				_type = value;
				OnPropertyChanged("Type");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
