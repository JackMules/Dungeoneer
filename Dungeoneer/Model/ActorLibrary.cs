using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Dungeoneer.Model
{
	public class ActorLibrary
	{
		public ActorLibrary()
		{
			LoadValues();
		}

		public ObservableCollection<PlayerActor> Characters
		{
			get;
			set;
		}

		public ObservableCollection<NonPlayerActor> Enemies
		{
			get;
			set;
		}

		public void LoadValues()
		{
			ObservableCollection<PlayerActor> characters = new ObservableCollection<PlayerActor>
			{
				new PlayerActor { DisplayName = "Kolnik", ActorName = "Kolnik", InitiativeMod = -1 },
				new PlayerActor { DisplayName = "Atrion", ActorName = "Atrion", InitiativeMod = 5 },
				new PlayerActor { DisplayName = "Thrasin", ActorName = "Thrasin", InitiativeMod = 7 },
				new PlayerActor { DisplayName = "Joshua", ActorName = "Joshua", InitiativeMod = 10 },
				new PlayerActor { DisplayName = "Osprey", ActorName = "Osprey", InitiativeMod = 13 }
			};

			Characters = characters;

			ObservableCollection<NonPlayerActor> enemies = new ObservableCollection<NonPlayerActor>
			{
				new Creature { ActorName = "Orc", InitiativeMod = 3, ChallengeRating = 0.5f, ArmourClass = 13, HitPoints = 8 },
				new Creature { ActorName = "Goblin", InitiativeMod = 2, ChallengeRating = 0.25f, ArmourClass = 11, HitPoints = 6 },
				new NonPlayerActor { ActorName = "Poison Dart Trap", InitiativeMod = 6, ChallengeRating = 4 },
				new Creature { ActorName = "Troll", ArmourClass = 16, HitPoints = 52 }
		};

			Enemies = enemies;
		}

		public void WriteXML()
		{
			XmlWriter xmlWriter = XmlWriter.Create("ActorLibrary.xml");

			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("ActorLibrary");

			xmlWriter.WriteStartElement("Characters");
			foreach (PlayerActor character in Characters)
			{
				character.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Enemies");
			foreach (NonPlayerActor enemy in Enemies)
			{
				enemy.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();

			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndDocument();
			xmlWriter.Close();
		}

		public void ReadXML()
		{
			try
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load("ActorLibrary.xml");

				foreach (XmlNode xmlNode in xmlDoc.DocumentElement)
				{
					if (xmlNode.Name == "Characters")
					{
						foreach (XmlNode characterNode in xmlNode.ChildNodes)
						{
							if (xmlNode.Name == "PlayerActor")
							{
								PlayerActor playerActor = new PlayerActor();
								playerActor.ReadXML(xmlNode);
								Characters.Add(playerActor);
							}
						}
					}
					else if (xmlNode.Name == "Enemies")
					{
						foreach (XmlNode characterNode in xmlNode.ChildNodes)
						{
							if (xmlNode.Name == "NonPlayerActor")
							{
								NonPlayerActor nonPlayerActor = new NonPlayerActor();
								nonPlayerActor.ReadXML(xmlNode);
								Enemies.Add(nonPlayerActor);
							}
							else if (xmlNode.Name == "Creature")
							{
								Creature creature = new Creature();
								creature.ReadXML(xmlNode);
								Enemies.Add(creature);
							}
						}
					}
				}
			}
			catch (System.Xml.XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}
	}
}
