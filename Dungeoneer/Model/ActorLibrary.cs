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
	public class ActorLibrary : BaseModel
	{
		public ActorLibrary()
		{
			Load();
		}

		private ObservableCollection<PlayerActor> _characters = new ObservableCollection<PlayerActor>();
		private ObservableCollection<Creature> _enemies = new ObservableCollection<Creature>();
		private bool _modified = false;

		public ObservableCollection<PlayerActor> Characters
		{
			get { return _characters; }
			set
			{
				_characters = value;
				NotifyPropertyChanged("Characters");
			}
		}

		public ObservableCollection<Creature> Enemies
		{
			get { return _enemies; }
			set
			{
				_enemies = value;
				NotifyPropertyChanged("Enemies");
			}
		}

		public bool Modified
		{
			get { return _modified; }
			set
			{
				_modified = value;
				NotifyPropertyChanged("Modified");
			}
		}

		public void Load()
		{
			ReadXML();
		}

		public void Clear()
        {
			Characters.Clear();
			Enemies.Clear();
			Modified = true;
        }

		public void AddActor(Actor actor)
		{
			if (actor is PlayerActor)
			{
				Characters.Add(actor as PlayerActor);
				Modified = true;
			}
			else if (actor is Creature)
			{
				Enemies.Add(actor as Creature);
				Modified = true;
			}
		}

		public void EditActor(Actor oldActor, Actor newActor)
		{
			if (oldActor is PlayerActor)
			{
				var foundCharacter = Characters.Where(character => character == oldActor).FirstOrDefault();

				if (foundCharacter != null)
				{
					Characters.Remove(oldActor as PlayerActor);
					Characters.Add(newActor as PlayerActor);
					Modified = true;
				}
			}
			else if (oldActor is Creature)
			{
				var foundEnemy = Enemies.Where(enemy => enemy == oldActor).FirstOrDefault();

				if (foundEnemy != null)
				{
					Enemies.Remove(oldActor as Creature);
					Enemies.Add(newActor as Creature);
					Modified = true;
				}
			}
		}

		public void DeleteActor(Actor actor)
		{
			if (actor is PlayerActor)
			{
				var foundCharacter = Characters.Where(character => character == actor).FirstOrDefault();

				if (foundCharacter != null)
				{
					Characters.Remove(actor as PlayerActor);
					Modified = true;
				}
			}
			else if (actor is Creature)
			{
				var foundEnemy = Enemies.Where(enemy => enemy == actor).FirstOrDefault();

				if (foundEnemy != null)
				{
					Enemies.Remove(actor as Creature);
					Modified = true;
				}
			}
		}

		public void WriteXML()
		{
			XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
			XmlWriter xmlWriter = XmlWriter.Create("ActorLibrary.xml", settings);

			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("ActorLibrary");

			xmlWriter.WriteStartElement("Characters");
			foreach (PlayerActor character in Characters)
			{
				character.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Enemies");
			foreach (Creature enemy in Enemies)
			{
				enemy.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();

			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndDocument();
			xmlWriter.Close();

			Modified = false;
		}

		public bool ReadXML()
		{
			//try
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load("ActorLibrary.xml");

				foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes)
				{
					if (xmlNode.Name == "Characters")
					{
						foreach (XmlNode characterNode in xmlNode.ChildNodes)
						{
							if (characterNode.Name == "PlayerActor")
							{
								Characters.Add(new PlayerActor(characterNode));
							}
						}
					}
					else if (xmlNode.Name == "Enemies")
					{
						foreach (XmlNode enemyNode in xmlNode.ChildNodes)
						{
							if (enemyNode.Name == "Creature")
							{
								Enemies.Add(new Creature(enemyNode));
							}
						}
					}
				}
			}
			//catch (System.IO.FileNotFoundException)
			{
			//	return false;
			}
			//catch (XmlException e)
			{
			//	MessageBox.Show(e.ToString());
			//	return false;
			}

			return true;
		}
	}
}
