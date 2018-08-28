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
			Attacks = new FullyObservableCollection<ViewModel.AttackViewModel>();
		}

		public NonPlayerActor(
			string displayName,
			string actorName,
			string type,
			int initiativeMod,
			float challengeRating,
			FullyObservableCollection<ViewModel.AttackViewModel> attacks,
			FullyObservableCollection<Effect> conditions)
			: base(displayName, actorName, initiativeMod, conditions)
		{
			Type = type;
			ChallengeRating = challengeRating;
			Attacks = attacks;
		}

		private string _type;
		private float _challengeRating;
		private FullyObservableCollection<ViewModel.AttackViewModel> _attacks;

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

		public FullyObservableCollection<ViewModel.AttackViewModel> Attacks
		{
			get { return _attacks; }
			set
			{
				_attacks = value;
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

			xmlWriter.WriteStartElement("Attacks");
			foreach (ViewModel.AttackViewModel attack in Attacks)
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
						Type = childNode.InnerText;
					}
					else if (childNode.Name == "ChallengeRating")
					{
						ChallengeRating = Convert.ToSingle(childNode.InnerText);
					}
					else if (childNode.Name == "Attacks")
					{
						foreach (XmlNode attackNode in childNode.ChildNodes)
						{
							if (attackNode.Name == "Attack")
							{
								ViewModel.AttackViewModel attack = new ViewModel.AttackViewModel();
								attack.ReadXML(attackNode);
								Attacks.Add(attack);
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
