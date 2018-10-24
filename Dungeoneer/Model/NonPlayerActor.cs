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
		public NonPlayerActor()
			: base()
		{
			Type = "No Type";
			ChallengeRating = 1;
			AttackSets = new FullyObservableCollection<AttackSet>();
		}

		public NonPlayerActor(
			string actorName,
			string type,
			int initiativeMod,
			float challengeRating,
			FullyObservableCollection<AttackSet> attackSets)
			: base(actorName, initiativeMod)
		{
			Type = type;
			ChallengeRating = challengeRating;
			AttackSets = attackSets;
		}

		private string _type;
		private float _challengeRating;
		private FullyObservableCollection<AttackSet> _attackSets;

		public string Type
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
						Type = childNode.InnerText;
					}
					else if (childNode.Name == "ChallengeRating")
					{
						ChallengeRating = Convert.ToSingle(childNode.InnerText);
					}
					else if (childNode.Name == "AttackSets")
					{
						foreach (XmlNode attackSetNode in childNode.ChildNodes)
						{
							if (attackSetNode.Name == "AttackSet")
							{
								AttackSet attackSet = new AttackSet();
								attackSet.ReadXML(attackSetNode);
								AttackSets.Add(attackSet);
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
	}
}
