using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dungeoneer.Utility;
using System.Windows.Forms;

namespace Dungeoneer.Model
{
	public class WeaponSet : BaseModel
	{
		public WeaponSet(PlayerActor playerActor)
		{
			_owner = playerActor.ActorName;
			_weapons = new List<Weapon>();

			foreach (Weapon weapon in playerActor.Weapons)
			{
				_weapons.Add(weapon);
			}
		}

		public WeaponSet(WeaponSet other)
		{
			Owner = other.Owner;
			Weapons = new List<Weapon>(other.Weapons);
		}

		public WeaponSet(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
		}

		private string _owner;
		private List<Weapon> _weapons;

		public string Owner
		{
			get { return _owner; }
			set
			{
				_owner = value;
				NotifyPropertyChanged("Owner");
			}
		}

		public List<Weapon> Weapons
		{
			get { return _weapons; }
			set
			{
				_weapons = value;
				NotifyPropertyChanged("Weapons");
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("WeaponSet");

			xmlWriter.WriteStartElement("Owner");
			xmlWriter.WriteString(Owner);
			xmlWriter.WriteEndElement();
			
			xmlWriter.WriteStartElement("Weapons");
			foreach (Weapon weapon in Weapons)
			{
				weapon.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Owner")
					{
						Owner = childNode.InnerText;
					}
					else if (childNode.Name == "Weapons")
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
