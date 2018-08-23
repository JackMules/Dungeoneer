using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dungeoneer.ViewModel
{
	public class NonPlayerActorViewModel : ActorViewModel
	{
		public NonPlayerActorViewModel()
		{
			_actor = new Model.NonPlayerActor();
		}

		public new Model.NonPlayerActor Actor
		{
			get { return _actor as Model.NonPlayerActor; }
			set
			{
				_actor = value;
				NotifyPropertyChanged("Actor");
			}
		}

		public float ChallengeRating
		{
			get { return Actor.ChallengeRating; }
			set
			{
				Actor.ChallengeRating = value;
				NotifyPropertyChanged("ChallengeRating");
			}
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			Model.NonPlayerActor nonPlayerActor= new Model.NonPlayerActor();
			nonPlayerActor.ReadXML(xmlNode);
			Actor = nonPlayerActor;
		}
	}
}
