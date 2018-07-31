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
			ViewModel.ActorViewModel actorViewModel = new ViewModel.ActorViewModel { Actor = actor };
			InitiativeTrack.Add( new ViewModel.InitiativeCardViewModel() { ActorViewModel = actorViewModel } );
		}
	}
}
