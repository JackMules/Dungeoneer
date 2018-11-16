using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;
using System.Xml;

namespace Dungeoneer.ViewModel
{
	public static class InitiativeCardViewModelFactory
	{
		public static InitiativeCardViewModel GetInitiativeCardViewModel(XmlNode xmlNode, EncounterViewModel encounterViewModel)
		{
			if (xmlNode.Name == "CreatureCard")
			{
				return new CreatureInitiativeCardViewModel(xmlNode, encounterViewModel);
			}
			else if (xmlNode.Name == "PlayerCard")
			{
				return new PlayerActorInitiativeCardViewModel(xmlNode);
			}
			else
			{
				throw new ArgumentException("Unrecognised xml node: " + xmlNode.Name);
			}
		}

		public static InitiativeCardViewModel GetInitiativeCardViewModel(ActorInitiativeViewModel actorInitiativeViewModel)
		{
			if (actorInitiativeViewModel is PlayerActorInitiativeViewModel)
			{
				return new PlayerActorInitiativeCardViewModel { ActorViewModel = actorInitiativeViewModel as PlayerActorInitiativeViewModel };
			}
			else if (actorInitiativeViewModel.Actor is Model.Creature)
			{
				return new CreatureInitiativeCardViewModel { ActorViewModel = actorInitiativeViewModel as CreatureInitiativeViewModel };
			}
			else
			{
				throw new ArgumentException("Unknown type: " + actorInitiativeViewModel.GetType().ToString());
			}
		}
	}
}
