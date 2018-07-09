using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class PlayerActor : Actor
	{
		private bool _selected { get; set; }

		public bool Selected
		{
			get { return _selected; }
			set
			{
				_selected = value;
				OnPropertyChanged("Selected");
			}
		}

		public PlayerActor()
			: base()
		{
			Selected = false;
		}

		public PlayerActor(
			string actorName,
			int initiativeMod,
			bool selected)
			: base(actorName, initiativeMod)
		{
			Selected = selected;
		}
	}
}
