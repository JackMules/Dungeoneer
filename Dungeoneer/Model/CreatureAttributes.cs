﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dungeoneer.Utility;
using System.Collections.ObjectModel;
using System.Xml;

namespace Dungeoneer.Model
{
	[Serializable]
	public class CreatureAttributes : ActorAttributes
	{
		public CreatureAttributes()
		{
			Type = Types.Creature.Humanoid;
			ChallengeRating = 1;
			AttackSets = new FullyObservableCollection<AttackSet>();
			Strength = 10;
			Dexterity = 10;
			Constitution = 10;
			Intelligence = 10;
			Wisdom = 10;
			Charisma = 10;
			BaseAttackBonus = 0;
			GrappleModifier = 0;
			HitPoints = 3;
			HitDice = 1;
			HitDieType = Types.Die.d3;
			ArmorClass = 10;
			TouchArmorClass = 10;
			FlatFootedArmorClass = 10;
			Speed = new SpeedSet(30);
			FortitudeSave = 0;
			ReflexSave = 0;
			WillSave = 0;
			Feats = new List<string>();
			Space = 5;
			Reach = 5;
			Size = Types.Size.Medium;
			DamageReductions = new ObservableCollection<DamageReduction>();
			Immunities = new DamageDescriptorSet();
			EnergyResistances = new ObservableCollection<EnergyResistance>();
			SpellResistance = 0;
			FastHealing = 0;
			SpecialAttacks = "";
			SpecialQualities = new List<string>();
		}

		public CreatureAttributes(CreatureAttributes other)
			: base(other)
		{
			Type = other._type;
			ChallengeRating = other._challengeRating;
			AttackSets = other.AttackSets.Clone();
			Strength = other.Strength;
			Dexterity = other.Dexterity;
			Constitution = other.Constitution;
			Intelligence = other.Intelligence;
			Wisdom = other.Wisdom;
			Charisma = other.Charisma;
			BaseAttackBonus = other.BaseAttackBonus;
			GrappleModifier = other.GrappleModifier;
			HitPoints = other.HitPoints;
			HitDice = other.HitDice;
			HitDieType = other.HitDieType;
			ArmorClass = other.ArmorClass;
			TouchArmorClass = other.TouchArmorClass;
			FlatFootedArmorClass = other.FlatFootedArmorClass;
			Speed = other.Speed.Clone();
			FortitudeSave = other.FortitudeSave;
			ReflexSave = other.ReflexSave;
			WillSave = other.WillSave;
			Feats = other.Feats.Clone();
			Space = other.Space;
			Reach = other.Reach;
			Size = other.Size;
			DamageReductions = other.DamageReductions.Clone();
			Immunities = other.Immunities.Clone();
			EnergyResistances = other.EnergyResistances.Clone();
			SpellResistance = other.SpellResistance;
			FastHealing = FastHealing;
			SpecialAttacks = other.SpecialAttacks;
			SpecialQualities = other.SpecialQualities;
		}

		private Types.Creature _type;
		private float _challengeRating;
		private FullyObservableCollection<AttackSet> _attackSets;

		private int _strength;
		private int _dexterity;
		private int _constitution;
		private int _intelligence;
		private int _wisdom;
		private int _charisma;

		private int _baseAttackBonus;
		private int _grappleModifier;
		private int _hitPoints;
		private int _hitDice;
		private Types.Die _hitDieType;

		private int _armorClass;
		private int _touchArmorClass;
		private int _flatFootedArmorClass;

		private SpeedSet _speed;

		private int _fortitudeSave;
		private int _reflexSave;
		private int _willSave;

		private List<string> _feats;

		private int _space;
		private int _reach;
		private int _spellResistance;
		private int _fastHealing;

		private Types.Size _size;
		private ObservableCollection<DamageReduction> _damageReductions;
		private DamageDescriptorSet _immunities;
		private ObservableCollection<EnergyResistance> _energyResistances;
		private string _specialAttacks;
		private List<string> _specialQualities;

