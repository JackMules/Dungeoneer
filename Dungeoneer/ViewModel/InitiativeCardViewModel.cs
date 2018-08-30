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
		private ActorInitiativeViewModel _actorViewModel;
		private Command _openInitiativeDialog;

		public delegate void WeaponsChange(Model.PlayerActor playerActor);

		public WeaponsChange OnWeaponsChange { get; set; }

		public List<Model.Weapon> WeaponsList
		{
			get { return ActorViewModel.Weapons; }
			set
			{
				parameter = value;
				NotifyPropertyChanged("Parameter");
				// Always check for null
				if (OnParameterChange != null) OnParameterChange(parameter);
			}
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
			SetInitiativeWindowViewModel setInitiativeWindowViewModel = new SetInitiativeWindowViewModel();
			Model.InitiativeValue initiativeValue = setInitiativeWindowViewModel.GetInitiative();
			if (initiativeValue != null)
			{
				InitiativeValueViewModel initiativeValueViewModel = new InitiativeValueViewModel { InitiativeValue = initiativeValue };
				InitiativeValueViewModel = initiativeValueViewModel;
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("InitiativeCard");
			ActorViewModel.WriteXML(xmlWriter);
			InitiativeValueViewModel.WriteXML(xmlWriter);
			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Actor" ||
							childNode.Name == "NonPlayerActor" ||
							childNode.Name == "PlayerActor" ||
							childNode.Name == "Creature")
					{
						ActorInitiativeViewModel actorViewModel = null;
						if (childNode.Name == "NonPlayerActor")
						{
							actorViewModel = new NonPlayerActorInitiativeViewModel();
						}
						else if (childNode.Name == "PlayerActor")
						{
							actorViewModel = new PlayerActorInitiativeViewModel();
						}
						else if (childNode.Name == "Creature")
						{
							actorViewModel = new CreatureInitiativeViewModel();
						}
						actorViewModel.ReadXML(childNode);
						ActorViewModel = actorViewModel;
					}
					else if (childNode.Name == "InitiativeValue")
					{
						InitiativeValueViewModel initValueViewModel = new InitiativeValueViewModel();
						initValueViewModel.ReadXML(childNode);
						InitiativeValueViewModel = initValueViewModel;
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
