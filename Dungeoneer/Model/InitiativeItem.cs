using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class InitiativeItem
	{
		public Actor Actor { get; set; }
		public int InitiativeScore { get; set; }
		public int InitiativeSubscore { get; set; }
	}
}
