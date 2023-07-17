using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class InitiativeCardViewModel : BaseViewModel
	{
		public InitiativeCardViewModel()
		{
			_initiativeValueViewModel = new InitiativeValueViewModel();
			InitCommands();
		}

		private InitiativeValueViewModel _initiativeValueViewModel;
		private ActorInitiativeViewModel _actorViewModel;
		private Command _openInitiativeDialog;
		private Command _advanceTurnState;
		private Command _incrementInitiativeAdjust;
		private Command _decrementInitiativeAdjust;

		protected virtual void InitCommands()
		{
			_openInitiativeDialog = new Command(ExecuteOpenInitiativeDialog);
			_advanceTurnState = new Command(ExecuteAdvanceTurnState);
			_incrementInitiativeAdjust = new Command(ExecuteIncrementInitiativeAdjust);
			_decrementInitiativeAdjust = new Command(ExecuteDecrementInitiativeAdjust);
	}

		public Command AdvanceTurnState
		{
			get { return _advanceTurnState; }
		}

		public void ExecuteAdvanceTurnState()
		{
			switch (TurnState)
			{
			case Types.TurnState.NotStarted:	StartTurn();	break;
			case Types.TurnState.Started:		EndTurn();		break;
			case Types.TurnState.Ended:			TurnState = Types.TurnState.Started; break;
			}
		}

		public Command IncrementInitiativeAdjust
		{
			get { return _incrementInitiativeAdjust; }
		}

		public Command DecrementInitiativeAdjust
		{
			get { return _decrementInitiativeAdjust; }
		}

		public void ExecuteIncrementInitiativeAdjust()
		{
			++InitiativeValueViewModel.InitiativeValue.Adjust;
		}

		public void ExecuteDecrementInitiativeAdjust()
		{
			--InitiativeValueViewModel.InitiativeValue.Adjust;
		}

		public virtual void StartEncounter()
		{
			ActorViewModel.StartEncounter();
			TurnState = Types.TurnState.NotStarted;
		}

		public virtual void StartTurn()
		{
			ActorViewModel.Actor.ApplyPerTurnEffects();

			TurnState = Types.TurnState.Started;
			ActorViewModel.ActorUpdated();
		}
		
		public virtual void EndTurn()
		{
			TurnState = Types.TurnState.Ended;
			ActorViewModel.ActorUpdated();
		}

		public virtual void StartNewRound()
		{
			TurnState = Types.TurnState.NotStarted;
		}

		public InitiativeValueViewModel InitiativeValueViewModel
		{
			get { return _initiativeValueViewModel; }
			set { SetField(ref _initiativeValueViewModel, value); }
		}

		public ActorInitiativeViewModel ActorViewModel
		{
			get { return _actorViewModel; }
			set { SetField(ref _actorViewModel, value); }
		}

		public Types.TurnState TurnState
		{
			get { return InitiativeValueViewModel.TurnState; }
			set
			{
				InitiativeValueViewModel.TurnState = value;
				NotifyPropertyChanged("TurnState");
				NotifyPropertyChanged("TurnEnded");
				NotifyPropertyChanged("TurnNotEnded");
			}
		}

		public bool TurnEnded
		{
			get { return TurnState == Types.TurnState.Ended; }
		}

		public bool TurnNotEnded
		{
			get { return TurnState != Types.TurnState.Ended; }
		}

		public bool Delayed
		{
			get { return InitiativeValueViewModel.Delayed; }
			set
			{
				InitiativeValueViewModel.Delayed = value;
				NotifyPropertyChanged("Delayed");

				if (InitiativeValueViewModel.Delayed &&
						InitiativeValueViewModel.Readied)
				{
					InitiativeValueViewModel.Readied = false;
					NotifyPropertyChanged("Readied");
				}
			}
		}

		public bool Readied
		{
			get { return InitiativeValueViewModel.Readied; }
			set
			{
				InitiativeValueViewModel.Readied = value;
				NotifyPropertyChanged("Readied");

				if (InitiativeValueViewModel.Readied &&
						InitiativeValueViewModel.Delayed)
				{
					InitiativeValueViewModel.Delayed = false;
					NotifyPropertyChanged("Delayed");
				}
			}
		}

		public Command OpenInitiativeDialog
		{
			get { return _openInitiativeDialog; }
		}

		private void ExecuteOpenInitiativeDialog()
		{
			InitiativeValueViewModel.OpenInitDialog(ActorViewModel.InitiativeMod);
			NotifyPropertyChanged("InitiativeValueViewModel");
		}

		public virtual void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("InitiativeCard");
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			WriteXMLStartElement(xmlWriter);
			ActorViewModel.WriteXML(xmlWriter);
			InitiativeValueViewModel.WriteXML(xmlWriter);
			xmlWriter.WriteEndElement();
		}

		public virtual void ReadXML(XmlNode xmlNode, EncounterViewModel encounterViewModel = null)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "InitiativeValue")
					{
						InitiativeValueViewModel = new InitiativeValueViewModel(childNode);
					}
				}
			}
			catch (XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}
	}
}
