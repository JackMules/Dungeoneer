using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Dungeoneer.Utility;
using System.Collections.ObjectModel;

namespace Dungeoneer.Model
{
	[Serializable]
	public class Creature : Actor
	{
		public Creature(Creature other)
			: base(other)
		{
			BaseAttributes = other.BaseAttributes.Clone();
			ModifiedAttributes = BaseAttributes.Clone();
			_usedAttacksOfOpportunity = 0;
		}

		public Creature(CreatureAttributes attributes)
			: base(attributes)
		{
			BaseAttributes = attributes.Clone();
			ModifiedAttributes = attributes.Clone();
			_usedAttacksOfOpportunity = 0;
		}

		public Creature(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
		}

		private CreatureAttributes _baseCreatureAttributes = new CreatureAttributes();
		private CreatureAttributes _modifiedAttributes = new CreatureAttributes();
		private FullyObservableCollection<IHitPointChange> _hitPointChanges = new FullyObservableCollection<IHitPointChange>();
		private int _usedAttacksOfOpportunity;

		public override void StartEncounter()
		{
			base.StartEncounter();

			Effect.TimedEffect flatFooted = new Effect.TimedEffect(Types.Effect.FlatFooted, 1);
			Effects.Add(flatFooted);

			if (BaseAttributes.FastHealing > 0)
			{
				Effect.ValueEffect fastHealing = new Effect.ValueEffect(Types.Effect.FastHealing,
					BaseAttributes.FastHealing);
				Effects.Add(fastHealing);
			}
		}

		protected new CreatureAttributes BaseAttributes
		{
			get { return _baseCreatureAttributes; }
			set
			{
				_baseCreatureAttributes = value;
				NotifyPropertyChanged("BaseAttributes");
			}
		}

		protected new CreatureAttributes ModifiedAttributes
		{
			get { return _modifiedAttributes; }
			set
			{
				_modifiedAttributes = value;
				NotifyPropertyChanged("ModifiedAttributes");
			}
		}

		public FullyObservableCollection<IHitPointChange> HitPointChanges
		{
			get { return _hitPointChanges; }
			set
			{
				_hitPointChanges = value;
				NotifyPropertyChanged("HitPointChanges");
			}
		}

		public new CreatureAttributes GetEffectiveAttributes()
		{
			CreatureAttributes effectiveAttributes = ModifiedAttributes.Clone();
			foreach (Effect.Effect effect in Effects)
			{
				if (!effect.PerTurn)
				{
					effect.ApplyTo(effectiveAttributes, BaseAttributes);
				}
			}
			return effectiveAttributes;
		}

		public void AddHitPointChange(IHitPointChange hitPointChange)
		{
			HitPointChanges.Add(hitPointChange);

			if (hitPointChange is Hit)
			{
				if (hitPointChange.GetHitPointChange() != 0)
				{
					Hit hit = hitPointChange as Hit;
					if (hit.Weapon.AbilityDamage)
					{
						Effects.Add(new Effect.AbilityValueEffect(Types.Effect.AbilityModifier, 
							hit.Weapon.Ability, -hit.Weapon.AbilityDamageValue));
					}
				}
			}
		}

		public int GetCurrentHitPoints()
		{
			int maxHP = GetEffectiveAttributes().HitPoints;
			int hp = maxHP;

			foreach (IHitPointChange hitPointChange in HitPointChanges)
			{
				hp += hitPointChange.GetHitPointChange();

				if (hp > maxHP)
				{
					hp = maxHP;
				}
			}

			return hp;
		}

		public override void ApplyPerTurnEffects()
		{
			foreach (Effect.Effect effect in Effects)
			{
				if (effect.PerTurn)
				{
					effect.ApplyTo(ModifiedAttributes, BaseAttributes);
				}
				if (effect is Effect.ValueEffect)
				{
					Effect.ValueEffect valueEffect = (effect as Effect.ValueEffect);
					if (valueEffect.EffectType == Types.Effect.FastHealing)
					{
						int currentHP = GetCurrentHitPoints();
						int maxHP = GetEffectiveAttributes().HitPoints;

						if (currentHP < maxHP)
						{
							int damage = maxHP - currentHP;
							if (damage < valueEffect.Value)
							{
								AddHitPointChange(new Heal(damage));
							}
							else
							{
								AddHitPointChange(new Heal(valueEffect.Value));
							}
						}
					}
				}
			}
		}

