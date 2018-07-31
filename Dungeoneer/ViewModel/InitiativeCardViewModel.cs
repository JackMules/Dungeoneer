using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public class InitiativeCardViewModel : BaseViewModel
	{
		public InitiativeCardViewModel()
		{
		}

		private Model.InitiativeCard _initiativeCard;

		public Model.InitiativeCard InitiativeCard
		{
			get { return _initiativeCard; }
			set
			{
				_initiativeCard = value;
				NotifyPropertyChanged("InitiativeCard");
			}
		}

		private ViewModel.ActorViewModel _actorViewModel;

		public ViewModel.ActorViewModel ActorViewModel
		{
			get { return _actorViewModel; }
			set
			{
				_actorViewModel = value;
				NotifyPropertyChanged("ActorViewModel");
			}
		}
	}
}
