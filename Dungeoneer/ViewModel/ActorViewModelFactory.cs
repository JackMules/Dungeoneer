using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public static class ActorViewModelFactory
	{
		public static ActorViewModel GetActorViewModel(Model.Actor actor)
		{
			if (actor is Model.PlayerActor)
			{
				return new PlayerActorViewModel { Actor = actor };
			}
			else if (actor is Model.NonPlayerActor)
			{
				return new NonPlayerActorViewModel { Actor = actor };
			}
			else
			{
				return new ActorViewModel { Actor = actor };
			}
		}
	}
}
