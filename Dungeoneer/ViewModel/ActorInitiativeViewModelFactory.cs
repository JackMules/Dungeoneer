using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public static class ActorInitiativeViewModelFactory
	{
		public static ActorInitiativeViewModel GetActorViewModel(Model.Actor actor)
		{
			if (actor is Model.PlayerActor)
			{
				return new PlayerActorInitiativeViewModel { Actor = actor as Model.PlayerActor };
			}
			else if (actor is Model.Creature)
			{
				return new CreatureInitiativeViewModel { Actor = actor as Model.Creature };
			}
			else if (actor is Model.NonPlayerActor)
			{
				return new NonPlayerActorInitiativeViewModel { Actor = actor as Model.NonPlayerActor };
			}
			else
			{
				throw new ArgumentException("Unknown type: " + actor.GetType().ToString());
			}
		}
	}
}
