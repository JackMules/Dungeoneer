using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class PlayerActorInitiativeViewModel : ActorInitiativeViewModel
	{
		public PlayerActorInitiativeViewModel(Model.PlayerActor playerActor)
		{
			_actor = playerActor.Clone();
		}

		public PlayerActorInitiativeViewModel(XmlNode playerXml)
		{
			_actor = new Model.PlayerActor(playerXml);
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

		public ObservableCollection<Model.Weapon> Weapons
		{
			get { return Actor.Weapons; }
			set
			{
				Actor.Weapons = value;
				NotifyPropertyChanged("Weapons");
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("PlayerActorInitiativeViewModel");
		}

		public override void WriteActorXML(XmlWriter xmlWriter)
		{
			Actor.WriteXML(xmlWriter);
		}

		public override void ReadActorXML(XmlNode xmlNode)
		{
			Actor = new Model.PlayerActor(xmlNode);
		}
	}
}
