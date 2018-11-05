using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public static class ActorInitiativeViewModelFactory
	{
		public static ActorInitiativeViewModel GetActorViewModel(Model.Actor actor, EncounterViewModel encounterViewModel)
		{
			if (actor is Model.PlayerActor)
			{
				return new PlayerActorInitiativeViewModel(actor as Model.PlayerActor);
			}
			else if (actor is Model.Creature)
			{
				return new CreatureInitiativeViewModel(actor as Model.Creature, encounterViewModel);
			}
			else if (actor is Model.NonPlayerActor)
			{
				return new NonPlayerActorInitiativeViewModel(actor as Model.NonPlayerActor);
			}
			else
			{
				throw new ArgumentException("Unknown type: " + actor.GetType().ToString());
			}
		}
	}
}
