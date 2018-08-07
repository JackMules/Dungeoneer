using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public class EncounterViewModel : INotifyPropertyChanged
	{
		public EncounterViewModel()
		{
			_initiativeTrack = new Utility.FullyObservableCollection<ViewModel.InitiativeCardViewModel>();

			CollectionEventList = new List<NotifyCollectionChangedEventArgs>();
			ItemEventList = new List<Utility.ItemPropertyChangedEventArgs>();
			_initiativeTrack.CollectionChanged += (o, e) => CollectionEventList.Add(e);
			_initiativeTrack.ItemPropertyChanged += (o, e) => ItemEventList.Add(e);
		}

		private List<NotifyCollectionChangedEventArgs> CollectionEventList;
		private List<Utility.ItemPropertyChangedEventArgs> ItemEventList;
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private Utility.FullyObservableCollection<ViewModel.InitiativeCardViewModel> _initiativeTrack;

		public Utility.FullyObservableCollection<ViewModel.InitiativeCardViewModel> InitiativeTrack
		{
			get { return _initiativeTrack; }
			set
			{
				_initiativeTrack = value;
				OnPropertyChanged("InitiativeTrack");
			}
		}

		public void AddActor(Model.Actor actor)
		{
			ViewModel.ActorViewModel actorViewModel = ViewModel.ActorViewModelFactory.GetActorViewModel(actor);
			InitiativeTrack.Add( new ViewModel.InitiativeCardViewModel() { ActorViewModel = actorViewModel } );
		}

		public void AddInitiativeCard(ViewModel.InitiativeCardViewModel initCard)
		{
			InitiativeTrack.Add(initCard);
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
