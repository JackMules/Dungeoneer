using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Dungeoneer.Utility;

namespace Dungeoneer.Model
{
	public class Actor : BaseModel
	{
		public Actor()
		{
			ActorName = "";
			InitiativeMod = 0;
			Active = true;
			Effects = new FullyObservableCollection<Effect.Effect>();
		}

		private string _actorName;
		private int _initiativeMod;
		private bool _active;
		private FullyObservableCollection<Effect.Effect> _effects;

		public string ActorName
		{
			get { return _actorName; }
			set
			{
				_actorName = value;
				NotifyPropertyChanged("ActorName");
			}
		}

		public int InitiativeMod
		{
			get { return _initiativeMod; }
			set
			{
				_initiativeMod = value;
				NotifyPropertyChanged("InitiativeMod");
			}
		}

		public bool Active
		{
			get { return _active; }
			set
			{
				_active = value;
				NotifyPropertyChanged("Active");
			}
		}

		public FullyObservableCollection<Effect.Effect> Effects
		{
			get { return _effects; }
			set
			{
				_effects = value;
				NotifyPropertyChanged("Effects");
			}
		}

		public Actor(
			string actorName,
			int initiativeMod,
			FullyObservableCollection<Effect.Effect> effects)
		{
			ActorName = actorName;
			InitiativeMod = initiativeMod;
			Active = true;
			Effects = effects;
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			WriteXMLStartElement(xmlWriter);
			WritePropertyXML(xmlWriter);
			xmlWriter.WriteEndElement();
		}

		public virtual void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Actor");
		}

		public virtual void WritePropertyXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("ActorName");
			xmlWriter.WriteString(ActorName);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("InitiativeMod");
			xmlWriter.WriteString(InitiativeMod.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Effects");
			foreach (Effect.Effect effect in Effects)
			{
				effect.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();
		}

		public virtual void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "ActorName")
					{
						ActorName = childNode.InnerText;
					}
					else if (childNode.Name == "InitiativeMod")
					{
						InitiativeMod = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Effects")
					{
						foreach (XmlNode effectNode in childNode.ChildNodes)
						{
							if (effectNode.Name == "Effect")
							{
								Effect.Effect effect = Effect.EffectFactory.GetEffectFromXML(effectNode);
								Effects.Add(effect);
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
