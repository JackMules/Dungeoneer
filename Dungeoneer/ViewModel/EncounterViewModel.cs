using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Dungeoneer.ViewModel
{
	public class EncounterViewModel : BaseViewModel
	{
		private Utility.FullyObservableCollection<InitiativeCardViewModel> _initiativeTrack;
		private int _round;
		private RelayCommand _nextRound;
		private Command _clear;
		private Command _save;
		private Command _load;

		public EncounterViewModel()
		{
			_initiativeTrack = new Utility.FullyObservableCollection<InitiativeCardViewModel>();
			_round = 1;
			_nextRound = new RelayCommand(ExecuteNextRound, CheckRound);
			_clear = new Command(ExecuteClear);
			_save = new Command(ExecuteSave);
			_load = new Command(ExecuteLoad);
		}

		public int Round
		{
			get { return _round; }
			set
			{
				_round = value;
				NotifyPropertyChanged("Round");
			}
		}

		public RelayCommand NextRound
		{
			get { return _nextRound; }
		}

		private void ExecuteNextRound()
		{
			++Round;

			foreach (InitiativeCardViewModel initCard in _initiativeTrack)
			{
				initCard.TurnEnded = false;
			}
		}

		private bool CheckRound()
		{
			bool roundComplete = true;
			foreach (InitiativeCardViewModel initCard in _initiativeTrack)
			{
				if (!initCard.TurnEnded && !initCard.Delayed && !initCard.Readied)
				{
					roundComplete = false;
				}
			}

			return roundComplete;
		}
		
		public Utility.FullyObservableCollection<InitiativeCardViewModel> InitiativeTrack
		{
			get { return _initiativeTrack; }
			set
			{
				_initiativeTrack = value;
				NotifyPropertyChanged("InitiativeTrack");
			}
		}

		public void AddActor(Model.Actor actor)
		{
			ActorViewModel actorViewModel = ActorViewModelFactory.GetActorViewModel(actor);
			InitiativeTrack.Add( new InitiativeCardViewModel() { ActorViewModel = actorViewModel } );
		}

		public void AddInitiativeCard(InitiativeCardViewModel initCard)
		{
			InitiativeTrack.Add(initCard);
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
			InitiativeTrack.Clear();
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
						if (xmlNode.Name == "InitiativeCard")
						{
							InitiativeCardViewModel initCard = new InitiativeCardViewModel();
							initCard.ReadXML(xmlNode);
							InitiativeTrack.Add(initCard);
						}
					}
				}
				catch (System.Xml.XmlException e)
				{
					MessageBox.Show(e.ToString());
				}
			}
		}
	}
}
