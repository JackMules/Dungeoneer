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
	[Serializable]
	public class Attack : BaseModel
	{
		public Attack()
		{
			_name = "";
			_modifier = 0;
			_type = Types.Attack.Melee;
			_ability = Types.Ability.Strength;
			_threatRangeMin = 20;
			_critMultiplier = 2;
			_twoHanded = false;
		}

		public Attack(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
		}

		private string _name;
		private int _modifier;
		private Types.Attack _type;
		private Types.Ability _ability;
		private FullyObservableCollection<Damage> _damages = new FullyObservableCollection<Damage>();
		private int _threatRangeMin;
		private int _critMultiplier;
		private bool _twoHanded;

		public string Name
		{
			get { return _name; }
			set { SetField(ref _name, value); }
		}

		public int Modifier
		{
			get { return _modifier; }
			set { SetField(ref _modifier, value); }
		}

		public Types.Attack Type
		{
			get { return _type; }
			set { SetField(ref _type, value); }
		}

		public Types.Ability Ability
		{
			get { return _ability; }
			set { SetField(ref _ability, value); }
		}

		public FullyObservableCollection<Damage> Damages
		{
			get { return _damages; }
			set { SetField(ref _damages, value); }
		}

		public int ThreatRangeMin
		{
			get { return _threatRangeMin; }
			set { SetField(ref _threatRangeMin, value); }
		}

		public int CritMultiplier
		{
			get { return _critMultiplier; }
			set { SetField(ref _critMultiplier, value); }
		}

		public bool TwoHanded
		{
			get { return _twoHanded; }
			set { SetField(ref _twoHanded, value); }
		}

		public string AsString
		{
			get { return ToString(); }
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

			xmlWriter.WriteStartElement("TwoHanded");
			xmlWriter.WriteString(TwoHanded.ToString());
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
								Damages.Add(new Damage(damageNode));
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
					else if (childNode.Name == "TwoHanded")
					{
						TwoHanded = Convert.ToBoolean(childNode.InnerText);
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
