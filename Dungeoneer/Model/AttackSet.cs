using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;
using System.Xml;

namespace Dungeoneer.Model
{
	public class AttackSet : BaseModel
	{
		public AttackSet()
		{
			_attacks = new FullyObservableCollection<Attack>();
		}

		private string _name;
		private FullyObservableCollection<Attack> _attacks;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public FullyObservableCollection<Attack> Attacks
		{
			get { return _attacks; }
			set
			{
				_attacks = value;
				NotifyPropertyChanged("Attacks");
			}
		}

		public override string ToString()
		{
			if (Name != "")
			{
				return Name;
			}
			else
			{
				return "Unnamed attack set";
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("AttackSet");
			xmlWriter.WriteAttributeString("Name", Name);
			foreach (Attack attack in Attacks)
			{
				attack.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			foreach (XmlAttribute xmlAttribute in xmlNode.Attributes)
			{
				if (xmlAttribute.Name == "Name")
				{
					Name = xmlAttribute.Value;
				}
			}

			foreach (XmlNode attackNode in xmlNode.ChildNodes)
			{
				if (attackNode.Name == "Attack")
				{
					Attack attack = new Attack();
					attack.ReadXML(attackNode);
					Attacks.Add(attack);
				}
			}
		}
	}
}
