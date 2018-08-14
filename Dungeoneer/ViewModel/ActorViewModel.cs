using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public class ActorViewModel : BaseViewModel
	{
		public ActorViewModel()
		{
			
		}

		protected Model.Actor _actor;

		public Model.Actor Actor
		{
			get { return _actor; }
			set
			{
				_actor = value;
				NotifyPropertyChanged("Actor");
			}
		}

		public string DisplayName
		{
			get { return Actor.DisplayName; }
			set
			{
				Actor.DisplayName = value;
				NotifyPropertyChanged("DisplayName");
			}
		}

		public string ActorName
		{
			get { return Actor.ActorName; }
			set
			{
				Actor.ActorName = value;
				NotifyPropertyChanged("ActorName");
			}
		}

		public int InitiativeMod
		{
			get { return Actor.InitiativeMod; }
			set
			{
				Actor.InitiativeMod = value;
				NotifyPropertyChanged("InitiativeMod");
			}
		}
	}
}
