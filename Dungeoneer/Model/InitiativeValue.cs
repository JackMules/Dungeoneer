using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class InitiativeValue
	{
		private int? _initiativeScore;
		private int? _initiativeSubScore;

		public InitiativeValue()
		{
			_initiativeScore = null;
			_initiativeSubScore = null;
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
