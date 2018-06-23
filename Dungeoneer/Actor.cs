using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer
{
	public class Actor
	{
		public string Name { get; set; }
		public int InitiativeMod { get; set; }

		public Actor()
		{
			Name = "No Name";
			InitiativeMod = 0;
		}

		public Actor(
			string name,
			int initiativeMod)
		{
			Name = name;
			InitiativeMod = initiativeMod;
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", Name, Utility.GetSignedNumberString(InitiativeMod));
		}
	}
}
