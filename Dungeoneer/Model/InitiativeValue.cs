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
		private int? _initiativeMod;
		private int? _initiativeRoll;

		public InitiativeValue()
		{
			_initiativeScore = null;
			_initiativeMod = null;
		}

		public int? InitiativeScore
		{
			get { return _initiativeScore; }
			set { _initiativeScore = value; }
		}

		public int? InitiativeMod
		{
			get { return _initiativeMod; }
			set { _initiativeMod = value; }
		}

		public int? InitiativeRoll
		{
			get { return _initiativeRoll; }
			set { _initiativeRoll = value; }
		}
	}
}
