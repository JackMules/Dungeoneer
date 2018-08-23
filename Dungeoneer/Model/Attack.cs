using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Dungeoneer.Model
{
	public class Attack : BaseModel
	{
		private string _name;
		private int _attackMod;
		private Utility.Types.AttackType _attackType;
		private Utility.FullyObservableCollection<Damage> _damages;
		private int _threatRangeMin;
		private int _critMultiplier;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public int AttackMod
		{
			get { return _attackMod; }
			set
			{
				_attackMod = value;
				NotifyPropertyChanged("AttackMod");
			}
		}

		public Utility.Types.AttackType AttackType
		{
			get { return _attackType; }
			set
			{
				_attackType = value;
				NotifyPropertyChanged("AttackType");
			}
		}

		public Utility.FullyObservableCollection<Damage> Damages
		{
			get { return _damages; }
			set
			{
				_damages = value;
				NotifyPropertyChanged("Damages");
			}
		}

		public int ThreatRangeMin
		{
			get { return _threatRangeMin; }
			set
			{
				_threatRangeMin = value;
				NotifyPropertyChanged("ThreatRangeMin");
			}
		}

		public int CritMultiplier
		{
			get { return _critMultiplier; }
			set
			{
				_critMultiplier = value;
				NotifyPropertyChanged("CritMultiplier");
			}
		}


		public Attack(){}

		public Attack(
			string name,
			int attackMod,
			Utility.Types.AttackType attackType,
			Utility.FullyObservableCollection<Damage> damages,
			int threatRangeMin,
			int critMultiplier)
		{
			Name = name;
			AttackMod = attackMod;
			AttackType = attackType;
			Damages = damages;
			ThreatRangeMin = threatRangeMin;
			CritMultiplier = critMultiplier;
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Attack");

			xmlWriter.WriteStartElement("Name");
			xmlWriter.WriteString(Name);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("AttackMod");
			xmlWriter.WriteString(AttackMod.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("AttackType");
			xmlWriter.WriteString(Utility.Methods.GetAttackTypeString(AttackType));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Damages");
			foreach (Damage damage in Damages)
			{
				damage.WriteXML(xmlWriter);
			}
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("ThreatRangeMin");
			xmlWriter.WriteString(ThreatRangeMin.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("CritMultiplier");
			xmlWriter.WriteString(CritMultiplier.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Name")
					{
						Name = childNode.InnerText;
					}
					else if (childNode.Name == "AttackMod")
					{
						AttackMod = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "AttackType")
					{
						AttackType = Utility.Methods.GetAttackTypeFromString(childNode.InnerText);
					}
					else if (childNode.Name == "Damages")
					{
						foreach (XmlNode damageNode in childNode.ChildNodes)
						{
							if (damageNode.Name == "Damage")
							{
								Damage damage = new Damage();
								damage.ReadXML(damageNode);
								Damages.Add(damage);
							}
						}
					}
					else if (childNode.Name == "ThreatRangeMin")
					{
						ThreatRangeMin = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "CritMultiplier")
					{
						CritMultiplier = Convert.ToInt32(childNode.InnerText);
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
