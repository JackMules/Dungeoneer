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

		public ObservableCollection<Model.NamedValue> NamedValues	{ get; set;	}

		public void LoadValues()
		{
			ObservableCollection<Model.NamedValue> namedValues = new ObservableCollection<Model.NamedValue>
			{
				new Model.NamedValue { Name = "Init", Value = 1 },
				new Model.NamedValue { Name = "AC", Value = 20 },
				new Model.NamedValue { Name = "To Hit", Value = 10 }
			};

			NamedValues = namedValues;
		}
	}
}
