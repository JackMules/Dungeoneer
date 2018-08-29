using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.Model
{
	public class PlayerActor : Actor
	{
		public PlayerActor()
		{
			_weapons = new FullyObservableCollection<Weapon>();
		}

		private FullyObservableCollection<Weapon> _weapons;

		public FullyObservableCollection<Weapon> Weapons
		{
			get { return _weapons; }
			set
			{
				_weapons = value;
				NotifyPropertyChanged("Weapons");
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("PlayerActor");
		}

		public override void WritePropertyXML(XmlWriter xmlWriter)
		{
			base.WritePropertyXML(xmlWriter);

			xmlWriter.WriteStartElement("Weapons");
			foreach (Weapon weapon in Weapons)
			{
				weapon.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();
		}
	}
}
