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
		protected Actor()
		{
		}

		public Actor(Actor other)
		{
			_baseActorAttributes = new ActorAttributes(other._baseActorAttributes);
			_modifiedActorAttributes = new ActorAttributes(_baseActorAttributes);
		}

		public Actor(ActorAttributes attributes)
		{
			_baseActorAttributes = new ActorAttributes(attributes);
			_modifiedActorAttributes = new ActorAttributes(attributes);
		}

		public Actor(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
			_modifiedActorAttributes = new ActorAttributes(_baseActorAttributes);
		}

		private string _actorName = "";
		private FullyObservableCollection<Effect.Effect> _effects = new FullyObservableCollection<Effect.Effect>();

		private ActorAttributes _baseActorAttributes = new ActorAttributes();
		private ActorAttributes _modifiedActorAttributes = new ActorAttributes();

		public ActorAttributes GetEffectiveAttributes()
		{
			ActorAttributes effectiveAttributes = new ActorAttributes(_modifiedActorAttributes);
			foreach (Effect.Effect effect in Effects)
			{
				effect.ApplyTo(effectiveAttributes);
			}
			return effectiveAttributes;
		}

		public string ActorName
		{
			get { return _actorName; }
			set
			{
				_actorName = value;
				NotifyPropertyChanged("ActorName");
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

		public int InitiativeMod
		{
			get { return GetEffectiveAttributes().InitiativeMod; }
			set
			{
				_modifiedActorAttributes.InitiativeMod = value;
				NotifyPropertyChanged("InitiativeMod");
			}
		}

		public bool Active
		{
			get { return GetEffectiveAttributes().Active; }
			set
			{
				_modifiedActorAttributes.Active = value;
				NotifyPropertyChanged("Active");
			}
		}
		
		public void ApplyPerTurnEffects()
		{
			foreach (Effect.Effect effect in Effects)
			{
				if (effect.PerTurn)
				{
					effect.ApplyTo(_modifiedActorAttributes);
				}
			}
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

			xmlWriter.WriteStartElement("Active");
			xmlWriter.WriteString(Active.ToString());
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
						_baseActorAttributes.InitiativeMod = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Active")
					{
						_baseActorAttributes.Active = Convert.ToBoolean(childNode.InnerText);
					}
					else if (childNode.Name == "Effects")
					{
						foreach (XmlNode effectNode in childNode.ChildNodes)
						{
							if (effectNode.Name == "Effect")
							{
								Effects.Add(Effect.EffectFactory.GetEffect(effectNode));
							}
						}
					}
				}

				_modifiedActorAttributes = new ActorAttributes(_baseActorAttributes);
			}
			catch (XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}
	}
}
