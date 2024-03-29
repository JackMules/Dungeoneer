﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Dungeoneer.Utility;
using System.Windows.Data;

namespace Dungeoneer.ViewModel
{
	public class EncounterViewModel : BaseViewModel
	{
		public EncounterViewModel()
		{
			_initiativeTrack = new FullyObservableCollection<InitiativeCardViewModel>();
			_round = 1;
			_nextRound = new RelayCommand(ExecuteNextRound, CheckRound);
			_clear = new Command(ExecuteClear);
			_start = new Command(ExecuteStart);
			_save = new Command(ExecuteSave);
			_load = new Command(ExecuteLoad);
			_weaponList = new FullyObservableCollection<Model.WeaponSet>();
			_weaponList.CollectionChanged += _weaponList_CollectionChanged;

			_initiativeTrackCVS = new CollectionViewSource();
			_initiativeTrackCVS.Source = _initiativeTrack;
			_initiativeTrackCVS.SortDescriptions.Add(new SortDescription("ActorViewModel.Active", ListSortDirection.Descending));
			_initiativeTrackCVS.SortDescriptions.Add(new SortDescription("TurnEnded", ListSortDirection.Ascending));
			_initiativeTrackCVS.SortDescriptions.Add(new SortDescription("InitiativeValueViewModel.InitiativeValue.Score", ListSortDirection.Descending));
			_initiativeTrackCVS.SortDescriptions.Add(new SortDescription("InitiativeValueViewModel.InitiativeValue.Adjust", ListSortDirection.Descending));
			_initiativeTrackCVS.SortDescriptions.Add(new SortDescription("InitiativeValueViewModel.InitiativeValue.Modifier", ListSortDirection.Descending));
			_initiativeTrackCVS.SortDescriptions.Add(new SortDescription("InitiativeValueViewModel.InitiativeValue.Roll", ListSortDirection.Descending));
			_initiativeTrackCVS.IsLiveSortingRequested = true;

			InitiativeTrackView.CollectionChanged += InitiativeTrackView_CollectionChanged;
		}

		internal CollectionViewSource InitiativeTrackCVS
		{
			get { return _initiativeTrackCVS; }
			set { SetField(ref _initiativeTrackCVS, value); }
		}

		public ICollectionView InitiativeTrackView
		{
			get { return InitiativeTrackCVS.View; }
		}

		private FullyObservableCollection<InitiativeCardViewModel> _initiativeTrack;
		private CollectionViewSource _initiativeTrackCVS;
		private int _round;
		private RelayCommand _nextRound;
		private Command _clear;
		private Command _start;
		private Command _save;
		private Command _load;
		private FullyObservableCollection<Model.WeaponSet> _weaponList;

		private void _weaponList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			OnWeaponListChange?.Invoke(_weaponList);
		}

