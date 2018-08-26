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
			DisplayName = "";
			ActorName = "";
			InitiativeMod = 0;
			Active = true;
			Conditions = new Utility.FullyObservableCollection<Condition>();
		}

		private string _displayName;
		private string _actorName;
		private int _initiativeMod;
		private bool _active;
		private Utility.FullyObservableCollection<Condition> _conditions;

		public string DisplayName
		{
			get { return _displayName; }
			set
			{
				_displayName = value;
				NotifyPropertyChanged("DisplayName");
			}
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

		public Utility.FullyObservableCollection<Condition> Conditions
		{
			get { return _conditions; }
			set
			{
				_conditions = value;
				NotifyPropertyChanged("Conditions");
			}
		}

		public Actor(
			string displayName,
			string actorName,
			int initiativeMod,
			Utility.FullyObservableCollection<Condition> conditions)
		{
			DisplayName = displayName;
			ActorName = actorName;
			InitiativeMod = initiativeMod;
			Active = true;
			Conditions = conditions;
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

			xmlWriter.WriteStartElement("DisplayName");
			xmlWriter.WriteString(DisplayName);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("InitiativeMod");
			xmlWriter.WriteString(InitiativeMod.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Conditions");
			foreach (Condition condition in Conditions)
			{
				condition.WriteXML(xmlWriter);
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
					else if (childNode.Name == "DisplayName")
					{
						DisplayName = childNode.InnerText;
					}
					else if (childNode.Name == "InitiativeMod")
					{
						InitiativeMod = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Conditions")
					{
						foreach (XmlNode conditionNode in childNode.ChildNodes)
						{
							if (conditionNode.Name == "Condition")
							{
								Condition condition = new Condition();
								condition.ReadXML(conditionNode);
								Conditions.Add(condition);
							}
						}
					}
				}
			}
			catch (System.Xml.XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}
	}
}
