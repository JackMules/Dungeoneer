﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml;

namespace Dungeoneer.ViewModel
{
	public abstract class ActorInitiativeViewModel : BaseViewModel
	{
		public ActorInitiativeViewModel()
		{
			_backgroundColor = Colors.LightGray;
		}

		protected Model.Actor _actor;
		private Color _backgroundColor;

		public Model.Actor Actor
		{
			get { return _actor; }
			set
			{
				_actor = value;
				NotifyPropertyChanged("Actor");
			}
		}

		public string DisplayName
		{
			get { return Actor.DisplayName; }
			set
			{
				Actor.DisplayName = value;
				NotifyPropertyChanged("DisplayName");
			}
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

		public Color BackgroundColor
		{
			get { return _backgroundColor; }
			set
			{
				_backgroundColor = value;
				NotifyPropertyChanged("BackgroundColor");
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			Actor.WriteXML(xmlWriter);
		}

		public virtual void ReadXML(XmlNode xmlNode)
		{
			Model.Actor actor = new Model.Actor();
			actor.ReadXML(xmlNode);
			Actor = actor;
		}
	}
}