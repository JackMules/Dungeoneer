using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using Dungeoneer.Utility;

namespace Dungeoneer.Model
{
	public class NonPlayerActor : Actor
	{
		protected NonPlayerActor()
		{

		}

		public NonPlayerActor(NonPlayerActor other)
			: base(other)
		{
			_baseNonPlayerActorAttributes = new NonPlayerActorAttributes(other._baseNonPlayerActorAttributes);
			_modifiedNonPlayerActorAttributes = new NonPlayerActorAttributes(_baseNonPlayerActorAttributes);
		}

		public NonPlayerActor(NonPlayerActorAttributes attributes)
			: base(attributes)
		{
			_baseNonPlayerActorAttributes = new NonPlayerActorAttributes(attributes);
			_modifiedNonPlayerActorAttributes = new NonPlayerActorAttributes(attributes);
		}

		public NonPlayerActor(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
			_modifiedNonPlayerActorAttributes = new NonPlayerActorAttributes(_baseNonPlayerActorAttributes);
		}

		private NonPlayerActorAttributes _baseNonPlayerActorAttributes = new NonPlayerActorAttributes();
		private NonPlayerActorAttributes _modifiedNonPlayerActorAttributes = new NonPlayerActorAttributes();

		public new NonPlayerActorAttributes GetEffectiveAttributes()
		{
			NonPlayerActorAttributes effectiveAttributes = new NonPlayerActorAttributes(_modifiedNonPlayerActorAttributes);
			foreach (Effect.Effect effect in Effects)
			{
				effect.ApplyTo(effectiveAttributes);
			}
			return effectiveAttributes;
		}

		public string Type
		{
			get { return GetEffectiveAttributes().Type; }
			set
			{
				_modifiedNonPlayerActorAttributes.Type = value;
				NotifyPropertyChanged("Type");
			}
		}

		public float ChallengeRating
		{
			get { return GetEffectiveAttributes().ChallengeRating; }
			set
			{
				_modifiedNonPlayerActorAttributes.ChallengeRating = value;
				NotifyPropertyChanged("ChallengeRating");
			}
		}

		public FullyObservableCollection<AttackSet> AttackSets
		{
			get { return GetEffectiveAttributes().AttackSets; }
			set
			{
				_modifiedNonPlayerActorAttributes.AttackSets = value;
				NotifyPropertyChanged("Attacks");
			}
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("NonPlayerActor");
		}

		public override void WritePropertyXML(XmlWriter xmlWriter)
		{
			base.WritePropertyXML(xmlWriter);

			xmlWriter.WriteStartElement("Type");
			xmlWriter.WriteString(Type);
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
						_baseNonPlayerActorAttributes.Type = childNode.InnerText;
					}
					else if (childNode.Name == "ChallengeRating")
					{
						_baseNonPlayerActorAttributes.ChallengeRating = Convert.ToSingle(childNode.InnerText);
					}
					else if (childNode.Name == "AttackSets")
					{
						_baseNonPlayerActorAttributes.AttackSets.Clear();
						foreach (XmlNode attackSetNode in childNode.ChildNodes)
						{
							if (attackSetNode.Name == "AttackSet")
							{
								_baseNonPlayerActorAttributes.AttackSets.Add(new AttackSet(attackSetNode));
							}
						}
					}
				}

				_modifiedNonPlayerActorAttributes = new NonPlayerActorAttributes(_baseNonPlayerActorAttributes);
			}
			catch (XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}
	}
}
