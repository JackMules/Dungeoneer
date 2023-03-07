using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;
using System.Xml;

namespace Dungeoneer.ViewModel
{
	public class PlayerActorInitiativeCardViewModel : InitiativeCardViewModel
	{
		public PlayerActorInitiativeCardViewModel()
		{
			InitCommands();
		}

		public PlayerActorInitiativeCardViewModel(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
			InitCommands();
		}

		public new PlayerActorInitiativeViewModel ActorViewModel
		{
			get { return base.ActorViewModel as PlayerActorInitiativeViewModel; }
			set
			{
				base.ActorViewModel = value;
				NotifyPropertyChanged("ActorViewModel");
				OnWeaponsChanged();
			}
		}

		public delegate void WeaponsChange(Model.WeaponSet weaponSet);

		public WeaponsChange OnWeaponsChange { get; set; }

		public ObservableCollection<Model.Weapon> Weapons
		{
			get
			{
				return ActorViewModel.Weapons;
			}
			set
			{
				ActorViewModel.Weapons = value;
				OnWeaponsChanged();
			}
		}

		private void OnWeaponsChanged()
		{
			NotifyPropertyChanged("Weapons");
			Model.WeaponSet weaponSet = new Model.WeaponSet(ActorViewModel.Actor);
			OnWeaponsChange?.Invoke(weaponSet);
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("PlayerCard");
		}

		public override void ReadXML(XmlNode xmlNode, EncounterViewModel encounterViewModel = null)
		{
			base.ReadXML(xmlNode);
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "PlayerActorInitiativeViewModel")
					{
						ActorViewModel = new PlayerActorInitiativeViewModel(childNode);
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
