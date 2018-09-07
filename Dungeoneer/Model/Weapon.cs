using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dungeoneer.Utility;
using System.Xml;

namespace Dungeoneer.Model
{
	public class Weapon : BaseModel
	{
		public Weapon()
		{
			_damageDescriptorSet = new DamageDescriptorSet();
		}

		private string _name;
		private DamageDescriptorSet _damageDescriptorSet;
		private bool _abilityDamage;
		private int _abilityDamageValue;
		private Types.Ability _ability;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public DamageDescriptorSet DamageDescriptorSet
		{
			get { return _damageDescriptorSet; }
			set
			{
				_damageDescriptorSet = value;
				NotifyPropertyChanged("DamageDescriptorSet");
			}
		}

		public bool AbilityDamage
		{
			get { return _abilityDamage; }
			set
			{
				_abilityDamage = value;
				NotifyPropertyChanged("AbilityDamage");
			}
		}

		public int AbilityDamageValue
		{
			get { return _abilityDamageValue; }
			set
			{
				_abilityDamageValue = value;
				NotifyPropertyChanged("AbilityDamageValue");
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

		public override string ToString()
		{
			return Name;
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Weapon");
			
			xmlWriter.WriteStartElement("Name");
			xmlWriter.WriteString(Name);
			xmlWriter.WriteEndElement();

			if (AbilityDamage)
			{
				xmlWriter.WriteStartElement("AbilityDamage");
				xmlWriter.WriteAttributeString("Name", Methods.GetAbilityString(Ability));
				xmlWriter.WriteAttributeString("Value", AbilityDamageValue.ToString());
				xmlWriter.WriteEndElement();
			}

			DamageDescriptorSet.WriteXML(xmlWriter);

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
					else if (childNode.Name == "DamageDescriptorSet")
					{
						DamageDescriptorSet damageDescriptorSet = new DamageDescriptorSet();
						damageDescriptorSet.ReadXML(childNode);
						DamageDescriptorSet = damageDescriptorSet;
					}
					else if (childNode.Name == "AbilityDamage")
					{
						AbilityDamage = true;
						foreach (XmlAttribute attribute in childNode.Attributes)
						{
							if (attribute.Name == "Ability")
							{
								Ability = Methods.GetAbilityFromString(attribute.Value);
							}
							else if (attribute.Name == "Value")
							{
								AbilityDamageValue = Convert.ToInt32(attribute.Value);
							}
						}
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
