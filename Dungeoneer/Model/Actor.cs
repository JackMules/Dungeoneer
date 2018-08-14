using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dungeoneer.Model
{
	public class Actor : INotifyPropertyChanged
	{
		public Actor()
		{
			DisplayName = "no display name";
			ActorName = "no name";
			InitiativeMod = 0;
		}

		private string _displayName { get; set; }
		private string _actorName { get; set; }
		private int _initiativeMod { get; set; }
		private Utility.FullyObservableCollection<Condition> _conditions;

		public string DisplayName
		{
			get { return _displayName; }
			set
			{
				_displayName = value;
				OnPropertyChanged("DisplayName");
			}
		}

		public string ActorName
		{
			get { return _actorName; }
			set
			{
				_actorName = value;
				OnPropertyChanged("ActorName");
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

		public Utility.FullyObservableCollection<Condition> Conditions
		{
			get { return _conditions; }
			set
			{
				_conditions = value;
				OnPropertyChanged("Conditions");
			}
		}

		public Actor(
			string displayName,
			string actorName,
			int initiativeMod)
		{
			DisplayName = displayName;
			ActorName = actorName;
			InitiativeMod = initiativeMod;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
