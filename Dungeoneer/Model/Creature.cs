using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Dungeoneer.Model
{
	public class Creature : NonPlayerActor
	{
		private int _strength;
		private int _dexterity;
		private int _constitution;
		private int _intelligence;
		private int _wisdom;
		private int _charisma;

		private int _baseAttackBonus;
		private int _hitPoints;
		private int _hitDice;
		private Utility.Types.DieType _hitDiceType;

		private int _armourClass;
		private int _touchArmourClass;
		private int _flatFootedArmourClass;

		private int _speed;

		private int _fortitudeSave;
		private int _reflexSave;
		private int _willSave;

		private bool _powerAttack;

		private Utility.Types.Size _size;
		private Utility.FullyObservableCollection<DamageReduction> _damageReductions;

		public int Strength
		{
			get { return _strength; }
			set
			{
				_strength = value;
				NotifyPropertyChanged("Strength");
			}
		}

		public int Dexterity
		{
			get { return _dexterity; }
			set
			{
				_dexterity = value;
				NotifyPropertyChanged("Dexterity");
			}
		}

		public int Constitution
		{
			get { return _constitution; }
			set
			{
				_constitution = value;
				NotifyPropertyChanged("Constitution");
			}
		}

		public int Intelligence
		{
			get { return _intelligence; }
			set
			{
				_intelligence = value;
				NotifyPropertyChanged("Intelligence");
			}
		}

		public int Wisdom
		{
			get { return _wisdom; }
			set
			{
				_wisdom = value;
				NotifyPropertyChanged("Wisdom");
			}
		}

		public int Charisma
		{
			get { return _charisma; }
			set
			{
				_charisma = value;
				NotifyPropertyChanged("Charisma");
			}
		}

		public int BaseAttackBonus
		{
			get { return _baseAttackBonus; }
			set
			{
				_baseAttackBonus = value;
				NotifyPropertyChanged("BaseAttackBonus");
			}
		}

		public int HitPoints
		{
			get { return _hitPoints; }
			set
			{
				_hitPoints = value;
				NotifyPropertyChanged("HitPoints");
			}
		}

		public int HitDice
		{
			get { return _hitDice; }
			set
			{
				_hitDice = value;
				NotifyPropertyChanged("HitDice");
			}
		}

		public Utility.Types.DieType HitDiceType
		{
			get { return _hitDiceType; }
			set
			{
				_hitDiceType = value;
				NotifyPropertyChanged("HitDiceType");
			}
		}

		public int ArmourClass
		{
			get { return _armourClass; }
			set
			{
				_armourClass = value;
				NotifyPropertyChanged("ArmourClass");
			}
		}

		public int TouchArmourClass
		{
			get { return _touchArmourClass; }
			set
			{
				_touchArmourClass = value;
				NotifyPropertyChanged("TouchArmourClass");
			}
		}

		public int FlatFootedArmourClass
		{
			get { return _flatFootedArmourClass; }
			set
			{
				_flatFootedArmourClass = value;
				NotifyPropertyChanged("FlatFootedArmourClass");
			}
		}

		public int Speed
		{
			get { return _speed; }
			set
			{
				_speed = value;
				NotifyPropertyChanged("Speed");
			}
		}

		public int FortitudeSave
		{
			get { return _fortitudeSave; }
			set
			{
				_fortitudeSave = value;
				NotifyPropertyChanged("FortitudeSave");
			}
		}

		public int ReflexSave
		{
			get { return _reflexSave; }
			set
			{
				_reflexSave = value;
				NotifyPropertyChanged("ReflexSave");
			}
		}

		public int WillSave
		{
			get { return _willSave; }
			set
			{
				_willSave = value;
				NotifyPropertyChanged("WillSave");
			}
		}

		public bool PowerAttack
		{
			get { return _powerAttack; }
			set
			{
				_powerAttack = value;
				NotifyPropertyChanged("PowerAttack");
			}
		}

		public Utility.Types.Size Size
		{
			get { return _size; }
			set
			{
				_size = value;
				NotifyPropertyChanged("Size");
			}
		}
		
		public Utility.FullyObservableCollection<DamageReduction> DamageReductions
		{
			get { return _damageReductions; }
			set
			{
				_damageReductions = value;
				NotifyPropertyChanged("DamageReductions");
			}
		}

		public Creature()
			: base()
		{
			Strength = 10;
			Dexterity = 10;
			Constitution = 10;
			Intelligence = 10;
			Wisdom = 10;
			Charisma = 10;
			BaseAttackBonus = 0;
			HitPoints = 3;
			HitDice = 1;
			HitDiceType = Utility.Types.DieType.d3;
			ArmourClass = 10;
			TouchArmourClass = 10;
			FlatFootedArmourClass = 10;
			Speed = 30;
			FortitudeSave = 0;
			ReflexSave = 0;
			WillSave = 0;
			PowerAttack = false;
			Size = Utility.Types.Size.Medium;
			DamageReductions = new Utility.FullyObservableCollection<DamageReduction>();
		}

		public Creature(
			string displayName,
			string actorName, 
			string type, 
			int initiativeMod,
			float challengeRating,
			Utility.FullyObservableCollection<ViewModel.AttackViewModel> attacks,
			int strength,
			int dexterity,
			int constitution,
			int intelligence,
			int wisdom,
			int charisma,
			int baseAttackBonus,
			int hitPoints,
			int hitDice,
			Utility.Types.DieType hitDiceType,
			int armourClass,
			int touchArmourClass,
			int flatFootedArmourClass,
			int damageReduction,
			string damageReductionType,
			int speed,
			int fortitudeSave,
			int reflexSave,
			int willSave,
			bool powerAttack,
			Utility.Types.Size size,
			Utility.FullyObservableCollection<DamageReduction> damageReductions,
			Utility.FullyObservableCollection<Condition> conditions)
			: base(displayName, actorName, type, 
					initiativeMod, challengeRating, attacks, conditions)
		{
			Strength = strength;
			Dexterity = dexterity;
			Constitution = constitution;
			Intelligence = intelligence;
			Wisdom = wisdom;
			Charisma = charisma;
			BaseAttackBonus = baseAttackBonus;
			HitPoints = hitPoints; 
			HitDice = hitDice; 
			HitDiceType = hitDiceType; 
			ArmourClass = armourClass; 
			TouchArmourClass = touchArmourClass; 
			FlatFootedArmourClass = flatFootedArmourClass; 
			Speed = speed; 
			FortitudeSave = fortitudeSave; 
			ReflexSave = reflexSave; 
			WillSave = willSave;
			PowerAttack = powerAttack;
			Size = size;
			DamageReductions = damageReductions;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Creature");
		}

		public override void WritePropertyXML(XmlWriter xmlWriter)
		{
			base.WritePropertyXML(xmlWriter);

			xmlWriter.WriteStartElement("Strength");
			xmlWriter.WriteString(Strength.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Dexterity");
			xmlWriter.WriteString(Dexterity.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Constitution");
			xmlWriter.WriteString(Constitution.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Intelligence");
			xmlWriter.WriteString(Intelligence.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Wisdom");
			xmlWriter.WriteString(Wisdom.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Charisma");
			xmlWriter.WriteString(Charisma.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("BaseAttackBonus");
			xmlWriter.WriteString(BaseAttackBonus.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("HitPoints");
			xmlWriter.WriteString(HitPoints.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("HitDice");
			xmlWriter.WriteString(HitDice.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("HitDiceType");
			xmlWriter.WriteString(Utility.Methods.GetDieTypeString(HitDiceType));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("ArmourClass");
			xmlWriter.WriteString(ArmourClass.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("TouchArmourClass");
			xmlWriter.WriteString(TouchArmourClass.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("FlatFootedArmourClass");
			xmlWriter.WriteString(FlatFootedArmourClass.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Speed");
			xmlWriter.WriteString(Speed.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("FortitudeSave");
			xmlWriter.WriteString(FortitudeSave.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("ReflexSave");
			xmlWriter.WriteString(ReflexSave.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("WillSave");
			xmlWriter.WriteString(WillSave.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("PowerAttack");
			xmlWriter.WriteString(PowerAttack.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Size");
			xmlWriter.WriteString(Utility.Methods.GetSizeString(Size));
			xmlWriter.WriteEndElement();
			
			xmlWriter.WriteStartElement("DamageReductions");
			foreach (DamageReduction dr in DamageReductions)
			{
				dr.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			base.ReadXML(xmlNode);

			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Strength")
					{
						Strength = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Dexterity")
					{
						Dexterity = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Constitution")
					{
						Constitution = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Intelligence")
					{
						Intelligence = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Wisdom")
					{
						Wisdom = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Charisma")
					{
						Charisma = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "BaseAttackBonus")
					{
						BaseAttackBonus = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "HitPoints")
					{
						HitPoints = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "HitDice")
					{
						HitDice = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "HitDiceType")
					{
						HitDiceType = Utility.Methods.GetDieTypeFromString(childNode.InnerText);
					}
					else if (childNode.Name == "ArmourClass")
					{
						ArmourClass = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "TouchArmourClass")
					{
						TouchArmourClass = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "FlatFootedArmourClass")
					{
						FlatFootedArmourClass = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Speed")
					{
						Speed = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "FortitudeSave")
					{
						FortitudeSave = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "ReflexSave")
					{
						ReflexSave = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "WillSave")
					{
						WillSave = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "PowerAttack")
					{
						PowerAttack = Convert.ToBoolean(childNode.InnerText);
					}
					else if (childNode.Name == "Size")
					{
						Size = Utility.Methods.GetSizeFromString(childNode.InnerText);
					}
					else if (childNode.Name == "DamageReductions")
					{
						foreach (XmlNode drNode in childNode.ChildNodes)
						{
							if (drNode.Name == "DamageReduction")
							{
								DamageReduction dr = new DamageReduction();
								dr.ReadXML(drNode);
								DamageReductions.Add(dr);
							}
						}
					}
				}
			}
			catch (System.Xml.XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}
	}
}
