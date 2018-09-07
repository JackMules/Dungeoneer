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
			_acid = false;
			_adamantine = false;
			_bludgeoning = false;
			_chaos = false;
			_cold = false;
			_coldIron = false;
			_divine = false;
			_electricity = false;
			_epic = false;
			_evil = false;
			_fire = false;
			_force = false;
			_good = false;
			_law = false;
			_magic = false;
			_negativeEnergy = false;
			_piercing = false;
			_positiveEnergy = false;
			_silver = false;
			_slashing = false;
			_subdual = false;
			_sonic = false;
		}

		private bool _acid;
		private bool _adamantine;
		private bool _bludgeoning;
		private bool _chaos;
		private bool _cold;
		private bool _coldIron;
		private bool _divine;
		private bool _electricity;
		private bool _epic;
		private bool _evil;
		private bool _fire;
		private bool _force;
		private bool _good;
		private bool _law;
		private bool _magic;
		private bool _negativeEnergy;
		private bool _piercing;
		private bool _positiveEnergy;
		private bool _silver;
		private bool _slashing;
		private bool _sonic;
		private bool _subdual;

		public bool Acid
		{
			get { return _acid; }
			set
			{
				_acid = value;
				NotifyPropertyChanged("Acid");
			}
		}

		public bool Adamantine
		{
			get { return _adamantine; }
			set
			{
				_adamantine = value;
				NotifyPropertyChanged("Adamantine");
			}
		}

		public bool Bludgeoning
		{
			get { return _bludgeoning; }
			set
			{
				_bludgeoning = value;
				NotifyPropertyChanged("Bludgeoning");
			}
		}

		public bool Chaos
		{
			get { return _chaos; }
			set
			{
				_chaos = value;
				NotifyPropertyChanged("Chaos");
			}
		}

		public bool Cold
		{
			get { return _cold; }
			set
			{
				_cold = value;
				NotifyPropertyChanged("Cold");
			}
		}

		public bool ColdIron
		{
			get { return _coldIron; }
			set
			{
				_coldIron = value;
				NotifyPropertyChanged("ColdIron");
			}
		}

		public bool Divine
		{
			get { return _divine; }
			set
			{
				_divine = value;
				NotifyPropertyChanged("Divine");
			}
		}

		public bool Electricity
		{
			get { return _electricity; }
			set
			{
				_electricity = value;
				NotifyPropertyChanged("Electricity");
			}
		}
		public bool Epic
		{
			get { return _epic; }
			set
			{
				_epic = value;
				NotifyPropertyChanged("Epic");
			}
		}

		public bool Evil
		{
			get { return _evil; }
			set
			{
				_evil = value;
				NotifyPropertyChanged("Evil");
			}
		}

		public bool Fire
		{
			get { return _fire; }
			set
			{
				_fire = value;
				NotifyPropertyChanged("Fire");
			}
		}

		public bool Force
		{
			get { return _force; }
			set
			{
				_force = value;
				NotifyPropertyChanged("Force");
			}
		}

		public bool Good
		{
			get { return _good; }
			set
			{
				_good = value;
				NotifyPropertyChanged("Good");
			}
		}

		public bool Law
		{
			get { return _law; }
			set
			{
				_law = value;
				NotifyPropertyChanged("Law");
			}
		}

		public bool Magic
		{
			get { return _magic; }
			set
			{
				_magic = value;
				NotifyPropertyChanged("Magic");
			}
		}

		public bool NegativeEnergy
		{
			get { return _negativeEnergy; }
			set
			{
				_negativeEnergy = value;
				NotifyPropertyChanged("NegativeEnergy");
			}
		}

		public bool Piercing
		{
			get { return _piercing; }
			set
			{
				_piercing = value;
				NotifyPropertyChanged("Piercing");
			}
		}

		public bool PositiveEnergy
		{
			get { return _positiveEnergy; }
			set
			{
				_positiveEnergy = value;
				NotifyPropertyChanged("PositiveEnergy");
			}
		}

		public bool Silver
		{
			get { return _silver; }
			set
			{
				_silver = value;
				NotifyPropertyChanged("Silver");
			}
		}

		public bool Slashing
		{
			get { return _slashing; }
			set
			{
				_slashing = value;
				NotifyPropertyChanged("Slashing");
			}
		}

		public bool Sonic
		{
			get { return _sonic; }
			set
			{
				_sonic = value;
				NotifyPropertyChanged("Sonic");
			}
		}

		public bool Subdual
		{
			get { return _subdual; }
			set
			{
				_subdual = value;
				NotifyPropertyChanged("Subdual");
			}
		}

		public override string ToString()
		{
			List<string> damageStrings = new List<string>();

			if (Acid)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Acid));
			}
			if (Adamantine)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Adamantine));
			}
			if (Bludgeoning)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Bludgeoning));
			}
			if (Chaos)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Chaos));
			}
			if (Cold)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Cold));
			}
			if (ColdIron)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.ColdIron));
			}
			if (Divine)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Divine));
			}
			if (Electricity)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Electricity));
			}
			if (Epic)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Epic));
			}
			if (Evil)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Evil));
			}
			if (Fire)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Fire));
			}
			if (Force)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Force));
			}
			if (Good)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Good));
			}
			if (Law)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Law));
			}
			if (Magic)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Magic));
			}
			if (NegativeEnergy)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.NegativeEnergy));
			}
			if (Piercing)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Piercing));
			}
			if (PositiveEnergy)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.PositiveEnergy));
			}
			if (Silver)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Silver));
			}
			if (Slashing)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Slashing));
			}
			if (Sonic)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Sonic));
			}
			if (Subdual)
			{
				damageStrings.Add(Methods.GetDamageTypeString(Types.Damage.Subdual));
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
