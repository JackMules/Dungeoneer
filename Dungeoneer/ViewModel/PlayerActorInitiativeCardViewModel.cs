using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class PlayerActorInitiativeCardViewModel : InitiativeCardViewModel
	{
		public PlayerActorInitiativeCardViewModel()
		{

		}

		public new PlayerActorInitiativeViewModel ActorViewModel
		{
			get { return base.ActorViewModel as PlayerActorInitiativeViewModel; }
			set
			{
				base.ActorViewModel = value;
				NotifyPropertyChanged("ActorViewModel");
			}
		}

		public delegate void WeaponsChange(Model.WeaponSet weaponSet);

		public WeaponsChange OnWeaponsChange { get; set; }

		public ObservableCollection<Model.Weapon> Weapons
		{
			get
			{
				return ActorViewModel.Weapons;
			}
			set
			{
				ActorViewModel.Weapons = value;
				NotifyPropertyChanged("Weapons");
				Model.WeaponSet weaponSet = new Model.WeaponSet(ActorViewModel.Actor);
				OnWeaponsChange?.Invoke(weaponSet);
			}
		}
	}
}
