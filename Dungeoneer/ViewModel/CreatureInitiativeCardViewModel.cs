using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dungeoneer.Utility;
using System.Xml;

namespace Dungeoneer.ViewModel
{
	public class CreatureInitiativeCardViewModel : InitiativeCardViewModel
	{
		public CreatureInitiativeCardViewModel()
		{
			InitCommands();
		}

		public CreatureInitiativeCardViewModel(XmlNode xmlNode, EncounterViewModel encounterViewModel)
		{
			ReadXML(xmlNode, encounterViewModel);
			InitCommands();
		}

		protected override void InitCommands()
		{
			base.InitCommands();
			_advanceTurnState = new Command(ExecuteAdvanceTurnState);
		}

		private Command _advanceTurnState;

		public new CreatureInitiativeViewModel ActorViewModel
		{
			get { return base.ActorViewModel as CreatureInitiativeViewModel; }
			set
			{
				base.ActorViewModel = value;
				NotifyPropertyChanged("ActorViewModel");
			}
		}

		public override void StartNewRound()
		{
			base.StartNewRound();
			TurnState = Types.TurnState.NotStarted;
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

		public virtual void StartTurn()
		{
			ActorViewModel.Actor.ApplyPerTurnEffects();

			TurnState = Types.TurnState.Started;
			ActorViewModel.ActorUpdated();
		}
		
		public virtual void EndTurn()
		{
			for (int i = ActorViewModel.Effects.Count - 1; i >= 0; --i)
			{
				ActorViewModel.Effects[i].AdvanceTurn();
				if (ActorViewModel.Effects[i].Expired())
				{
					ActorViewModel.Effects.RemoveAt(i);
				}
			}

			TurnState = Types.TurnState.Ended;
			ActorViewModel.ActorUpdated();
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("CreatureCard");
		}

		public override void ReadXML(XmlNode xmlNode, EncounterViewModel encounterViewModel)
		{
			base.ReadXML(xmlNode);

			if (encounterViewModel != null)
			{
				try
				{
					foreach (XmlNode childNode in xmlNode.ChildNodes)
					{
						if (childNode.Name == "CreatureInitiativeViewModel")
						{
							ActorViewModel = new CreatureInitiativeViewModel(childNode, encounterViewModel);
						}

					}
				}
				catch (XmlException e)
				{
					MessageBox.Show(e.ToString());
				}
			}
			else
			{
				throw new ArgumentException("EncounterViewModel is null!");
			}
		}
	}
}
