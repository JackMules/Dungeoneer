using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public static class InitiativeCardViewModelFactory
	{
		public static InitiativeCardViewModel GetInitiativeCardViewModel(ActorInitiativeViewModel actorInitiativeViewModel)
		{
			if (actorInitiativeViewModel is PlayerActorInitiativeViewModel)
			{
				return new PlayerActorInitiativeCardViewModel { ActorViewModel = actorInitiativeViewModel as PlayerActorInitiativeViewModel };
			}
			else if (actorInitiativeViewModel.Actor is Model.Creature)
			{
				return new InitiativeCardViewModel { ActorViewModel = actorInitiativeViewModel as CreatureInitiativeViewModel };
			}
			else
			{
				throw new ArgumentException("Unknown type: " + actorInitiativeViewModel.GetType().ToString());
			}
		}
	}
}
