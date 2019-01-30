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
	[Serializable]
	public class Actor : BaseModel
	{
		protected Actor()
		{
		}

		public Actor(Actor other)
		{
			BaseAttributes = new ActorAttributes(other.BaseAttributes);
			ModifiedAttributes = new ActorAttributes(BaseAttributes);
		}

		public Actor(ActorAttributes attributes)
		{
			BaseAttributes = new ActorAttributes(attributes);
			ModifiedAttributes = new ActorAttributes(attributes);
		}

		public Actor(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
			ModifiedAttributes = new ActorAttributes(BaseAttributes);
		}

		private string _actorName = "";
		private FullyObservableCollection<Effect.Effect> _effects = new FullyObservableCollection<Effect.Effect>();

		private ActorAttributes _baseActorAttributes = new ActorAttributes();
		private ActorAttributes _modifiedActorAttributes = new ActorAttributes();

		protected ActorAttributes BaseAttributes
		{
			get { return _baseActorAttributes; }
			set
			{
				_baseActorAttributes = value;
				NotifyPropertyChanged("BaseAttributes");
			}
		}

		protected ActorAttributes ModifiedAttributes
		{
			get { return _modifiedActorAttributes; }
			set
			{
				_modifiedActorAttributes = value;
				NotifyPropertyChanged("ModifiedAttributes");
			}
		}

		public ActorAttributes GetEffectiveAttributes()
		{
			ActorAttributes effectiveAttributes = ModifiedAttributes.Clone();
			foreach (Effect.Effect effect in Effects)
			{
				if (!effect.PerTurn)
				{
					effect.ApplyTo(effectiveAttributes, BaseAttributes);
				}
			}
			return effectiveAttributes;
		}

		public virtual void StartEncounter()
		{
			Effects.Clear();
			NotifyPropertyChanged("Effects");
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

		public virtual int InitiativeMod
		{
			get { return GetEffectiveAttributes().InitiativeMod; }
			set
			{
				ModifiedAttributes.InitiativeMod = value;
				NotifyPropertyChanged("InitiativeMod");
			}
		}

		public virtual bool Active
		{
			get { return GetEffectiveAttributes().Active; }
			set
			{
				ModifiedAttributes.Active = value;
				NotifyPropertyChanged("Active");
			}
		}
		
		public virtual void ApplyPerTurnEffects()
		{
			foreach (Effect.Effect effect in Effects)
			{
				if (effect.PerTurn)
				{
					effect.ApplyTo(ModifiedAttributes, BaseAttributes);
				}
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			WriteXMLStartElement(xmlWriter);
			WritePropertyXML(xmlWriter);
			WriteAttributesXML(xmlWriter);
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

			xmlWriter.WriteStartElement("Effects");
			foreach (Effect.Effect effect in Effects)
			{
				effect.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();
		}

		public virtual void WriteAttributesXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("BaseAttributes");
			BaseAttributes.WriteXML(xmlWriter);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("ModifiedAttributes");
			ModifiedAttributes.WriteXML(xmlWriter);
			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			ReadPropertyXML(xmlNode);
			ReadAttributesXML(xmlNode);
		}

		public virtual void ReadPropertyXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "ActorName")
					{
						ActorName = childNode.InnerText;
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
			}
			catch (XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		public virtual void ReadAttributesXML(XmlNode xmlNode)
		{
			bool readBase = false;
			bool readModified = false;
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "BaseAttributes")
					{
						BaseAttributes.ReadXML(childNode.ChildNodes[0]);
						readBase = true;
					}
					else if (childNode.Name == "ModifiedAttributes")
					{
						ModifiedAttributes.ReadXML(childNode.ChildNodes[0]);
						readModified = true;
					}
				}
			}
			catch (XmlException e)
			{
				MessageBox.Show(e.ToString());
			}

			if (readBase && !readModified)
			{
				ModifiedAttributes = BaseAttributes.Clone();
			}
		}
	}
}
