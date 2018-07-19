using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class InitiativeItem
	{
		public InitiativeItem() {}

		private Actor _actor;
		public Actor Actor
		{
			get { return _actor; }
			set { _actor = value; }
		}

		private int _initiativeScore;

		public int InitiativeScore
		{
			get { return _initiativeScore; }
			set { _initiativeScore = value; }
		}

		private int _initiativeSubScore;

		public int InitiativeSubScore
		{
			get { return _initiativeSubScore; }
			set { _initiativeSubScore = value; }
		}
	}
}
