using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class InitiativeCard
	{
		private Actor _actor;
		private int? _initiativeScore;
		private int? _initiativeSubScore;

		public InitiativeCard(Actor actor)
		{
			_actor = actor;
			_initiativeScore = null;
			_initiativeSubScore = null;
		}

		public Actor Actor
		{
			get { return _actor; }
			set { _actor = value; }
		}

		public int? InitiativeScore
		{
			get { return _initiativeScore; }
			set { _initiativeScore = value; }
		}

		public int? InitiativeSubScore
		{
			get { return _initiativeSubScore; }
			set { _initiativeSubScore = value; }
		}
	}
}
