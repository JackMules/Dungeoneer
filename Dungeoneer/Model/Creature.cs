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
			BaseAttributes = new CreatureAttributes(other.BaseAttributes);
			ModifiedAttributes = new CreatureAttributes(BaseAttributes);
		}

		public Creature(CreatureAttributes attributes)
			: base(attributes)
		{
			BaseAttributes = new CreatureAttributes(attributes);
			_modifiedCreatureAttributes = new CreatureAttributes(attributes);
		}

		public Creature(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
		}

		private CreatureAttributes _baseCreatureAttributes = new CreatureAttributes();
		private CreatureAttributes _modifiedCreatureAttributes = new CreatureAttributes();

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
			get { return _modifiedCreatureAttributes; }
			set
			{
				_modifiedCreatureAttributes = value;
				NotifyPropertyChanged("ModifiedAttributes");
			}
		}

		public new CreatureAttributes GetEffectiveAttributes()
		{
			CreatureAttributes effectiveAttributes = ModifiedAttributes.Clone();
			foreach (Effect.Effect effect in Effects)
			{
				effect.ApplyTo(effectiveAttributes);
			}
			return effectiveAttributes;
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

		public string Type
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
			get { return GetEffectiveAttributes().HitPoints; }
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

		public int Speed
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

		public void ModifyAbilityScore(Types.Ability ability, int change)
		{
			ModifiedAttributes.ModifyAbilityScore(ability, change);
			NotifyPropertyChanged(Methods.GetAbilityString(ability));
		}

		public int DoHitPointDamage(Hit hit)
		{
			return ModifiedAttributes.DoHitPointDamage(hit);
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Creature");
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