		private void InitiativeTrackView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (_initiativeTrack.Count > 0)
			{
				InitiativeTrackView.MoveCurrentToFirst();
				if (InitiativeTrackView.CurrentItem is InitiativeCardViewModel)
				{
					InitiativeCardViewModel initiativeCardViewModel = InitiativeTrackView.CurrentItem as InitiativeCardViewModel;
					OnInitiativeTrackChange?.Invoke(initiativeCardViewModel.ActorViewModel.ActorName);
				}
			}
		}

		public int Round
		{
			get { return _round; }
			set { SetField(ref _round, value); }
		}

		public RelayCommand NextRound
		{
			get { return _nextRound; }
		}

		private void ExecuteNextRound()
		{
			++Round;

			foreach (InitiativeCardViewModel initCard in InitiativeTrack)
			{
				initCard.StartNewRound();
			}
		}

		private bool CheckRound()
		{
			if (InitiativeTrack.Count > 0)
			{
				bool roundComplete = true;
				foreach (InitiativeCardViewModel initCard in InitiativeTrack)
				{
					if (!initCard.TurnEnded && !initCard.Delayed && !initCard.Readied)
					{
						roundComplete = false;
					}
				}

				return roundComplete;
			}
			else
			{
				return false;
			}
		}

		public int XPEarned
		{
			get
			{
				int xpTotal = 0;
				foreach (var initiativeCard in InitiativeTrack)
				{
					var initCard = initiativeCard as CreatureInitiativeCardViewModel;
					if (initCard != null &&
						initCard.ActorViewModel.Dead)
					{
						xpTotal += Methods.CalculateXP(initCard.ActorViewModel.ChallengeRating);
					}
				}
				return xpTotal;
			}
		}

		public FullyObservableCollection<InitiativeCardViewModel> InitiativeTrack
		{
			get { return _initiativeTrack; }
			set { SetField(ref _initiativeTrack, value); }
		}

		public delegate void WeaponListChange(FullyObservableCollection<Model.WeaponSet> weaponList);

		public WeaponListChange OnWeaponListChange { get; set; }

		public delegate void InitiativeTrackChange(string actorName);

		public InitiativeTrackChange OnInitiativeTrackChange { get; set; }

		public FullyObservableCollection<Model.WeaponSet> WeaponList
		{
			get { return _weaponList; }
			set { SetField(ref _weaponList, value); }
		}

		public void AddWeaponSet(Model.WeaponSet weaponSet)
		{
			bool found = false;
			for (int i = 0; i < WeaponList.Count; ++i)
			{
				if (WeaponList[i].Owner == weaponSet.Owner)
				{
					WeaponList[i] = weaponSet;
					found = true;
				}
			}

			if (!found)
			{
				WeaponList.Add(weaponSet);
			}
		}

		public void Delete(InitiativeCardViewModel initCardViewModel)
		{
			InitiativeTrack.Remove(initCardViewModel);
		}

		public void AddActor(Model.Actor actor, string displayName)
		{
			ActorInitiativeViewModel actorViewModel = ActorInitiativeViewModelFactory.GetActorViewModel(actor, this);
			actorViewModel.DisplayName = displayName;
			InitiativeCardViewModel initCardViewModel = InitiativeCardViewModelFactory.GetInitiativeCardViewModel(actorViewModel);

			AddInitiativeCard(initCardViewModel);
		}

		public void UpdateActor(Model.Actor updatedActor)
		{
			foreach (InitiativeCardViewModel initCard in InitiativeTrack)
			{
				if (initCard.ActorViewModel.Actor.ActorName == updatedActor.ActorName &&
					initCard.ActorViewModel.Actor.GetType() == updatedActor.GetType())
				{
					if (initCard.ActorViewModel is PlayerActorInitiativeViewModel)
					{
						PlayerActorInitiativeViewModel newViewModel = new PlayerActorInitiativeViewModel(updatedActor as Model.PlayerActor);
						newViewModel.DisplayName = initCard.ActorViewModel.DisplayName;
						(initCard as PlayerActorInitiativeCardViewModel).ActorViewModel = newViewModel;
					}
				}
			}
		}

		public void AddInitiativeCard(InitiativeCardViewModel initCardViewModel)
		{
			if (initCardViewModel is PlayerActorInitiativeCardViewModel)
			{
				PlayerActorInitiativeCardViewModel playerCardVM = initCardViewModel as PlayerActorInitiativeCardViewModel;
				playerCardVM.OnWeaponsChange += AddWeaponSet;
				InitiativeTrack.Add(playerCardVM);

				Model.WeaponSet weaponSet = new Model.WeaponSet(playerCardVM.ActorViewModel.Actor);
				AddWeaponSet(weaponSet);
			}
			else
			{
				InitiativeTrack.Add(initCardViewModel);
			}
		}

		public int GetNumberOfActorsWithName(string actorName)
		{
			int count = 0;
			foreach (InitiativeCardViewModel initCard in InitiativeTrack)
			{
				if (initCard.ActorViewModel.ActorName == actorName)
				{
					++count;
				}
			}
			return count;
		}

		public Command Save
		{
			get { return _save; }
		}

		public void ExecuteSave()
		{
			SaveFileDialog dlg = new SaveFileDialog
			{
				FileName = "Encounter",
				DefaultExt = ".xml",
				Filter = "XML documents (.xml)|*.xml"
			};

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				XmlWriter xmlWriter = XmlWriter.Create(dlg.FileName);

				xmlWriter.WriteStartDocument();
				xmlWriter.WriteStartElement("Encounter");
				xmlWriter.WriteAttributeString("Round", Round.ToString());

				foreach (InitiativeCardViewModel initCard in InitiativeTrack)
				{
					initCard.WriteXML(xmlWriter);
				}

				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndDocument();
				xmlWriter.Close();
			}
		}

		public Command Clear
		{
			get { return _clear; }
		}

		public void ExecuteClear()
		{
			Round = 1;
			InitiativeTrack.Clear();
		}

		public Command Start
		{
			get { return _start; }
		}

		public void ExecuteStart()
		{
			var result = MessageBox.Show("Roll for initiative!");

			if (result == DialogResult.OK)
			{
				Round = 1;

				foreach (InitiativeCardViewModel cardVM in InitiativeTrack)
				{
					cardVM.StartEncounter();
				}
			}
		}

		public Command Load
		{
			get { return _load; }
		}

		public void ExecuteLoad()
		{
			ExecuteClear();

			OpenFileDialog dlg = new OpenFileDialog
			{
				FileName = "Encounter",
				DefaultExt = ".xml",
				Filter = "XML documents (.xml)|*.xml"
			};

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					XmlDocument xmlDoc = new XmlDocument();
					xmlDoc.Load(dlg.FileName);

					XmlAttributeCollection attrColl = xmlDoc.DocumentElement.Attributes;
					XmlAttribute round = (XmlAttribute)attrColl.GetNamedItem("Round");

					Round = Convert.ToInt32(round.Value);

					foreach (XmlNode xmlNode in xmlDoc.DocumentElement)
					{
						AddInitiativeCard(InitiativeCardViewModelFactory.GetInitiativeCardViewModel(xmlNode, this));
					}
				}
				catch (XmlException e)
				{
					MessageBox.Show(e.ToString());
				}
			}
		}
	}
}
