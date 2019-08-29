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
	public class TimedTextEffect : TimedEffect, ITextEffect
	{
		public TimedTextEffect(Types.Effect effectType, string text, int duration)
			: base(effectType, duration, false)
		{
			_text = text;
		}

		public TimedTextEffect(Types.Effect effectType, string text, int duration, bool perTurn)
			: base(effectType, duration, perTurn)
		{
			_text = text;
		}

		public TimedTextEffect(XmlNode xmlNode)
			: base(xmlNode)
		{
			ReadXML(xmlNode);
		}

		private string _text;

		public string Text
		{
			get { return _text; }
			set { SetField(ref _text, value); }
		}

		public override string ToString()
		{
			return Text;
		}

		public override void WritePropertyXML(XmlWriter xmlWriter)
		{
			base.WritePropertyXML(xmlWriter);

			xmlWriter.WriteStartElement("Text");
			xmlWriter.WriteString(Text);
			xmlWriter.WriteEndElement();
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			base.ReadXML(xmlNode);

			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Text")
					{
						Text = childNode.InnerText;
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
