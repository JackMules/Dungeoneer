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
		public PlayerActor()
		{
			_weapons = new ObservableCollection<Weapon>();
		}

		private ObservableCollection<Weapon> _weapons;

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

		public override void ReadXML(XmlNode xmlNode)
		{
			base.ReadXML(xmlNode);

			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Weapons")
					{
						foreach (XmlNode attackNode in childNode.ChildNodes)
						{
							if (attackNode.Name == "Weapon")
							{
								Weapon weapon = new Weapon();
								weapon.ReadXML(attackNode);
								Weapons.Add(weapon);
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
