﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Forms;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public abstract class ActorInitiativeViewModel : BaseViewModel
	{
		public ActorInitiativeViewModel()
		{
		}

		protected virtual void InitCommands()
		{ }

		protected Model.Actor _actor;
		private string _displayName;

		public void StartEncounter()
		{
			Actor.StartEncounter();
			ActorUpdated();
		}

		public Model.Actor Actor
		{
			get { return _actor; }
			set
			{
				if (SetField(ref _actor, value))
				{
					ActorUpdated();
				}
			}
		}

		public virtual void ActorUpdated()
		{
			InitiativeMod = Actor.InitiativeMod;
			ActorName = Actor.ActorName;
		}

		public string DisplayName
		{
			get { return _displayName; }
			set { SetField(ref _displayName, value); }
		}

		public string ActorName
		{
			get { return Actor.ActorName; }
			set 
			{
				Actor.ActorName = value;
				NotifyPropertyChanged("ActorName");
			}
		}

		public int InitiativeMod
		{
			get { return Actor.InitiativeMod; }
			set
			{
				Actor.InitiativeMod = value;
				NotifyPropertyChanged("InitiativeMod");
			}
		}

		public bool Active
		{
			get { return Actor.Active; }
			set
			{
				Actor.Active = value;
				NotifyPropertyChanged("Active");
			}
		}

		public virtual void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("ActorInitiativeViewModel");
		}

		public virtual void WriteActorXML(XmlWriter xmlWriter)
		{
			Actor.WriteXML(xmlWriter);
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			WriteXMLStartElement(xmlWriter);

			xmlWriter.WriteStartElement("DisplayName");
			xmlWriter.WriteString(DisplayName);
			xmlWriter.WriteEndElement();

			WriteActorXML(xmlWriter);

			xmlWriter.WriteEndElement();
		}

		public virtual void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "DisplayName")
					{
						DisplayName = childNode.InnerText;
					}
					else
					{
						ReadActorXML(childNode);
					}
				}
			}
			catch (XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		public virtual void ReadActorXML(XmlNode xmlNode)
		{
			Model.Actor actor = new Model.Actor(xmlNode);
			Actor = actor;
		}
	}
}
