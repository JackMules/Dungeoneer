using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer
{
	public class NonPlayerActor : Actor
	{
		public string Type { get; set; }
		public List<Attack> Attacks;

		public NonPlayerActor(
			string name,
			string type,
			int initiativeMod,
			List<Attack> attacks)
			: base(name, initiativeMod)
		{
			Type = type;
			Attacks = attacks;
		}
	}
}
