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

		private Model.InitiativeValue _initiativeValue;
		private bool _initiativeSet;

		public Model.InitiativeValue InitiativeValue
		{
			get { return _initiativeValue; }
			set
			{
				_initiativeValue = value;
				NotifyPropertyChanged("InitiativeValue");
			}
		}

		public string InitiativeScore
		{
			get
			{
				if (InitiativeValue.InitiativeScore.HasValue)
				{
					return InitiativeValue.InitiativeScore.ToString();
				}
				else
				{
					return "Not set";
				}
			}
			set
			{
				InitiativeValue.InitiativeScore = Convert.ToInt32(value);
				NotifyPropertyChanged("InitiativeScore");
				NotifyPropertyChanged("InitiativeValue");
				InitiativeSet = InitiativeValue.InitiativeScore.HasValue;
			}
		}

		public string InitiativeAdjust
		{
			get
			{
				if (InitiativeValue.InitiativeAdjust.HasValue)
				{
					return InitiativeValue.InitiativeAdjust.ToString();
				}
				else
				{
					return "Not set";
				}
			}
			set
			{
				InitiativeValue.InitiativeAdjust = Convert.ToInt32(value);
				NotifyPropertyChanged("InitiativeAdjust");
				NotifyPropertyChanged("InitiativeValue");
				InitiativeSet = InitiativeValue.InitiativeAdjust.HasValue;
			}
		}

		public string InitiativeMod
		{
			get
			{
				if (InitiativeSet)
				{
					return InitiativeValue.InitiativeMod.ToString();
				}
				else
				{
					return "Not set";
				}
			}
			set
			{
				InitiativeValue.InitiativeMod = Convert.ToInt32(value);
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
					return InitiativeValue.InitiativeRoll.ToString();
				}
				else
				{
					return "Not set";
				}
			}
			set
			{
				InitiativeValue.InitiativeRoll = Convert.ToInt32(value);
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
			InitiativeValue.ReadXML(xmlNode);
		}
	}
}
