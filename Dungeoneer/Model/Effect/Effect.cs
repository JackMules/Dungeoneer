using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Dungeoneer.Utility;

namespace Dungeoneer.Model.Effect
{
	[Serializable]
	public class Effect : BaseModel
	{
		public Effect(Types.Effect effectType)
		{
			EffectType = effectType;
			PerTurn = false;
		}

		public Effect(Types.Effect effectType, bool perTurn)
		{
			EffectType = effectType;
			PerTurn = perTurn;
		}

		public Effect(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
		}

		private Types.Effect _effectType;
		private bool _perTurn;

		public Types.Effect EffectType
		{
			get { return _effectType; }
			set { SetField(ref _effectType, value); }
		}

		public bool PerTurn
		{
			get { return _perTurn; }
			set { SetField(ref _perTurn, value); }
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(EffectType);
		}

		public virtual void AdvanceTurn()
		{ }

		public virtual bool Expired()
		{
			return false;
		}

		public void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).ApplyEffect(this);
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			WriteXMLStartElement(xmlWriter);
			WritePropertyXML(xmlWriter);
			xmlWriter.WriteEndElement();
		}

		public void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public virtual void WritePropertyXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("EffectType");
			xmlWriter.WriteString(Methods.GetEffectTypeString(EffectType));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("PerTurn");
			xmlWriter.WriteString(PerTurn.ToString());
			xmlWriter.WriteEndElement();
		}

		public virtual void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "EffectType")
					{
						EffectType = Methods.GetEffectTypeFromString(childNode.InnerText);
					}
					else if (childNode.Name == "PerTurn")
					{
						PerTurn = Convert.ToBoolean(childNode.InnerText);
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
