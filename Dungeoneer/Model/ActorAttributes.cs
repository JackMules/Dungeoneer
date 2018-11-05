using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.Model
{
	public class ActorAttributes : BaseModel
	{
		public ActorAttributes()
		{
			InitiativeMod = 0;
			Active = true;
		}

		public ActorAttributes(ActorAttributes other)
		{
			InitiativeMod = other._initiativeMod;
			Active = other._active;
		}

		private int _initiativeMod;
		private bool _active;

		public int InitiativeMod
		{
			get { return _initiativeMod; }
			set
			{
				_initiativeMod = value;
				NotifyPropertyChanged("InitiativeMod");
			}
		}

		public bool Active
		{
			get { return _active; }
			set
			{
				_active = value;
				NotifyPropertyChanged("Active");
			}
		}
	}
}
