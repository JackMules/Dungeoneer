using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dungeoneer
{
	public class Actor : INotifyPropertyChanged
	{
		public Actor()
		{
			ActorName = "No Name";
			InitiativeMod = 0;
		}

		private string _actorName { get; set; }
		private int _initiativeMod { get; set; }

		public string ActorName
		{
			get { return _actorName; }
			set
			{
				_actorName = value;
				OnPropertyChanged("Name");
			}
		}

		public int InitiativeMod
		{
			get { return _initiativeMod; }
			set
			{
				_initiativeMod = value;
				OnPropertyChanged("InitiativeMod");
			}
		}

		public Actor(
			string actorName,
			int initiativeMod)
		{
			ActorName = actorName;
			InitiativeMod = initiativeMod;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public override string ToString()
		{
			return string.Format("{0} Init: {1}", ActorName, Utility.GetSignedNumberString(InitiativeMod));
		}
	}
}
