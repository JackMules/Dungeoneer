using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Dungeoneer.Utility;

namespace Dungeoneer.Model
{
	public class InitiativeValue : BaseModel
	{
		private int? _score;
		private int? _adjust;
		private int? _modifier;
		private int? _roll;
		private bool _delayed;
		private Types.TurnState _turnState;
		private bool _readied;

		public InitiativeValue()
		{
			_score = null;
			_adjust = null;
			_modifier = null;
			_roll = null;
			_delayed = false;
			_turnState = Types.TurnState.NotStarted;
			_readied = false;
		}

		public InitiativeValue(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
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

		public Types.TurnState TurnState
		{
			get { return _turnState; }
			set
			{
				_turnState = value;
				NotifyPropertyChanged("TurnState");
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

			xmlWriter.WriteStartElement("TurnState");
			xmlWriter.WriteString(Methods.GetTurnStateString(TurnState));
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
						try
						{
							Score = Convert.ToInt32(childNode.InnerText);
						}
						catch (FormatException)
						{
							Score = null;
						}
					}
					else if (childNode.Name == "Adjust")
					{
						try
						{
							Adjust = Convert.ToInt32(childNode.InnerText);
						}
						catch (FormatException)
						{
							Score = null;
						}
					}
					else if (childNode.Name == "Modifier")
					{
						try
						{
							Modifier = Convert.ToInt32(childNode.InnerText);
						}
						catch (FormatException)
						{
							Score = null;
						}
					}
					else if (childNode.Name == "Roll")
					{
						try
						{
							Roll = Convert.ToInt32(childNode.InnerText);
						}
						catch (FormatException)
						{
							Score = null;
						}
					}
					else if (childNode.Name == "Delayed")
					{
						Delayed = Convert.ToBoolean(childNode.InnerText);
					}
					else if (childNode.Name == "TurnEnded")
					{
						TurnState = Methods.GetTurnStateFromString(childNode.InnerText);
					}
					else if (childNode.Name == "Readied")
					{
						Readied = Convert.ToBoolean(childNode.InnerText);
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
