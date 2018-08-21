using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
		private ActorViewModel _actorViewModel;
		private Command _openInitiativeDialog;

		public InitiativeValueViewModel InitiativeValueViewModel
		{
			get { return _initiativeValueViewModel; }
			set
			{
				_initiativeValueViewModel = value;
				NotifyPropertyChanged("InitiativeValueViewModel");
			}
		}

		public ActorViewModel ActorViewModel
		{
			get { return _actorViewModel; }
			set
			{
				_actorViewModel = value;
				NotifyPropertyChanged("ActorViewModel");
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

		public bool TurnEnded
		{
			get { return InitiativeValueViewModel.TurnEnded; }
			set
			{
				InitiativeValueViewModel.TurnEnded = value;
				NotifyPropertyChanged("TurnEnded");
			}
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
			bool askForInput = true;
			string feedback = null;
			while (askForInput)
			{
				View.InitiativeDialog initDialog = new View.InitiativeDialog(InitiativeValueViewModel.InitiativeScore,
					InitiativeValueViewModel.InitiativeAdjust, InitiativeValueViewModel.InitiativeMod, InitiativeValueViewModel.InitiativeRoll, feedback);
				if (initDialog.ShowDialog() == true)
				{
					try
					{
						InitiativeValueViewModel.InitiativeScore = initDialog.InitScore;
						InitiativeValueViewModel.InitiativeAdjust = initDialog.InitAdjust;
						InitiativeValueViewModel.InitiativeMod = initDialog.InitMod;
						InitiativeValueViewModel.InitiativeRoll = initDialog.InitRoll;
						askForInput = false;
					}
					catch (FormatException)
					{
						// Failed to parse input
						feedback = "Invalid format";
					}
				}
				else
				{
					askForInput = false;
				}
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("InitiativeCard");
			ActorViewModel.WriteXML(xmlWriter);
			InitiativeValueViewModel.WriteXML(xmlWriter);
			xmlWriter.WriteEndElement();
		}
	}
}
