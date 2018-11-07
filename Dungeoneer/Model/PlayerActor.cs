using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Dungeoneer.Utility;

namespace Dungeoneer.Model
{
	public class PlayerActor : Actor
	{
		public PlayerActor(PlayerActor other)
			: base(other)
		{
			_weapons = new ObservableCollection<Weapon>(other.Weapons);
		}

		public PlayerActor(ActorAttributes attributes)
			: base(attributes)
		{
		}

		public PlayerActor(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
		}

		private ObservableCollection<Weapon> _weapons = new ObservableCollection<Weapon>();

		public ObservableCollection<Weapon> Weapons
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
			xmlWriter.WriteStartElement(GetType().Name);
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

		public override void ReadPropertyXML(XmlNode xmlNode)
		{
			base.ReadPropertyXML(xmlNode);

			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Weapons")
					{
						foreach (XmlNode weaponNode in childNode.ChildNodes)
						{
							if (weaponNode.Name == "Weapon")
							{
								Weapons.Add(new Weapon(weaponNode));
							}
						}
					}
				}
			}
			catch (XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}
	}
}
