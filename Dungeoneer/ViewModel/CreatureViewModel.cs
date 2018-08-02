using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public class CreatureViewModel : NonPlayerActorViewModel
	{
		public CreatureViewModel() { }

		public new Model.Creature Actor
		{
			get { return _actor as Model.Creature; }
			set
			{
				_actor = value;
				NotifyPropertyChanged("Actor");
			}
		}

		public uint ArmourClass
		{
			get { return Actor.ArmourClass; }
			set
			{
				Actor.ArmourClass = value;
				NotifyPropertyChanged("ArmourClass");
			}
		}
	}
}
