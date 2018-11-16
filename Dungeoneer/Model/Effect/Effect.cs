using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Dungeoneer.Model.Effect
{
	public abstract class Effect : BaseModel
	{
		protected Effect()
		{
			PerTurn = false;
		}

		public Effect(bool perTurn)
		{
			PerTurn = perTurn;
		}

		public Effect(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
		}

		private bool _perTurn;
		private string _name;

		public bool PerTurn
		{
			get { return _perTurn; }
			private set { _perTurn = value; }
		}

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public override string ToString()
		{
			return Name;
		}

		public virtual void AdvanceTurn()
		{ }

		public virtual bool Expired()
		{
			return false;
		}

		public virtual void ApplyTo(ActorAttributes attributes)
		{ }

		public void WriteXML(XmlWriter xmlWriter)
		{
			WriteXMLStartElement(xmlWriter);
			WritePropertyXML(xmlWriter);
			xmlWriter.WriteEndElement();
		}

		public abstract void WriteXMLStartElement(XmlWriter xmlWriter);

		public virtual void WritePropertyXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("PerTurn");
			xmlWriter.WriteString(PerTurn.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Name");
			xmlWriter.WriteString(Name);
			xmlWriter.WriteEndElement();
		}

		public virtual void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "PerTurn")
					{
						PerTurn = Convert.ToBoolean(childNode.InnerText);
					}
					else if (childNode.Name == "Name")
					{
						Name = childNode.InnerText;
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
