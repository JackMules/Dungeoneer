using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.Model.Effect
{
	[Serializable]
	public class TimedValueEffect : TimedEffect, IValueEffect
	{
		public TimedValueEffect(Types.Effect effectType, int value, int duration)
			: base(effectType, duration, false)
		{
			_value = value;
		}

		public TimedValueEffect(Types.Effect effectType, int value, int duration, bool perTurn)
			: base(effectType, duration, perTurn)
		{
			_value = value;
		}

		public TimedValueEffect(XmlNode xmlNode)
			: base(xmlNode)
		{
			ReadXML(xmlNode);
		}

		private int _value;

		public int Value
		{
			get { return _value; }
			set { SetField(ref _value, value); }
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(EffectType) + " " + Methods.GetSignedNumberString(Value);
		}

		public override void WritePropertyXML(XmlWriter xmlWriter)
		{
			base.WritePropertyXML(xmlWriter);

			xmlWriter.WriteStartElement("Value");
			xmlWriter.WriteString(Value.ToString());
			xmlWriter.WriteEndElement();
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			base.ReadXML(xmlNode);

			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Value")
					{
						Value = Convert.ToInt32(childNode.InnerText);
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
