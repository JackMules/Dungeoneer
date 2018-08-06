using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class Encounter
	{
		public Encounter()
		{
			_initiativeTrack = new ObservableCollection<ViewModel.InitiativeCardViewModel>();
		}

		private ObservableCollection<ViewModel.InitiativeCardViewModel> _initiativeTrack;

		public ObservableCollection<ViewModel.InitiativeCardViewModel> InitiativeTrack
		{
			get { return _initiativeTrack; }
			set { _initiativeTrack = value; }
		}

		public void AddActor(Model.Actor actor)
		{
			ViewModel.ActorViewModel actorViewModel = ViewModel.ActorViewModelFactory.GetActorViewModel(actor);
			InitiativeTrack.Add( new ViewModel.InitiativeCardViewModel() { ActorViewModel = actorViewModel } );
		}

		public uint GetNumberOfActorsWithName(string actorName)
		{
			uint count = 0;
			foreach (ViewModel.InitiativeCardViewModel initCard in InitiativeTrack)
			{
				if (initCard.ActorViewModel.ActorName == actorName)
				{
					++count;
				}
			}
			return count;
		}
	}
}
