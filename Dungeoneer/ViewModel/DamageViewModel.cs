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
		}

		public string Die
		{
			get
			{
				return Methods.GetDieTypeString(Damage.Die);
			}
		}

		public string Modifier
		{
			get
			{
				return Damage.Modifier.ToString();
			}
		}

		public string DescriptorSet
		{
			get
			{
				return Damage.DamageDescriptorSet.ToString();
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
