using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class CreatureInitiativeCardViewModel : InitiativeCardViewModel
	{
		public CreatureInitiativeCardViewModel()
		{

		}

		private FullyObservableCollection<Model.WeaponSet> _weaponList;

		public new NonPlayerActorInitiativeViewModel ActorViewModel
		{
			get { return base.ActorViewModel as NonPlayerActorInitiativeViewModel; }
			set
			{
				base.ActorViewModel = value;
				NotifyPropertyChanged("ActorViewModel");
			}
		}

		public FullyObservableCollection<Model.WeaponSet> WeaponList
		{
			get { return _weaponList; }
			set
			{
				_weaponList = value;
				NotifyPropertyChanged("WeaponList");
			}
		}
	}
}
