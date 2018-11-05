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
	public class Creature : NonPlayerActor
	{
		public Creature(Creature other)
			: base(other)
		{
			_baseCreatureAttributes = new CreatureAttributes(other._baseCreatureAttributes);
			_modifiedCreatureAttributes = new CreatureAttributes(_baseCreatureAttributes);
		}

		public Creature(CreatureAttributes attributes)
			: base(attributes)
		{
			_baseCreatureAttributes = new CreatureAttributes(attributes);
			_modifiedCreatureAttributes = new CreatureAttributes(attributes);
		}

		public Creature(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
		}

		private CreatureAttributes _baseCreatureAttributes = new CreatureAttributes();
		private CreatureAttributes _modifiedCreatureAttributes = new CreatureAttributes();

		public CreatureAttributes GetEffectiveCreatureAttributes()
		{
			CreatureAttributes effectiveAttributes = new CreatureAttributes(_modifiedCreatureAttributes);
			foreach (Effect.Effect effect in Effects)
			{
				effect.ApplyTo(effectiveAttributes);
			}
			return effectiveAttributes;
		}

		public int Strength
		{
			get
			{
				return GetEffectiveCreatureAttributes().Strength;
			}
			set
			{
				_modifiedCreatureAttributes.Strength = value;
				NotifyPropertyChanged("Strength");
			}
		}

		public int Dexterity
		{
			get { return GetEffectiveCreatureAttributes().Dexterity; }
			set
			{
				_modifiedCreatureAttributes.Dexterity = value;
				NotifyPropertyChanged("Dexterity");
			}
		}

		public int Constitution
		{
			get { return GetEffectiveCreatureAttributes().Constitution; }
			set
			{
				_modifiedCreatureAttributes.Constitution = value;
				NotifyPropertyChanged("Constitution");
			}
		}

		public int Intelligence
		{
			get { return GetEffectiveCreatureAttributes().Intelligence; }
			set
			{
				_modifiedCreatureAttributes.Intelligence = value;
				NotifyPropertyChanged("Intelligence");
			}
		}

		public int Wisdom
		{
			get { return GetEffectiveCreatureAttributes().Wisdom; }
			set
			{
				_modifiedCreatureAttributes.Wisdom = value;
				NotifyPropertyChanged("Wisdom");
			}
		}

		public int Charisma
		{
			get { return GetEffectiveCreatureAttributes().Charisma; }
			set
			{
				_modifiedCreatureAttributes.Charisma = value;
				NotifyPropertyChanged("Charisma");
			}
		}

		public int BaseAttackBonus
		{
			get { return GetEffectiveCreatureAttributes().BaseAttackBonus; }
			set
			{
				_modifiedCreatureAttributes.BaseAttackBonus = value;
				NotifyPropertyChanged("BaseAttackBonus");
			}
		}

		public int GrappleModifier
		{
			get { return GetEffectiveCreatureAttributes().GrappleModifier; }
			set
			{
				_modifiedCreatureAttributes.GrappleModifier = value;
				NotifyPropertyChanged("BaseGrappleModifierAttackBonus");
			}
		}

		public int HitPoints
		{
			get { return GetEffectiveCreatureAttributes().HitPoints; }
			set
			{
				_modifiedCreatureAttributes.HitPoints = value;
				NotifyPropertyChanged("HitPoints");
			}
		}

		public int HitDice
		{
			get { return GetEffectiveCreatureAttributes().HitDice; }
			set
			{
				_modifiedCreatureAttributes.HitDice = value;
				NotifyPropertyChanged("HitDice");
			}
		}

		public Types.Die HitDieType
		{
			get { return GetEffectiveCreatureAttributes().HitDieType; }
			set
			{
				_modifiedCreatureAttributes.HitDieType = value;
				NotifyPropertyChanged("HitDiceType");
			}
		}

		public int ArmorClass
		{
			get { return GetEffectiveCreatureAttributes().ArmorClass; }
			set
			{
				_modifiedCreatureAttributes.ArmorClass = value;
				NotifyPropertyChanged("ArmorClass");
			}
		}

		public int TouchArmorClass
		{
			get { return GetEffectiveCreatureAttributes().TouchArmorClass; }
			set
			{
				_modifiedCreatureAttributes.TouchArmorClass = value;
				NotifyPropertyChanged("TouchArmorClass");
			}
		}

		public int FlatFootedArmorClass
		{
			get { return GetEffectiveCreatureAttributes().FlatFootedArmorClass; }
			set
			{
				_modifiedCreatureAttributes.FlatFootedArmorClass = value;
				NotifyPropertyChanged("FlatFootedArmorClass");
			}
		}

		public int Speed
		{
			get { return GetEffectiveCreatureAttributes().Speed; }
			set
			{
				_modifiedCreatureAttributes.Speed = value;
				NotifyPropertyChanged("Speed");
			}
		}

		public int FortitudeSave
		{
			get { return GetEffectiveCreatureAttributes().FortitudeSave; }
			set
			{
				_modifiedCreatureAttributes.FortitudeSave = value;
				NotifyPropertyChanged("FortitudeSave");
			}
		}

		public int ReflexSave
		{
			get { return GetEffectiveCreatureAttributes().ReflexSave; }
			set
			{
				_modifiedCreatureAttributes.ReflexSave = value;
				NotifyPropertyChanged("ReflexSave");
			}
		}

		public int WillSave
		{
			get { return GetEffectiveCreatureAttributes().WillSave; }
			set
			{
				_modifiedCreatureAttributes.WillSave = value;
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
			get { return GetEffectiveCreatureAttributes().Space; }
			set
			{
				_modifiedCreatureAttributes.Space = value;
				NotifyPropertyChanged("Space");
			}
		}

		public int Reach
		{
			get { return GetEffectiveCreatureAttributes().Reach; }
			set
			{
				_modifiedCreatureAttributes.Reach = value;
				NotifyPropertyChanged("Reach");
			}
		}

		public List<string> Feats
		{
			get { return GetEffectiveCreatureAttributes().Feats; }
			set
			{
				_modifiedCreatureAttributes.Feats = value;
				NotifyPropertyChanged("Feats");
				NotifyPropertyChanged("PowerAttack");
			}
		}

		public Types.Size Size
		{
			get { return GetEffectiveCreatureAttributes().Size; }
			set
			{
				_modifiedCreatureAttributes.Size = value;
				NotifyPropertyChanged("Size");
			}
		}

		public ObservableCollection<DamageReduction> DamageReductions
		{
			get { return GetEffectiveCreatureAttributes().DamageReductions; }
			set
			{
				_modifiedCreatureAttributes.DamageReductions = value;
				NotifyPropertyChanged("DamageReductions");
			}
		}

		public DamageDescriptorSet Immunities
		{
			get { return GetEffectiveCreatureAttributes().Immunities; }
			set
			{
				_modifiedCreatureAttributes.Immunities = value;
				NotifyPropertyChanged("Immunities");
			}
		}

		public void ModifyAbilityScore(Types.Ability ability, int change)
		{
			_modifiedCreatureAttributes.ModifyAbilityScore(ability, change);
			NotifyPropertyChanged(Methods.GetAbilityString(ability));
		}

		public int DoHitPointDamage(Hit hit)
		{
			return _modifiedCreatureAttributes.DoHitPointDamage(hit);
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
						_baseCreatureAttributes.Strength = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Dexterity")
					{
						_baseCreatureAttributes.Dexterity = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Constitution")
					{
						_baseCreatureAttributes.Constitution = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Intelligence")
					{
						_baseCreatureAttributes.Intelligence = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Wisdom")
					{
						_baseCreatureAttributes.Wisdom = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Charisma")
					{
						_baseCreatureAttributes.Charisma = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "BaseAttackBonus")
					{
						_baseCreatureAttributes.BaseAttackBonus = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "GrappleModifier")
					{
						_baseCreatureAttributes.GrappleModifier = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "HitPoints")
					{
						_baseCreatureAttributes.HitPoints = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "HitDice")
					{
						_baseCreatureAttributes.HitDice = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "HitDieType")
					{
						_baseCreatureAttributes.HitDieType = Methods.GetDieTypeFromString(childNode.InnerText);
					}
					else if (childNode.Name == "ArmorClass")
					{
						_baseCreatureAttributes.ArmorClass = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "TouchArmorClass")
					{
						_baseCreatureAttributes.TouchArmorClass = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "FlatFootedArmorClass")
					{
						_baseCreatureAttributes.FlatFootedArmorClass = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Speed")
					{
						_baseCreatureAttributes.Speed = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "FortitudeSave")
					{
						_baseCreatureAttributes.FortitudeSave = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "ReflexSave")
					{
						_baseCreatureAttributes.ReflexSave = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "WillSave")
					{
						_baseCreatureAttributes.WillSave = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Feats")
					{
						foreach (XmlNode featNode in childNode.ChildNodes)
						{
							if (featNode.Name == "Feat")
							{
								_baseCreatureAttributes.Feats.Add(featNode.InnerText);
							}
						}
					}
					else if (childNode.Name == "Space")
					{
						_baseCreatureAttributes.Space = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Reach")
					{
						_baseCreatureAttributes.Reach = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Size")
					{
						_baseCreatureAttributes.Size = Methods.GetSizeFromString(childNode.InnerText);
					}
					else if (childNode.Name == "DamageReductions")
					{
						foreach (XmlNode drNode in childNode.ChildNodes)
						{
							if (drNode.Name == "DamageReduction")
							{
								DamageReduction dr = new DamageReduction();
								dr.ReadXML(drNode);
								_baseCreatureAttributes.DamageReductions.Add(dr);
							}
						}
					}
				}

				_modifiedCreatureAttributes = new CreatureAttributes(_baseCreatureAttributes);
			}
			catch (XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}
	}
}
