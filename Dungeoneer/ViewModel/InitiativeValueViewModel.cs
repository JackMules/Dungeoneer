using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dungeoneer.ViewModel
{
	public class InitiativeValueViewModel : BaseViewModel
	{
		public InitiativeValueViewModel()
		{
			_initiativeValue = new Model.InitiativeValue();
			_initiativeSet = false;
		}

		public InitiativeValueViewModel(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
		}

		private Model.InitiativeValue _initiativeValue;
		private bool _initiativeSet;

		public Model.InitiativeValue InitiativeValue
		{
			get { return _initiativeValue; }
			set
			{
				_initiativeValue = value;
				NotifyPropertyChanged("InitiativeValue");
				InitiativeSet = _initiativeValue.Score.HasValue;
			}
		}

		public string InitiativeScore
		{
			get
			{
				if (InitiativeValue.Score.HasValue)
				{
					return InitiativeValue.Score.ToString();
				}
				else
				{
					return "0";
				}
			}
			set
			{
				InitiativeValue.Score = Convert.ToInt32(value);
				NotifyPropertyChanged("InitiativeScore");
				NotifyPropertyChanged("InitiativeValue");
				InitiativeSet = InitiativeValue.Score.HasValue;
			}
		}

		public string InitiativeAdjust
		{
			get
			{
				if (InitiativeValue.Adjust.HasValue)
				{
					return InitiativeValue.Adjust.ToString();
				}
				else
				{
					return "0";
				}
			}
			set
			{
				InitiativeValue.Adjust = Convert.ToInt32(value);
				NotifyPropertyChanged("InitiativeAdjust");
				NotifyPropertyChanged("InitiativeValue");
				InitiativeSet = InitiativeValue.Adjust.HasValue;
			}
		}

		public string InitiativeMod
		{
			get
			{
				if (InitiativeSet)
				{
					return InitiativeValue.Modifier.ToString();
				}
				else
				{
					return "0";
				}
			}
			set
			{
				InitiativeValue.Modifier = Convert.ToInt32(value);
				NotifyPropertyChanged("InitiativeMod");
				NotifyPropertyChanged("InitiativeValue");
			}
		}

		public string InitiativeRoll
		{
			get
			{
				if (InitiativeSet)
				{
					return InitiativeValue.Roll.ToString();
				}
				else
				{
					return "0";
				}
			}
			set
			{
				InitiativeValue.Roll = Convert.ToInt32(value);
				NotifyPropertyChanged("InitiativeRoll");
				NotifyPropertyChanged("InitiativeValue");
			}
		}

		public bool InitiativeSet
		{
			get { return _initiativeSet; }
			set
			{
				_initiativeSet = value;
				NotifyPropertyChanged("InitiativeSet");
			}
		}

		public bool Delayed
		{
			get { return InitiativeValue.Delayed; }
			set
			{
				InitiativeValue.Delayed = value;
				NotifyPropertyChanged("Delayed");
			}
		}

		public bool TurnEnded
		{
			get { return InitiativeValue.TurnEnded; }
			set
			{
				InitiativeValue.TurnEnded = value;
				NotifyPropertyChanged("TurnEnded");
			}
		}

		public bool Readied
		{
			get { return InitiativeValue.Readied; }
			set
			{
				InitiativeValue.Readied = value;
				NotifyPropertyChanged("Readied");
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			InitiativeValue.WriteXML(xmlWriter);
		}

		public void ReadXML(XmlNode xmlNode)
		{
			InitiativeValue = new Model.InitiativeValue(xmlNode);
		}
	}
}