		public Types.Creature Type
		{
			get { return _type; }
			set
			{
				_type = value;
				NotifyPropertyChanged("Type");
			}
		}

		public float ChallengeRating
		{
			get { return _challengeRating; }
			set
			{
				_challengeRating = value;
				NotifyPropertyChanged("ChallengeRating");
			}
		}

		public FullyObservableCollection<AttackSet> AttackSets
		{
			get { return _attackSets; }
			set
			{
				_attackSets = value;
				NotifyPropertyChanged("AttackSets");
			}
		}

		public int Strength
		{
			get
			{
				return _strength;
			}
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

		public int GrappleModifier
		{
			get { return _grappleModifier; }
			set
			{
				_grappleModifier = value;
				NotifyPropertyChanged("BaseGrappleModifierAttackBonus");
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

		public Types.Die HitDieType
		{
			get { return _hitDieType; }
			set
			{
				_hitDieType = value;
				NotifyPropertyChanged("HitDiceType");
			}
		}

		public int ArmorClass
		{
			get { return _armorClass; }
			set
			{
				_armorClass = value;
				NotifyPropertyChanged("ArmorClass");
			}
		}

		public int TouchArmorClass
		{
			get { return _touchArmorClass; }
			set
			{
				_touchArmorClass = value;
				NotifyPropertyChanged("TouchArmorClass");
			}
		}

		public int FlatFootedArmorClass
		{
			get { return _flatFootedArmorClass; }
			set
			{
				_flatFootedArmorClass = value;
				NotifyPropertyChanged("FlatFootedArmorClass");
			}
		}

		public SpeedSet Speed
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
			get
			{
				return Feats.Contains("Power Attack", StringComparer.CurrentCultureIgnoreCase) &&
					Strength >= 13;
			}
		}

		public bool WeaponFinesse
		{
			get
			{
				return Feats.Contains("Weapon Finesse", StringComparer.CurrentCultureIgnoreCase);
			}
		}

		public int FastHealing
		{
			get { return _fastHealing; }
			set
			{
				_fastHealing = value;
				NotifyPropertyChanged("FastHealing");
			}
		}

		public int Space
		{
			get { return _space; }
			set
			{
				_space = value;
				NotifyPropertyChanged("Space");
			}
		}

		public int Reach
		{
			get { return _reach; }
			set
			{
				_reach = value;
				NotifyPropertyChanged("Reach");
			}
		}

		public List<string> Feats
		{
			get { return _feats; }
			set
			{
				_feats = value;
				NotifyPropertyChanged("Feats");
				NotifyPropertyChanged("PowerAttack");
				NotifyPropertyChanged("WeaponFinesse");
			}
		}

		public Types.Size Size
		{
			get { return _size; }
			set
			{
				_size = value;
				NotifyPropertyChanged("Size");
			}
		}

		public ObservableCollection<DamageReduction> DamageReductions
		{
			get { return _damageReductions; }
			set
			{
				_damageReductions = value;
				NotifyPropertyChanged("DamageReductions");
			}
		}

		public ObservableCollection<EnergyResistance> EnergyResistances
		{
			get { return _energyResistances; }
			set
			{
				_energyResistances = value;
				NotifyPropertyChanged("EnergyResistances");
			}
		}

		public DamageDescriptorSet Immunities
		{
			get { return _immunities; }
			set
			{
				_immunities = value;
				NotifyPropertyChanged("Immunities");
			}
		}

		public int SpellResistance
		{
			get { return _spellResistance; }
			set
			{
				_spellResistance = value;
				NotifyPropertyChanged("SpellResistance");
			}
		}

		public string SpecialAttacks
		{
			get { return _specialAttacks; }
			set
			{
				_specialAttacks = value;
				NotifyPropertyChanged("SpecialAttacks");
			}
		}

		public List<string> SpecialQualities
		{
			get { return _specialQualities; }
			set
			{
				_specialQualities = value;
				NotifyPropertyChanged("SpecialQualities");
			}
		}

		public void ModifyAttackModifier(Types.Ability ability, int change)
		{
			foreach (AttackSet attackSet in AttackSets)
			{
				foreach (Attack attack in attackSet.Attacks)
				{
					if (attack.Ability == ability)
					{
						attack.Modifier += change;
					}
				}
			}
			NotifyPropertyChanged("AttackSets");
		}

		public void ModifyDamageModifier(int change)
		{
			foreach (AttackSet attackSet in AttackSets)
			{
				foreach (Attack attack in attackSet.Attacks)
				{
					if (attack.Damages.Count > 0)
					{
						attack.Damages[0].Modifier += change;
					}
				}
			}
			NotifyPropertyChanged("AttackSets");
		}

		public void ModifyArmorClass(int change)
		{
			ArmorClass += change;
			FlatFootedArmorClass += change;
			TouchArmorClass += change;
		}

		public void ModifySpeed(double factor)
		{
			double distance = Speed.LandSpeed;
			distance *= factor;
			Speed.LandSpeed = (int)distance;

			foreach (Speed speed in Speed.Speeds)
			{
				distance = speed.Distance;
				distance *= factor;
				speed.Distance = (int)distance;
			}
		}

		public bool UncannyDodge
		{
			get { return SpecialQualities.Contains("Uncanny Dodge", StringComparer.CurrentCultureIgnoreCase); }
		}

		public bool ImprovedUncannyDodge
		{
			get { return SpecialQualities.Contains("Improved Uncanny Dodge", StringComparer.CurrentCultureIgnoreCase); }
		}

		public void SetFlatFooted()
		{
			if (!UncannyDodge)
			{
				ArmorClass = FlatFootedArmorClass;
				TouchArmorClass -= Methods.GetAbilityModifier(Dexterity);
			}
		}

		public void ModifyFortitudeSave(int change)
		{
			FortitudeSave += change;
		}

		public void ModifyReflexSave(int change)
		{
			ReflexSave += change;
		}

		public void ModifyWillSave(int change)
		{
			WillSave += change;
		}

		public void ModifySaves(int change)
		{
			ModifyFortitudeSave(change);
			ModifyReflexSave(change);
			ModifyWillSave(change);
		}

		public void ModifyAbilityScore(Types.Ability ability, int change)
		{
			int oldModifier = GetAbilityModifier(ability);
			SetAbilityScore(ability, GetAbilityScore(ability) + change);
			int newModifier = GetAbilityModifier(ability);

			int modifierDifference = newModifier - oldModifier;

			if (ability == Types.Ability.Strength ||
				ability == Types.Ability.Dexterity)
			{
				ModifyAttackModifier(ability, modifierDifference);

				if (ability == Types.Ability.Strength)
				{
					ModifyDamageModifier(modifierDifference);
				}
				else if (ability == Types.Ability.Dexterity)
				{
					ReflexSave += modifierDifference;
				}
			}
			else if (ability == Types.Ability.Constitution)
			{
				if (Type != Types.Creature.Undead)
				{
					HitPoints += HitDice * modifierDifference;
					FortitudeSave += modifierDifference;
				}
			}
			else
			{
				// Modify spell DCs

				if (ability == Types.Ability.Wisdom)
				{
					WillSave += modifierDifference;
				}
			}
		}

		public int GetAbilityScore(Types.Ability ability)
		{
			switch (ability)
			{
			case Types.Ability.Strength:
				return Strength;
			case Types.Ability.Dexterity:
				return Dexterity;
			case Types.Ability.Constitution:
				return Constitution;
			case Types.Ability.Intelligence:
				return Intelligence;
			case Types.Ability.Wisdom:
				return Wisdom;
			case Types.Ability.Charisma:
				return Charisma;
			}
			return 0;
		}

		public int GetAbilityModifier(Types.Ability ability)
		{
			return Methods.GetAbilityModifier(GetAbilityScore(ability));
		}

		public void SetAbilityScore(Types.Ability ability, int score)
		{
			switch (ability)
			{
			case Types.Ability.Strength:
				Strength = score;
				break;
			case Types.Ability.Dexterity:
				Dexterity = score;
				break;
			case Types.Ability.Constitution:
				Constitution = score;
				break;
			case Types.Ability.Intelligence:
				Intelligence = score;
				break;
			case Types.Ability.Wisdom:
				Wisdom = score;
				break;
			case Types.Ability.Charisma:
				Charisma = score;
				break;
			}
		}

		public int CalculateHitPointChange(List<DamageSet> damageSets)
		{
			int hpChange = 0;

			List<DamageSet> damageDone = new List<DamageSet>();

			foreach (DamageSet damageSet in damageSets)
			{
				damageDone.Add(new DamageSet(damageSet));
			}

			List<DamageReduction> damageReductions = DamageReductions.ToList();
			damageReductions.Sort((dr1, dr2) => dr2.Value.CompareTo(dr1.Value));

			List<EnergyResistance> energyResistances = EnergyResistances.ToList();

			foreach (DamageSet damageSet in damageDone)
			{
				foreach (EnergyResistance energyResistance in energyResistances)
				{
					if (damageSet.DamageDescriptorSet.IsEnergyDamage() &&
							damageSet.DamageDescriptorSet.Contains(energyResistance.EnergyType))
					{
						int numEnergyTypes = damageSet.DamageDescriptorSet.Count;
						int thisEnergyDamage = damageSet.Amount / numEnergyTypes;
						int thisEnergyDamageAfterResistance = thisEnergyDamage - energyResistance.Value;
						if (thisEnergyDamageAfterResistance < 0)
						{
							thisEnergyDamageAfterResistance = 0;
						}

						int difference = thisEnergyDamage - thisEnergyDamageAfterResistance;
						damageSet.Amount -= difference;

						if (damageSet.Amount < 0)
						{
							damageSet.Amount = 0;
						}
					}
				}
			}

			foreach (DamageSet damageSet in damageDone)
			{
				if (damageSet.DamageDescriptorSet.IsTyped())
				{
					foreach (Types.Damage damageType in damageSet.DamageDescriptorSet.ToList())
					{
						if (Immunities.Contains(damageType))
						{
							damageSet.Amount = 0;
						}
					}

					foreach (DamageReduction dr in damageReductions)
					{
						if (!dr.IsBypassedBy(damageSet.DamageDescriptorSet))
						{
							damageSet.Amount -= dr.Value;
							break;
						}
					}

					if (damageSet.Amount < 0)
					{
						damageSet.Amount = 0;
					}
				}
			}
			
			foreach (DamageSet damageSet in damageDone)
			{
				hpChange -= damageSet.Amount;
			}

			return hpChange;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("CreatureAttributes");
		}

		public override void WritePropertyXML(XmlWriter xmlWriter)
		{
			base.WritePropertyXML(xmlWriter);

			xmlWriter.WriteStartElement("Type");
			xmlWriter.WriteString(Methods.GetCreatureTypeString(Type));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("ChallengeRating");
			xmlWriter.WriteString(ChallengeRating.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("AttackSets");
			foreach (AttackSet attackSet in AttackSets)
			{
				attackSet.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();

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

			xmlWriter.WriteStartElement("GrappleModifier");
			xmlWriter.WriteString(GrappleModifier.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("HitPoints");
			xmlWriter.WriteString(HitPoints.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("HitDice");
			xmlWriter.WriteString(HitDice.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("HitDieType");
			xmlWriter.WriteString(Methods.GetDieTypeString(HitDieType));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("ArmorClass");
			xmlWriter.WriteString(ArmorClass.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("TouchArmorClass");
			xmlWriter.WriteString(TouchArmorClass.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("FlatFootedArmorClass");
			xmlWriter.WriteString(FlatFootedArmorClass.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Speed");
			Speed.WriteXML(xmlWriter);
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

			xmlWriter.WriteStartElement("Feats");
			foreach (string feat in Feats)
			{
				xmlWriter.WriteStartElement("Feat");
				xmlWriter.WriteString(feat);
				xmlWriter.WriteEndElement();
			}
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Space");
			xmlWriter.WriteString(Space.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Reach");
			xmlWriter.WriteString(Reach.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Size");
			xmlWriter.WriteString(Methods.GetSizeString(Size));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("DamageReductions");
			foreach (DamageReduction dr in DamageReductions)
			{
				dr.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Immunities");
			Immunities.WriteXML(xmlWriter);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("EnergyResistances");
			foreach (EnergyResistance er in EnergyResistances)
			{
				er.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("SpellResistance");
			xmlWriter.WriteString(SpellResistance.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("FastHealing");
			xmlWriter.WriteString(FastHealing.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("SpecialAttacks");
			xmlWriter.WriteString(SpecialAttacks);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("SpecialQualities");
			xmlWriter.WriteString(String.Join(", ", SpecialQualities));
			xmlWriter.WriteEndElement();
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			base.ReadXML(xmlNode);

			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Type")
					{
						try
						{
							Type = Methods.GetCreatureTypeFromString(childNode.InnerText);
						}
						catch (FormatException)
						{
							Type = Types.Creature.Humanoid;
						}
					}
					else if (childNode.Name == "ChallengeRating")
					{
						ChallengeRating = Convert.ToSingle(childNode.InnerText);
					}
					else if (childNode.Name == "AttackSets")
					{
						AttackSets.Clear();
						foreach (XmlNode attackSetNode in childNode.ChildNodes)
						{
							if (attackSetNode.Name == "AttackSet")
							{
								AttackSets.Add(new AttackSet(attackSetNode));
							}
						}
					}
					else if (childNode.Name == "Strength")
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
					else if (childNode.Name == "GrappleModifier")
					{
						GrappleModifier = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "HitPoints")
					{
						HitPoints = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "HitDice")
					{
						HitDice = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "HitDieType")
					{
						HitDieType = Methods.GetDieTypeFromString(childNode.InnerText);
					}
					else if (childNode.Name == "ArmorClass")
					{
						ArmorClass = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "TouchArmorClass")
					{
						TouchArmorClass = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "FlatFootedArmorClass")
					{
						FlatFootedArmorClass = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Speed")
					{
						Speed.ReadXML(childNode);
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
					else if (childNode.Name == "Feats")
					{
						foreach (XmlNode featNode in childNode.ChildNodes)
						{
							if (featNode.Name == "Feat")
							{
								Feats.Add(featNode.InnerText);
							}
						}
					}
					else if (childNode.Name == "Space")
					{
						Space = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Reach")
					{
						Reach = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Size")
					{
						Size = Methods.GetSizeFromString(childNode.InnerText);
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
					else if (childNode.Name == "Immunities")
					{
						Immunities.ReadXML(childNode);
					}
					else if (childNode.Name == "EnergyResistances")
					{
						foreach (XmlNode erNode in childNode.ChildNodes)
						{
							if (erNode.Name == "EnergyResistance")
							{
								EnergyResistance er = new EnergyResistance();
								er.ReadXML(erNode);
								EnergyResistances.Add(er);
							}
						}
					}
					else if (childNode.Name == "SpellResistance")
					{
						SpellResistance = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "FastHealing")
					{
						FastHealing = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "SpecialAttacks")
					{
						SpecialAttacks = childNode.InnerText;
					}
					else if (childNode.Name == "SpecialQualities")
					{
						foreach (string specialQuality in childNode.InnerText.Split(','))
						{
							SpecialQualities.Add(specialQuality.Trim());
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
