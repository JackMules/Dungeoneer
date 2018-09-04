using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class PlayerActorInitiativeViewModel : ActorInitiativeViewModel
	{
		public PlayerActorInitiativeViewModel()
		{
			_actor = new Model.PlayerActor();
		}

		public new Model.PlayerActor Actor
		{
			get { return _actor as Model.PlayerActor; }
			set
			{
				_actor = value;
				NotifyPropertyChanged("Actor");
			}
		}

		public List<Model.Weapon> Weapons
		{
			get { return Actor.Weapons; }
			set
			{
				Actor.Weapons = value;
				NotifyPropertyChanged("Weapons");
			}
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			Model.PlayerActor playerActor = new Model.PlayerActor();
			playerActor.ReadXML(xmlNode);
			Actor = playerActor;
		}
	}
}
