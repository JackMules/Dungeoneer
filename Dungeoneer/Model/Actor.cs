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
		}

		private string _actorName;
		private int _initiativeMod;
		private bool _active;

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

		public Actor(
			string actorName,
			int initiativeMod)
		{
			ActorName = actorName;
			InitiativeMod = initiativeMod;
			Active = true;
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
				}
			}
			catch (XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}
	}
}
