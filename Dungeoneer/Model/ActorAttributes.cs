using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;
using System.Xml;
using System.Windows.Forms;

namespace Dungeoneer.Model
{
	[Serializable]
	public class ActorAttributes : BaseModel
	{
		public ActorAttributes()
		{
			InitiativeMod = 0;
			Active = true;
		}

		public ActorAttributes(ActorAttributes other)
		{
			InitiativeMod = other._initiativeMod;
			Active = other._active;
		}

		private int _initiativeMod;
		private bool _active;

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

		public void WriteXML(XmlWriter xmlWriter)
		{
			WriteXMLStartElement(xmlWriter);
			WritePropertyXML(xmlWriter);
			xmlWriter.WriteEndElement();
		}

		public virtual void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("ActorAttributes");
		}

		public virtual void WritePropertyXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("InitiativeMod");
			xmlWriter.WriteString(InitiativeMod.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Active");
			xmlWriter.WriteString(Active.ToString());
			xmlWriter.WriteEndElement();
		}

		public virtual void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "InitiativeMod")
					{
						InitiativeMod = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Active")
					{
						Active = Convert.ToBoolean(childNode.InnerText);
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
