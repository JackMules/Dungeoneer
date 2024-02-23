using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;
using System.Xml;

namespace Dungeoneer.Model
{
	[Serializable]
	public class DamageDescriptorSet : BaseModel
	{
		public DamageDescriptorSet()
		{
			_descriptors = new HashSet<Types.Damage>();
		}

		public DamageDescriptorSet(DamageDescriptorSet other)
		{
			_descriptors = new HashSet<Types.Damage>(other._descriptors);
		}

		public DamageDescriptorSet(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
		}

		private HashSet<Types.Damage> _descriptors;

		public void Add(Types.Damage damageType)
		{
			SetDamageType(damageType, true);
		}

		public bool Contains(Types.Damage damageType)
		{
			return _descriptors.Contains(damageType);
		}

		public bool IsEnergyDamage()
		{
			foreach (Types.Damage damage in _descriptors)
			{
				if (!Methods.IsEnergyDamageType(damage))
				{
					return false;
				}
			}
			return true;
		}

		public bool IsTyped()
		{
			if (Count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public List<Types.Damage> ToList()
		{
			return new List<Types.Damage>(_descriptors);
		}

		public int Count
		{
			get { return _descriptors.Count; }
		}

		private void SetDamageType(Types.Damage damageType, bool setPresent)
		{
			if (setPresent)
			{
				_descriptors.Add(damageType);
			}
			else
			{
				_descriptors.Remove(damageType);
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

			return string.Join(" and ", damageStrings);
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(typeof(DamageDescriptorSet).Name);
			foreach (Types.Damage damageType in _descriptors)
			{
				damageType.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			_descriptors = new HashSet<Types.Damage>();

			foreach (XmlNode childNode in xmlNode.ChildNodes)
			{
				_descriptors.Add(Methods.GetDamageTypeFromString(childNode.InnerText));
			}
		}
	}
}
