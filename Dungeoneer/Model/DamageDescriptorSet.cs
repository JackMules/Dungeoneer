using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;
using System.Xml;

namespace Dungeoneer.Model
{
	public class DamageDescriptorSet : BaseModel
	{
		public DamageDescriptorSet()
		{
			_descriptors = new List<Types.Damage>();
		}

		private List<Types.Damage> _descriptors;

		public bool Contains(Types.Damage damageType)
		{
			return _descriptors.Contains(damageType);
		}

		private void SetDamageType(Types.Damage damageType, bool setPresent)
		{
			if (setPresent)
			{
				_descriptors.Add(damageType);
			}
			else
			{
				_descriptors.RemoveAll(d => d == damageType);
			}
		}

		public bool Acid
		{
			get { return Contains(Types.Damage.Acid); }
			set
			{
				SetDamageType(Types.Damage.Acid, value);
				NotifyPropertyChanged("Acid");
			}
		}

		public bool Adamantine
		{
			get { return Contains(Types.Damage.Adamantine); }
			set
			{
				SetDamageType(Types.Damage.Adamantine, value);
				NotifyPropertyChanged("Adamantine");
			}
		}

		public bool Bludgeoning
		{
			get { return Contains(Types.Damage.Bludgeoning); }
			set
			{
				SetDamageType(Types.Damage.Bludgeoning, value);
				NotifyPropertyChanged("Bludgeoning");
			}
		}

		public bool Chaos
		{
			get { return Contains(Types.Damage.Chaos); }
			set
			{
				SetDamageType(Types.Damage.Chaos, value);
				NotifyPropertyChanged("Chaos");
			}
		}

		public bool Cold
		{
			get { return Contains(Types.Damage.Cold); }
			set
			{
				SetDamageType(Types.Damage.Cold, value);
				NotifyPropertyChanged("Cold");
			}
		}

		public bool ColdIron
		{
			get { return Contains(Types.Damage.ColdIron); }
			set
			{
				SetDamageType(Types.Damage.ColdIron, value);
				NotifyPropertyChanged("ColdIron");
			}
		}

		public bool Divine
		{
			get { return Contains(Types.Damage.Divine); }
			set
			{
				SetDamageType(Types.Damage.Divine, value);
				NotifyPropertyChanged("Divine");
			}
		}

		public bool Electricity
		{
			get { return Contains(Types.Damage.Electricity); }
			set
			{
				SetDamageType(Types.Damage.Electricity, value);
				NotifyPropertyChanged("Electricity");
			}
		}
		public bool Epic
		{
			get { return Contains(Types.Damage.Epic); }
			set
			{
				SetDamageType(Types.Damage.Epic, value);
				NotifyPropertyChanged("Epic");
			}
		}

		public bool Evil
		{
			get { return Contains(Types.Damage.Evil); }
			set
			{
				SetDamageType(Types.Damage.Evil, value);
				NotifyPropertyChanged("Evil");
			}
		}

		public bool Fire
		{
			get { return Contains(Types.Damage.Fire); }
			set
			{
				SetDamageType(Types.Damage.Fire, value);
				NotifyPropertyChanged("Fire");
			}
		}

		public bool Force
		{
			get { return Contains(Types.Damage.Force); }
			set
			{
				SetDamageType(Types.Damage.Force, value);
				NotifyPropertyChanged("Force");
			}
		}

		public bool Good
		{
			get { return Contains(Types.Damage.Good); }
			set
			{
				SetDamageType(Types.Damage.Good, value);
				NotifyPropertyChanged("Good");
			}
		}

		public bool Law
		{
			get { return Contains(Types.Damage.Law); }
			set
			{
				SetDamageType(Types.Damage.Law, value);
				NotifyPropertyChanged("Law");
			}
		}

		public bool Magic
		{
			get { return Contains(Types.Damage.Magic); }
			set
			{
				SetDamageType(Types.Damage.Magic, value);
				NotifyPropertyChanged("Magic");
			}
		}

		public bool NegativeEnergy
		{
			get { return Contains(Types.Damage.NegativeEnergy); }
			set
			{
				SetDamageType(Types.Damage.NegativeEnergy, value);
				NotifyPropertyChanged("NegativeEnergy");
			}
		}

		public bool Piercing
		{
			get { return Contains(Types.Damage.Piercing); }
			set
			{
				SetDamageType(Types.Damage.Piercing, value);
				NotifyPropertyChanged("Piercing");
			}
		}

