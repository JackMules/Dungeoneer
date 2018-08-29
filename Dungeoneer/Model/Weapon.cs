using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;
using System.Xml;

namespace Dungeoneer.Model
{
	public class Weapon : BaseModel
	{
		public Weapon()
		{

		}

		private string _name;
		private List<Types.Damage> _damageQualities;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public List<Types.Damage> DamageQualities
		{
			get { return _damageQualities; }
			set
			{
				_damageQualities = value;
				NotifyPropertyChanged("DamageQualities");
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Weapon");

			xmlWriter.WriteStartElement("Name");
			xmlWriter.WriteString(Name);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("DamageQualities");
			foreach (Types.Damage damage in DamageQualities)
			{
				xmlWriter.WriteStartElement("Damage");
				xmlWriter.WriteString(Methods.GetDamageTypeString(damage));
				xmlWriter.WriteEndElement();
			}
			xmlWriter.WriteEndElement();
		}
	}
}