		public override int InitiativeMod
		{
			get { return GetEffectiveAttributes().InitiativeMod; }
			set
			{
				ModifiedAttributes.InitiativeMod = value;
				NotifyPropertyChanged("InitiativeMod");
			}
		}

		public override bool Active
		{
			get { return GetEffectiveAttributes().Active; }
			set
			{
				ModifiedAttributes.Active = value;
				NotifyPropertyChanged("Active");
			}
		}

		public Types.Creature Type
		{
			get { return GetEffectiveAttributes().Type; }
			set
			{
				ModifiedAttributes.Type = value;
				NotifyPropertyChanged("Type");
			}
		}

		public float ChallengeRating
		{
			get { return GetEffectiveAttributes().ChallengeRating; }
			set
			{
				ModifiedAttributes.ChallengeRating = value;
				NotifyPropertyChanged("ChallengeRating");
			}
		}

		public FullyObservableCollection<AttackSet> AttackSets
		{
			get { return GetEffectiveAttributes().AttackSets; }
			set
			{
				ModifiedAttributes.AttackSets = value;
				NotifyPropertyChanged("AttackSets");
			}
		}

		public int Strength
		{
			get
			{
				return GetEffectiveAttributes().Strength;
			}
			set
			{
				ModifiedAttributes.Strength = value;
				NotifyPropertyChanged("Strength");
			}
		}

		public int Dexterity
		{
			get { return GetEffectiveAttributes().Dexterity; }
			set
			{
				ModifiedAttributes.Dexterity = value;
				NotifyPropertyChanged("Dexterity");
			}
		}

		public int Constitution
		{
			get { return GetEffectiveAttributes().Constitution; }
			set
			{
				ModifiedAttributes.Constitution = value;
				NotifyPropertyChanged("Constitution");
			}
		}

		public int Intelligence
		{
			get { return GetEffectiveAttributes().Intelligence; }
			set
			{
				ModifiedAttributes.Intelligence = value;
				NotifyPropertyChanged("Intelligence");
			}
		}

		public int Wisdom
		{
			get { return GetEffectiveAttributes().Wisdom; }
			set
			{
				ModifiedAttributes.Wisdom = value;
				NotifyPropertyChanged("Wisdom");
			}
		}

		public int Charisma
		{
			get { return GetEffectiveAttributes().Charisma; }
			set
			{
				ModifiedAttributes.Charisma = value;
				NotifyPropertyChanged("Charisma");
			}
		}

		public int BaseAttackBonus
		{
			get { return GetEffectiveAttributes().BaseAttackBonus; }
			set
			{
				ModifiedAttributes.BaseAttackBonus = value;
				NotifyPropertyChanged("BaseAttackBonus");
			}
		}

		public int GrappleModifier
		{
			get { return GetEffectiveAttributes().GrappleModifier; }
			set
			{
				ModifiedAttributes.GrappleModifier = value;
				NotifyPropertyChanged("BaseGrappleModifierAttackBonus");
			}
		}

		public int HitPoints
		{
			get { return GetCurrentHitPoints(); }
			set
			{
				ModifiedAttributes.HitPoints = value;
				NotifyPropertyChanged("HitPoints");
			}
		}

		public int HitDice
		{
			get { return GetEffectiveAttributes().HitDice; }
			set
			{
				ModifiedAttributes.HitDice = value;
				NotifyPropertyChanged("HitDice");
			}
		}

		public Types.Die HitDieType
		{
			get { return GetEffectiveAttributes().HitDieType; }
			set
			{
				ModifiedAttributes.HitDieType = value;
				NotifyPropertyChanged("HitDiceType");
			}
		}

		public int ArmorClass
		{
			get { return GetEffectiveAttributes().ArmorClass; }
			set
			{
				ModifiedAttributes.ArmorClass = value;
				NotifyPropertyChanged("ArmorClass");
			}
		}

