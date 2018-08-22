using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Dungeoneer.Model
{
	public class NonPlayerActor : Actor
	{
		private string _type;
		private float _challengeRating;
		private List<Attack> _attacks;

		public string Type
		{
			get { return _type; }
			set
			{
				_type = value;
				OnPropertyChanged("Type");
			}
		}

		public float ChallengeRating
		{
			get { return _challengeRating; }
			set
			{
				_challengeRating = value;
				OnPropertyChanged("ChallengeRating");
			}
		}

		public List<Attack> Attacks
		{
			get { return _attacks; }
			set
			{
				_attacks = value;
				OnPropertyChanged("Attacks");
			}
		}

		public NonPlayerActor()
			: base()
		{
			Type = "No Type";
			ChallengeRating = 1;
			Attacks = new List<Attack>();
		}

		public NonPlayerActor(
			string displayName,
			string actorName,
			string type,
			int initiativeMod,
			float challengeRating,
			List<Attack> attacks,
			Utility.FullyObservableCollection<Condition> conditions)
			: base(displayName, actorName, initiativeMod, conditions)
		{
			Type = type;
			ChallengeRating = challengeRating;
			Attacks = attacks;
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

			xmlWriter.WriteStartElement("Attacks");
			foreach (Attack attack in Attacks)
			{
				attack.WriteXML(xmlWriter);
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
						Type = childNode.Value;
					}
					else if (childNode.Name == "ChallengeRating")
					{
						ChallengeRating = Convert.ToInt32(childNode.Value);
					}
					else if (childNode.Name == "Attacks")
					{
						foreach (XmlNode attackNode in childNode.ChildNodes)
						{
							if (attackNode.Name == "Attack")
							{
								Attack attack = new Attack();
								attack.ReadXML(attackNode);
								Attacks.Add(attack);
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
