using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public class CreatureInitiativeCardViewModel : InitiativeCardViewModel
	{
		public CreatureInitiativeCardViewModel()
		{
			_endTurn = new Command(ExecuteEndTurn);
		}

		private Command _endTurn;

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
			ActorViewModel.TurnStarted = false;
		}

		public Command EndTurn
		{
			get { return _endTurn; }
		}

		public virtual void ExecuteEndTurn()
		{
			for (int i = ActorViewModel.Actor.Effects.Count - 1; i >= 0; --i)
			{
				if (ActorViewModel.Actor.Effects[i] is Model.Effect.TimedEffect)
				{
					Model.Effect.TimedEffect tempEffect = ActorViewModel.Actor.Effects[i] as Model.Effect.TimedEffect;
					tempEffect.ElapsedDuration++;
					if (tempEffect.ElapsedDuration > tempEffect.Duration)
					{
						ActorViewModel.Actor.Effects.RemoveAt(i);
					}
				}
			}

			ActorViewModel.ActorUpdated();
		}
	}
}
