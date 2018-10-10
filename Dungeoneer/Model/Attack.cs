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
	public class Attack : BaseModel
	{
		public Attack()
		{
			_name = "";
			_modifier = 0;
			_type = Types.Attack.Primary;
			_ability = Types.Ability.Strength;
			_damages = new FullyObservableCollection<Damage>();
			_threatRangeMin = 20;
			_critMultiplier = 2;
		}

		public Attack(
			string name,
			int attackMod,
			Types.Attack attackType,
			Types.Ability ability,
			FullyObservableCollection<Damage> damages,
			int threatRangeMin,
			int critMultiplier)
		{
			Name = name;
			Modifier = attackMod;
			Type = attackType;
			Ability = ability;
			Damages = damages;
			ThreatRangeMin = threatRangeMin;
			CritMultiplier = critMultiplier;
		}

		private string _name;
		private int _modifier;
		private Types.Attack _type;
		private Types.Ability _ability;
		private FullyObservableCollection<Damage> _damages;
		private int _threatRangeMin;
		private int _critMultiplier;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public int Modifier
		{
			get { return _modifier; }
			set
			{
				_modifier = value;
				NotifyPropertyChanged("Modifier");
			}
		}

		public Types.Attack Type
		{
			get { return _type; }
			set
			{
				_type = value;
				NotifyPropertyChanged("Type");
			}
		}

		public Types.Ability Ability
		{
			get { return _ability; }
			set
			{
				_ability = value;
				NotifyPropertyChanged("Ability");
			}
		}

		public FullyObservableCollection<Damage> Damages
		{
			get { return _damages; }
			set
			{
				_damages = value;
				NotifyPropertyChanged("Damages");
			}
		}

		public int ThreatRangeMin
		{
			get { return _threatRangeMin; }
			set
			{
				_threatRangeMin = value;
				NotifyPropertyChanged("ThreatRangeMin");
			}
		}

		public int CritMultiplier
		{
			get { return _critMultiplier; }
			set
			{
				_critMultiplier = value;
				NotifyPropertyChanged("CritMultiplier");
			}
		}

		public override string ToString()
		{
			return Name + " (" + Methods.GetAttackTypeString(Type) + "): " + Methods.GetSignedNumberString(Modifier) + ", " + Methods.GetDamageString(Damages);
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Attack");

			xmlWriter.WriteStartElement("Name");
			xmlWriter.WriteString(Name);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Modifier");
			xmlWriter.WriteString(Modifier.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Type");
			xmlWriter.WriteString(Methods.GetAttackTypeString(Type));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Ability");
			xmlWriter.WriteString(Methods.GetAbilityString(Ability));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Damages");
			foreach (Damage damage in Damages)
			{
				damage.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("ThreatRangeMin");
			xmlWriter.WriteString(ThreatRangeMin.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("CritMultiplier");
			xmlWriter.WriteString(CritMultiplier.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Name")
					{
						Name = childNode.InnerText;
					}
					else if (childNode.Name == "Modifier")
					{
						Modifier = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Type")
					{
						Type = Methods.GetAttackTypeFromString(childNode.InnerText);
					}
					else if (childNode.Name == "Ability")
					{
						Ability = Methods.GetAbilityFromString(childNode.InnerText);
					}
					else if (childNode.Name == "Damages")
					{
						foreach (XmlNode damageNode in childNode.ChildNodes)
						{
							if (damageNode.Name == "Damage")
							{
								Damage damage = new Damage();
								damage.ReadXML(damageNode);
								Damages.Add(damage);
							}
						}
					}
					else if (childNode.Name == "ThreatRangeMin")
					{
						ThreatRangeMin = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "CritMultiplier")
					{
						CritMultiplier = Convert.ToInt32(childNode.InnerText);
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
