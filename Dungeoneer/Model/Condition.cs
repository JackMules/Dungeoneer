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
	public class Condition : INotifyPropertyChanged
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
				OnPropertyChanged("Name");
			}
		}

		public int Value
		{
			get { return _value; }
			set
			{
				_value = value;
				OnPropertyChanged("Value");
			}
		}

		public int? OriginalDuration
		{
			get { return _originalDuration; }
			set
			{
				_originalDuration = value;
				OnPropertyChanged("OriginalDuration");
			}
		}

		public int? ElapsedDuration
		{
			get { return _elapsedDuration; }
			set
			{
				_elapsedDuration = value;
				OnPropertyChanged("ElapsedDuration");
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
						Name = childNode.Value;
					}
					else if (childNode.Name == "Value")
					{
						Value = Convert.ToInt32(childNode.Value);
					}
					else if (childNode.Name == "OriginalDuration")
					{
						OriginalDuration = Convert.ToInt32(childNode.Value);
					}
					else if (childNode.Name == "ElapsedDuration")
					{
						ElapsedDuration = Convert.ToInt32(childNode.Value);
					}
				}
			}
			catch (System.Xml.XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
