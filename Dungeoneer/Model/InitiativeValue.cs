using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class InitiativeValue : INotifyPropertyChanged
	{
		private int? _initiativeScore;
		private int? _initiativeMod;
		private int? _initiativeRoll;
		private uint _turn;

		public InitiativeValue()
		{
			_initiativeScore = null;
			_initiativeMod = null;
			_initiativeRoll = null;
			_turn = 0;
		}

		public int? InitiativeScore
		{
			get { return _initiativeScore; }
			set
			{
				_initiativeScore = value;
				OnPropertyChanged("InitiativeScore");
			}
		}

		public int? InitiativeMod
		{
			get { return _initiativeMod; }
			set
			{
				_initiativeMod = value;
				OnPropertyChanged("InitiativeMod");
			}
		}

		public int? InitiativeRoll
		{
			get { return _initiativeRoll; }
			set
			{
				_initiativeRoll = value;
				OnPropertyChanged("InitiativeRoll");
			}
		}

		public uint Turn
		{
			get { return _turn; }
			set
			{
				_turn = value;
				OnPropertyChanged("Turn");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
