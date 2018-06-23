using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer
{
	public class NamedValue
	{
		public NamedValue()
		{
			Name = "No Name";
			Value = "No Value";
		}

		public string Name { get; set; }
		public string Value { get; set; }
	}
}
