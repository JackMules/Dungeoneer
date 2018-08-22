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
	public class InitiativeValue : INotifyPropertyChanged
	{
		private int? _initiativeScore;
		private int? _initiativeAdjust;
		private int? _initiativeMod;
		private int? _initiativeRoll;
		private bool _delayed;
		private bool _turnEnded;
		private bool _readied;

		public InitiativeValue()
		{
			_initiativeScore = null;
			_initiativeAdjust = null;
			_initiativeMod = null;
			_initiativeRoll = null;
			_delayed = false;
			_turnEnded = false;
			_readied = false;
		}

		public int? InitiativeScore
		{
			get { return _initiativeScore; }
			set
			{
				_initiativeScore = value;
				OnPropertyChanged("InitiativeScore");
			}
		}

		public int? InitiativeAdjust
		{
			get { return _initiativeAdjust; }
			set
			{
				_initiativeAdjust = value;
				OnPropertyChanged("InitiativeAdjust");
			}
		}

		public int? InitiativeMod
		{
			get { return _initiativeMod; }
			set
			{
				_initiativeMod = value;
				OnPropertyChanged("InitiativeMod");
			}
		}

		public int? InitiativeRoll
		{
			get { return _initiativeRoll; }
			set
			{
				_initiativeRoll = value;
				OnPropertyChanged("InitiativeRoll");
			}
		}

		public bool Delayed
		{
			get { return _delayed; }
			set
			{
				_delayed = value;
				OnPropertyChanged("Delayed");
			}
		}

		public bool TurnEnded
		{
			get { return _turnEnded; }
			set
			{
				_turnEnded = value;
				OnPropertyChanged("TurnEnded");
			}
		}

		public bool Readied
		{
			get { return _readied; }
			set
			{
				_readied = value;
				OnPropertyChanged("Readied");
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("InitiativeValue");

			xmlWriter.WriteStartElement("InitiativeScore");
			xmlWriter.WriteString(InitiativeScore.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("InitiativeAdjust");
			xmlWriter.WriteString(InitiativeAdjust.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("InitiativeMod");
			xmlWriter.WriteString(InitiativeMod.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("InitiativeRoll");
			xmlWriter.WriteString(InitiativeRoll.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Delayed");
			xmlWriter.WriteString(Delayed.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("TurnEnded");
			xmlWriter.WriteString(TurnEnded.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Readied");
			xmlWriter.WriteString(Readied.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "InitiativeScore")
					{
						InitiativeScore = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "InitiativeAdjust")
					{
						InitiativeAdjust = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "InitiativeMod")
					{
						InitiativeMod = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "InitiativeRoll")
					{
						InitiativeRoll = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Delayed")
					{
						Delayed = Convert.ToBoolean(childNode.InnerText);
					}
					else if (childNode.Name == "TurnEnded")
					{
						TurnEnded = Convert.ToBoolean(childNode.InnerText);
					}
					else if (childNode.Name == "Readied")
					{
						Readied = Convert.ToBoolean(childNode.InnerText);
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
