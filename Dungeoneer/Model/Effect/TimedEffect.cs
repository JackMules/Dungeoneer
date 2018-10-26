using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;
using System.Xml;
using System.Windows.Forms;

namespace Dungeoneer.Model.Effect
{
	public abstract class TimedEffect : Effect
	{
		public TimedEffect(bool perTurn)
			: base(perTurn)
		{

		}
		
		private int _duration;
		private int _elapsedDuration;

		public int Duration
		{
			get { return _duration; }
			set
			{
				_duration = value;
				NotifyPropertyChanged("Duration");
			}
		}

		public int ElapsedDuration
		{
			get { return _elapsedDuration; }
			set
			{
				_elapsedDuration = value;
				NotifyPropertyChanged("ElapsedDuration");
			}
		}

		public override bool Expired()
		{
			return (ElapsedDuration >= Duration);
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("TemporaryEffect");
		}

		public override void WritePropertyXML(XmlWriter xmlWriter)
		{
			base.WritePropertyXML(xmlWriter);

			xmlWriter.WriteStartElement("Duration");
			xmlWriter.WriteString(Duration.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("ElapsedDuration");
			xmlWriter.WriteString(ElapsedDuration.ToString());
			xmlWriter.WriteEndElement();
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			base.ReadXML(xmlNode);

			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Duration")
					{
						Duration = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "ElapsedDuration")
					{
						ElapsedDuration = Convert.ToInt32(childNode.InnerText);
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
