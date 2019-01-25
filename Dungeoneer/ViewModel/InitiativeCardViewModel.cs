﻿using System;
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

		protected virtual void InitCommands()
		{
			_openInitiativeDialog = new Command(ExecuteOpenInitiativeDialog);
			_advanceTurnState = new Command(ExecuteAdvanceTurnState);
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
			case Types.TurnState.Started:			EndTurn();		break;
			}
		}

		public virtual void StartEncounter()
		{
			ActorViewModel.StartEncounter();
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
			set
			{
				_initiativeValueViewModel = value;
				NotifyPropertyChanged("InitiativeValueViewModel");
			}
		}

		public ActorInitiativeViewModel ActorViewModel
		{
			get { return _actorViewModel; }
			set
			{
				_actorViewModel = value;
				NotifyPropertyChanged("ActorInitiativeViewModel");
			}
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
			SetInitiativeWindowViewModel setInitiativeWindowViewModel = new SetInitiativeWindowViewModel(ActorViewModel.InitiativeMod);
			Model.InitiativeValue initiativeValue = setInitiativeWindowViewModel.GetInitiative();
			if (initiativeValue != null)
			{
				InitiativeValueViewModel = new InitiativeValueViewModel { InitiativeValue = initiativeValue };
			}
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
