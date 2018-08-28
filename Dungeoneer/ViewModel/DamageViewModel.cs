using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class DamageViewModel : BaseViewModel
	{
		public DamageViewModel()
		{
			_damage = new Model.Damage();
		}

		private Model.Damage _damage;

		public Model.Damage Damage
		{
			get { return _damage; }
			set
			{
				_damage = value;
				NotifyPropertyChanged("Damage");
			}
		}

		public string NumDice
		{
			get
			{
				return Damage.NumDice.ToString();
			}
			set
			{
				Damage.NumDice = Convert.ToInt32(value);
				NotifyPropertyChanged("NumDice");
			}
		}

		public string Die
		{
			get
			{
				return Methods.GetDieTypeString(Damage.Die);
			}
			set
			{
				Damage.Die = Methods.GetDieTypeFromString(value);
				NotifyPropertyChanged("Die");
			}
		}

		public string Modifier
		{
			get
			{
				return Damage.Modifier.ToString();
			}
			set
			{
				Damage.Modifier = Convert.ToInt32(value);
				NotifyPropertyChanged("Modifier");
			}
		}

		public string Type
		{
			get
			{
				return Methods.GetDamageTypeString(Damage.Type);
			}
			set
			{
				Damage.Type = Methods.GetDamageTypeFromString(value);
				NotifyPropertyChanged("Type");
			}
		}

		public override string ToString()
		{
			return Damage.ToString();
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			Damage.WriteXML(xmlWriter);
		}

		public void ReadXML(XmlNode xmlNode)
		{
			Model.Damage damage = new Model.Damage();
			damage.ReadXML(xmlNode);
			Damage = damage;
		}
	}
}
