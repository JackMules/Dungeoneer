using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer
{
	public class CreatureCardViewModel
	{
		public CreatureCardViewModel()
		{
			LoadValues();
		}

		public ObservableCollection<NamedValue> NamedValues	{ get; set;	}

		public void LoadValues()
		{
			ObservableCollection<NamedValue> namedValues = new ObservableCollection<NamedValue>
			{
				new NamedValue { Name = "Init", Value = "1" },
				new NamedValue { Name = "AC", Value = "20" },
				new NamedValue { Name = "To Hit", Value = "+10" }
			};

			NamedValues = namedValues;
		}
	}
}
