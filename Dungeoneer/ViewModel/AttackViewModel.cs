using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class AttackViewModel : BaseViewModel
	{
		public AttackViewModel(Model.Attack attack = null)
		{
			if (attack != null)
			{
				_attack = attack;
			}
			else
			{
				_attack = new Model.Attack();
			}
		}

		private Model.Attack _attack;

		public Model.Attack Attack
		{
			get { return _attack; }
			set
			{
				_attack = value;
				NotifyPropertyChanged("Attack");
			}
		}

		public string Name
		{
			get { return Attack.Name; }
			set
			{
				Attack.Name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public string Modifier
		{
			get
			{
				return Methods.GetSignedNumberString(Attack.Modifier);
			}
			set
			{
				Attack.Modifier = Convert.ToInt32(value);
				NotifyPropertyChanged("Modifier");
			}
		}

		public string Type
		{
			get
			{
				return Methods.GetAttackTypeString(Attack.Type);
			}
			set
			{
				Attack.Type = Methods.GetAttackTypeFromString(value);
				NotifyPropertyChanged("Type");
			}
		}

		public string ThreatRange
		{
			get
			{
				return Methods.GetThreatRangeString(Attack.ThreatRangeMin);
			}
			set
			{
				string min = value.Substring(0, 2);
				Attack.ThreatRangeMin = Convert.ToInt32(min);
				NotifyPropertyChanged("ThreatRange");
			}
		}

		public string CritMultiplier
		{
			get
			{
				return "x" + Convert.ToString(Attack.CritMultiplier);
			}
			set
			{
				string multiplier = value.Substring(1, 1);
				Attack.CritMultiplier = Convert.ToInt32(multiplier);
				NotifyPropertyChanged("CritMultiplier");
			}
		}

		public override string ToString()
		{
			return Attack.ToString();
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			Attack.WriteXML(xmlWriter);
		}

		public void ReadXML(XmlNode xmlNode)
		{
			Model.Attack attack = new Model.Attack();
			attack.ReadXML(xmlNode);
			Attack = attack;
		}
	}
}
