using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer
{
	class MainWindowViewModel
	{
		public MainWindowViewModel()
		{
			LoadValues();
		}

		public ObservableCollection<Actor> Characters
		{
			get;
			set;
		}

		public void LoadValues()
		{
			ObservableCollection<Actor> characters = new ObservableCollection<Actor>
			{
				new Actor { Name = "Kolnik", InitiativeMod = -1 },
				new Actor { Name = "Atrion", InitiativeMod = 7  },
				new Actor { Name = "Thrasin", InitiativeMod = 5  },
				new Actor { Name = "Joshua", InitiativeMod = 10  }
			};

			Characters = characters;
		}
	}
}
