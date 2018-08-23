using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Dungeoneer.Model
{
	public class Condition : BaseModel
	{
		private string _name;
		private int _value;
		private int? _originalDuration;
		private int? _elapsedDuration;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public int Value
		{
			get { return _value; }
			set
			{
				_value = value;
				NotifyPropertyChanged("Value");
			}
		}

		public int? OriginalDuration
		{
			get { return _originalDuration; }
			set
			{
				_originalDuration = value;
				NotifyPropertyChanged("OriginalDuration");
			}
		}

		public int? ElapsedDuration
		{
			get { return _elapsedDuration; }
			set
			{
				_elapsedDuration = value;
				NotifyPropertyChanged("ElapsedDuration");
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Condition");

			xmlWriter.WriteStartElement("Name");
			xmlWriter.WriteString(Name);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Value");
			xmlWriter.WriteString(Value.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("OriginalDuration");
			xmlWriter.WriteString(OriginalDuration.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("ElapsedDuration");
			xmlWriter.WriteString(ElapsedDuration.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Name")
					{
						Name = childNode.InnerText;
					}
					else if (childNode.Name == "Value")
					{
						Value = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "OriginalDuration")
					{
						OriginalDuration = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "ElapsedDuration")
					{
						ElapsedDuration = Convert.ToInt32(childNode.InnerText);
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
