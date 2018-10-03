using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Dungeoneer.Model.Effect
{
	public abstract class Effect : BaseModel
	{
		public Effect(bool perTurn)
		{
			_perTurn = perTurn;
		}

		private bool _perTurn;
		private string _name;

		public bool PerTurn
		{
			get { return _perTurn; }
			private set { _perTurn = value; }
		}

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
			}
		}

		protected Creature ChangeAttackModifier(Creature creature, int penalty)
		{
			for (int set = 0; set < creature.AttackSets.Count; ++set)
			{
				for (int attack = 0; attack < creature.AttackSets[set].Attacks.Count; ++attack)
				{
					int newAttackMod = Convert.ToInt32(creature.AttackSets[set].Attacks[attack].Modifier) + penalty;
					creature.AttackSets[set].Attacks[attack].Modifier = newAttackMod;
				}
			}
			return creature;
		}

		public abstract bool Expired();

		public abstract Actor ApplyTo(Actor actor);

		public void WriteXML(XmlWriter xmlWriter)
		{
			WriteXMLStartElement(xmlWriter);
			WritePropertyXML(xmlWriter);
			xmlWriter.WriteEndElement();
		}

		public abstract void WriteXMLStartElement(XmlWriter xmlWriter);

		public virtual void WritePropertyXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("PerTurn");
			xmlWriter.WriteString(PerTurn.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Name");
			xmlWriter.WriteString(Name);
			xmlWriter.WriteEndElement();
		}

		public virtual void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "PerTurn")
					{
						PerTurn = Convert.ToBoolean(childNode.InnerText);
					}
					else if (childNode.Name == "Name")
					{
						Name = childNode.InnerText;
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