		public bool PositiveEnergy
		{
			get { return Contains(Types.Damage.PositiveEnergy); }
			set
			{
				SetDamageType(Types.Damage.PositiveEnergy, value);
				NotifyPropertyChanged("PositiveEnergy");
			}
		}

		public bool Silver
		{
			get { return Contains(Types.Damage.Silver); }
			set
			{
				SetDamageType(Types.Damage.Silver, value);
				NotifyPropertyChanged("Silver");
			}
		}

		public bool Slashing
		{
			get { return Contains(Types.Damage.Slashing); }
			set
			{
				SetDamageType(Types.Damage.Slashing, value);
				NotifyPropertyChanged("Slashing");
			}
		}

		public bool Sonic
		{
			get { return Contains(Types.Damage.Sonic); }
			set
			{
				SetDamageType(Types.Damage.Sonic, value);
				NotifyPropertyChanged("Sonic");
			}
		}

		public bool Subdual
		{
			get { return Contains(Types.Damage.Subdual); }
			set
			{
				SetDamageType(Types.Damage.Subdual, value);
				NotifyPropertyChanged("Subdual");
			}
		}

		public override string ToString()
		{
			List<string> damageStrings = new List<string>();

			foreach (Types.Damage damageType in _descriptors)
			{
				damageStrings.Add(Methods.GetDamageTypeString(damageType));
			}

			return String.Join(" ", damageStrings);
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("DamageDescriptorSet");
			
			xmlWriter.WriteAttributeString("Acid",						Acid.ToString());
			xmlWriter.WriteAttributeString("Adamantine",			Adamantine.ToString());
			xmlWriter.WriteAttributeString("Bludgeoning",			Bludgeoning.ToString());
			xmlWriter.WriteAttributeString("Chaos",						Chaos.ToString());
			xmlWriter.WriteAttributeString("Cold",						Cold.ToString());
			xmlWriter.WriteAttributeString("ColdIron",				ColdIron.ToString());
			xmlWriter.WriteAttributeString("Divine",					Divine.ToString());
			xmlWriter.WriteAttributeString("Electricity",			Electricity.ToString());
			xmlWriter.WriteAttributeString("Epic",						Epic.ToString());
			xmlWriter.WriteAttributeString("Evil",						Evil.ToString());
			xmlWriter.WriteAttributeString("Fire",						Fire.ToString());
			xmlWriter.WriteAttributeString("Force",						Force.ToString());
			xmlWriter.WriteAttributeString("Good",						Good.ToString());
			xmlWriter.WriteAttributeString("Law",							Law.ToString());
			xmlWriter.WriteAttributeString("Magic",						Magic.ToString());
			xmlWriter.WriteAttributeString("NegativeEnergy",	NegativeEnergy.ToString());
			xmlWriter.WriteAttributeString("Piercing",				Piercing.ToString());
			xmlWriter.WriteAttributeString("PositiveEnergy",	PositiveEnergy.ToString());
			xmlWriter.WriteAttributeString("Silver",					Silver.ToString());
			xmlWriter.WriteAttributeString("Slashing",				Slashing.ToString());
			xmlWriter.WriteAttributeString("Sonic",						Sonic.ToString());
			xmlWriter.WriteAttributeString("Subdual",					Subdual.ToString());

			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			foreach (XmlAttribute xmlAttribute in xmlNode.Attributes)
			{
				if (xmlAttribute.Name == "Acid"						) { Acid					 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Adamantine"			) { Adamantine		 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Bludgeoning"		) { Bludgeoning		 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Chaos"					) { Chaos					 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Cold"						) { Cold					 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "ColdIron"				) { ColdIron			 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Divine"					) { Divine				 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Electricity"		) { Electricity		 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Epic"						) { Epic					 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Evil"						) { Evil					 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Fire"						) { Fire					 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Force"					) { Force					 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Good"						) { Good					 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Law"						) { Law						 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Magic"					) { Magic					 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "NegativeEnergy"	) { NegativeEnergy = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Piercing"				) { Piercing			 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "PositiveEnergy"	) { PositiveEnergy = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Silver"					) { Silver				 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Slashing"				) { Slashing			 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Sonic"					) { Sonic					 = Convert.ToBoolean(xmlAttribute.Value); }
				if (xmlAttribute.Name == "Subdual"				) { Subdual				 = Convert.ToBoolean(xmlAttribute.Value); }
			}
		}
	}
}