		public int TouchArmorClass
		{
			get { return GetEffectiveAttributes().TouchArmorClass; }
			set
			{
				ModifiedAttributes.TouchArmorClass = value;
				NotifyPropertyChanged("TouchArmorClass");
			}
		}

		public int FlatFootedArmorClass
		{
			get { return GetEffectiveAttributes().FlatFootedArmorClass; }
			set
			{
				ModifiedAttributes.FlatFootedArmorClass = value;
				NotifyPropertyChanged("FlatFootedArmorClass");
			}
		}

		public SpeedSet Speed
		{
			get { return GetEffectiveAttributes().Speed; }
			set
			{
				ModifiedAttributes.Speed = value;
				NotifyPropertyChanged("Speed");
			}
		}

		public int FortitudeSave
		{
			get { return GetEffectiveAttributes().FortitudeSave; }
			set
			{
				ModifiedAttributes.FortitudeSave = value;
				NotifyPropertyChanged("FortitudeSave");
			}
		}

		public int ReflexSave
		{
			get { return GetEffectiveAttributes().ReflexSave; }
			set
			{
				ModifiedAttributes.ReflexSave = value;
				NotifyPropertyChanged("ReflexSave");
			}
		}

		public int WillSave
		{
			get { return GetEffectiveAttributes().WillSave; }
			set
			{
				ModifiedAttributes.WillSave = value;
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

		public bool CombatReflexes
		{
			get
			{
				return Feats.Contains("Combat Reflexes", StringComparer.CurrentCultureIgnoreCase);
			}
		}

		public int Space
		{
			get { return GetEffectiveAttributes().Space; }
			set
			{
				ModifiedAttributes.Space = value;
				NotifyPropertyChanged("Space");
			}
		}

		public int Reach
		{
			get { return GetEffectiveAttributes().Reach; }
			set
			{
				ModifiedAttributes.Reach = value;
				NotifyPropertyChanged("Reach");
			}
		}

		public List<string> Feats
		{
			get { return GetEffectiveAttributes().Feats; }
			set
			{
				ModifiedAttributes.Feats = value;
				NotifyPropertyChanged("Feats");
				NotifyPropertyChanged("PowerAttack");
				NotifyPropertyChanged("CombatReflexes");
			}
		}

		public Types.Size Size
		{
			get { return GetEffectiveAttributes().Size; }
			set
			{
				ModifiedAttributes.Size = value;
				NotifyPropertyChanged("Size");
			}
		}

		public ObservableCollection<DamageReduction> DamageReductions
		{
			get { return GetEffectiveAttributes().DamageReductions; }
			set
			{
				ModifiedAttributes.DamageReductions = value;
				NotifyPropertyChanged("DamageReductions");
			}
		}

		public DamageDescriptorSet Immunities
		{
			get { return GetEffectiveAttributes().Immunities; }
			set
			{
				ModifiedAttributes.Immunities = value;
				NotifyPropertyChanged("Immunities");
			}
		}

		public DamageDescriptorSet Vulnerabilities
		{
			get { return GetEffectiveAttributes().Vulnerabilities; }
			set
			{
				ModifiedAttributes.Vulnerabilities = value;
				NotifyPropertyChanged("Vulnerabilities");
			}
		}

		public ObservableCollection<EnergyResistance> EnergyResistances
		{
			get { return GetEffectiveAttributes().EnergyResistances; }
			set
			{
				ModifiedAttributes.EnergyResistances = value;
				NotifyPropertyChanged("EnergyResistances");
			}
		}

		public int SpellResistance
		{
			get { return GetEffectiveAttributes().SpellResistance; }
			set
			{
				ModifiedAttributes.SpellResistance = value;
				NotifyPropertyChanged("SpellResistance");
			}
		}

		public int FastHealing
		{
			get { return GetEffectiveAttributes().FastHealing; }
			set
			{
				ModifiedAttributes.FastHealing = value;
				NotifyPropertyChanged("FastHealing");
			}
		}

		public string SpecialAttacks
		{
			get { return BaseAttributes.SpecialAttacks; }
		}

		public List<string> SpecialQualities
		{
			get { return BaseAttributes.SpecialQualities; }
		}

		public bool Threatening
		{
			get
			{
				return !Grappling && !FlatFooted;
			}
		}

		public void IncrementAttacksOfOpportunity()
		{
			if (_usedAttacksOfOpportunity > 0)
			{
				--_usedAttacksOfOpportunity;
				NotifyPropertyChanged("AttacksOfOpportunity");
			}
		}

		public void DecrementAttacksOfOpportunity()
		{
			if (_usedAttacksOfOpportunity < CalculateAttacksOfOpportunity())
			{
				++_usedAttacksOfOpportunity;
				NotifyPropertyChanged("AttacksOfOpportunity");
			}
		}

		public bool Grappling
		{
			get
			{
				foreach (Effect.Effect effect in Effects)
				{
					if (effect.EffectType == Types.Effect.Grappling)
					{
						return true;
					}
				}

				return false;
			}
        }

		public bool FlatFooted
		{
			get
			{
				foreach (Effect.Effect effect in Effects)
				{
					if (effect.EffectType == Types.Effect.FlatFooted)
					{
						return true;
					}
				}

				return false;
			}
		}

		public bool UncannyDodge
		{
			get { return GetEffectiveAttributes().UncannyDodge; }
		}

		public bool ImprovedUncannyDodge
		{
			get { return GetEffectiveAttributes().ImprovedUncannyDodge; }
		}

		private int CalculateAttacksOfOpportunity()
		{
			int aoo = 0;
			if (!Threatening)
            {
				return aoo;
            }
			if (CombatReflexes)
			{
				int dexMod = Methods.GetAbilityModifier(GetEffectiveAttributes().Dexterity);
				aoo = dexMod;
			}
			else
			{
				aoo = 1;
			}

			return aoo;
		}

		public int AttacksOfOpportunity
		{
			get
			{
				int aoo = CalculateAttacksOfOpportunity() - _usedAttacksOfOpportunity;

				if (aoo < 0)
				{
					aoo = 0;
				}

				return aoo;
			}
		}

		public void ModifyAbilityScore(Types.Ability ability, int change)
		{
			ModifiedAttributes.ModifyAbilityScore(ability, change);
			NotifyPropertyChanged(Methods.GetAbilityString(ability));
		}

		public void Heal(int healing)
		{
			ModifiedAttributes.HitPoints += healing;
			if (ModifiedAttributes.HitPoints > BaseAttributes.HitPoints)
			{
				ModifiedAttributes.HitPoints = BaseAttributes.HitPoints;
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Creature");
		}

		public override void WritePropertyXML(XmlWriter xmlWriter)
		{
			base.WritePropertyXML(xmlWriter);

			xmlWriter.WriteStartElement("HitPointChanges");
			foreach (IHitPointChange hpChange in HitPointChanges)
			{
				hpChange.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();
		}

		public override void WriteAttributesXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("BaseAttributes");
			BaseAttributes.WriteXML(xmlWriter);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("ModifiedAttributes");
			ModifiedAttributes.WriteXML(xmlWriter);
			xmlWriter.WriteEndElement();
		}

		public override void ReadPropertyXML(XmlNode xmlNode)
		{
			base.ReadPropertyXML(xmlNode);

			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "HitPointChanges")
					{
						foreach (XmlNode childChildNode in childNode.ChildNodes)
						{
							if (childChildNode.Name == "Hit")
							{
								var hit = new Hit(childChildNode);
								HitPointChanges.Add(hit);
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

		public override void ReadAttributesXML(XmlNode xmlNode)
		{
			bool readBase = false;
			bool readModified = false;
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "BaseAttributes")
					{
						BaseAttributes.ReadXML(childNode.ChildNodes[0]);
						readBase = true;
					}
					else if (childNode.Name == "ModifiedAttributes")
					{
						ModifiedAttributes.ReadXML(childNode.ChildNodes[0]);
						readModified = true;
					}
				}
			}
			catch (XmlException e)
			{
				MessageBox.Show(e.ToString());
			}

			if (readBase && !readModified)
			{
				ModifiedAttributes = new CreatureAttributes(BaseAttributes);
			}
		}
	}
}
