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
	public class InitiativeValue : BaseModel
	{
		private int? _score;
		private int? _adjust;
		private int? _modifier;
		private int? _roll;
		private bool _delayed;
		private bool _turnEnded;
		private bool _readied;

		public InitiativeValue()
		{
			_score = null;
			_adjust = null;
			_modifier = null;
			_roll = null;
			_delayed = false;
			_turnEnded = false;
			_readied = false;
		}

		public int? Score
		{
			get { return _score; }
			set
			{
				_score = value;
				NotifyPropertyChanged("InitiativeScore");
			}
		}

		public int? Adjust
		{
			get { return _adjust; }
			set
			{
				_adjust = value;
				NotifyPropertyChanged("InitiativeAdjust");
			}
		}

		public int? Modifier
		{
			get { return _modifier; }
			set
			{
				_modifier = value;
				NotifyPropertyChanged("InitiativeMod");
			}
		}

		public int? Roll
		{
			get { return _roll; }
			set
			{
				_roll = value;
				NotifyPropertyChanged("InitiativeRoll");
			}
		}

		public bool Delayed
		{
			get { return _delayed; }
			set
			{
				_delayed = value;
				NotifyPropertyChanged("Delayed");
			}
		}

		public bool TurnEnded
		{
			get { return _turnEnded; }
			set
			{
				_turnEnded = value;
				NotifyPropertyChanged("TurnEnded");
			}
		}

		public bool Readied
		{
			get { return _readied; }
			set
			{
				_readied = value;
				NotifyPropertyChanged("Readied");
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("InitiativeValue");

			xmlWriter.WriteStartElement("Score");
			xmlWriter.WriteString(Score.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Adjust");
			xmlWriter.WriteString(Adjust.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Modifier");
			xmlWriter.WriteString(Modifier.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Roll");
			xmlWriter.WriteString(Roll.ToString());
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
					if (childNode.Name == "Score")
					{
						Score = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Adjust")
					{
						Adjust = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Modifier")
					{
						Modifier = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Roll")
					{
						Roll = Convert.ToInt32(childNode.InnerText);
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
	}
}
