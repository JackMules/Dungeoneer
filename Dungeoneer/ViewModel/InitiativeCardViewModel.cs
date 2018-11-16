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
			_openInitiativeDialog = new Command(ExecuteOpenInitiativeDialog);
		}

		private InitiativeValueViewModel _initiativeValueViewModel;
		private ActorInitiativeViewModel _actorViewModel;
		private Command _openInitiativeDialog;
		private Command _removeCard;

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

		public bool Delayed
		{
			get { return InitiativeValueViewModel.Delayed; }
			set
			{
				InitiativeValueViewModel.Delayed = value;
				NotifyPropertyChanged("Delayed");
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

		public bool Readied
		{
			get { return InitiativeValueViewModel.Readied; }
			set
			{
				InitiativeValueViewModel.Readied = value;
				NotifyPropertyChanged("Readied");
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

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("InitiativeCard");
			ActorViewModel.WriteXML(xmlWriter);
			InitiativeValueViewModel.WriteXML(xmlWriter);
			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode, EncounterViewModel encounterViewModel)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "ActorInitiativeViewModel" ||
							childNode.Name == "PlayerActorInitiativeViewModel" ||
							childNode.Name == "CreatureInitiativeViewModel")
					{
						if (childNode.Name == "PlayerActorInitiativeViewModel")
						{
							ActorViewModel = new PlayerActorInitiativeViewModel(childNode);
						}
						else if (childNode.Name == "CreatureInitiativeViewModel")
						{
							ActorViewModel = new CreatureInitiativeViewModel(childNode, encounterViewModel);
						}
					}
					else if (childNode.Name == "InitiativeValue")
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
