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
	public class Attack : INotifyPropertyChanged
	{
		private int _attackMod;
		private Utility.Types.AttackType _attackType;
		private int _numDamageDice;
		private Utility.Types.DieType _damageDie;
		private int _damageMod;
		private int _threatRangeMin;
		private int _critMultiplier;

		public int AttackMod
		{
			get { return _attackMod; }
			set
			{
				_attackMod = value;
				OnPropertyChanged("AttackMod");
			}
		}

		public Utility.Types.AttackType AttackType
		{
			get { return _attackType; }
			set
			{
				_attackType = value;
				OnPropertyChanged("AttackType");
			}
		}

		public int NumDamageDice
		{
			get { return _numDamageDice; }
			set
			{
				_numDamageDice = value;
				OnPropertyChanged("NumDamageDice");
			}
		}

		public Utility.Types.DieType DamageDie
		{
			get { return _damageDie; }
			set
			{
				_damageDie = value;
				OnPropertyChanged("DamageDie");
			}
		}

		public int DamageMod
		{
			get { return _damageMod; }
			set
			{
				_damageMod = value;
				OnPropertyChanged("DamageMod");
			}
		}

		public int ThreatRangeMin
		{
			get { return _threatRangeMin; }
			set
			{
				_threatRangeMin = value;
				OnPropertyChanged("ThreatRangeMin");
			}
		}

		public int CritMultiplier
		{
			get { return _critMultiplier; }
			set
			{
				_critMultiplier = value;
				OnPropertyChanged("CritMultiplier");
			}
		}


		public Attack(){}

		public Attack(
			int attackMod,
			Utility.Types.AttackType attackType,
			int numDamageDice,
			Utility.Types.DieType damageDie,
			int damageMod,
			int threatRangeMin,
			int critMultiplier)
		{
			AttackMod = attackMod;
			AttackType = attackType;
			NumDamageDice = numDamageDice;
			DamageDie = damageDie;
			DamageMod = damageMod;
			ThreatRangeMin = threatRangeMin;
			CritMultiplier = critMultiplier;
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Attack");

			xmlWriter.WriteStartElement("AttackMod");
			xmlWriter.WriteString(AttackMod.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("AttackType");
			xmlWriter.WriteString(Utility.Methods.GetAttackTypeString(AttackType));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("NumDamageDice");
			xmlWriter.WriteString(NumDamageDice.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("DamageDie");
			xmlWriter.WriteString(Utility.Methods.GetDieTypeString(DamageDie));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("DamageMod");
			xmlWriter.WriteString(DamageMod.ToString());
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
					if (childNode.Name == "AttackMod")
					{
						AttackMod = Convert.ToInt32(childNode.Value);
					}
					else if (childNode.Name == "AttackType")
					{
						AttackType = Utility.Methods.GetAttackTypeFromString(childNode.Value);
					}
					else if (childNode.Name == "NumDamageDice")
					{
						NumDamageDice = Convert.ToInt32(childNode.Value);
					}
					else if (childNode.Name == "DamageDie")
					{
						DamageDie = Utility.Methods.GetDieTypeFromString(childNode.Value);
					}
					else if (childNode.Name == "DamageMod")
					{
						DamageMod = Convert.ToInt32(childNode.Value);
					}
					else if (childNode.Name == "ThreatRangeMin")
					{
						ThreatRangeMin = Convert.ToInt32(childNode.Value);
					}
					else if (childNode.Name == "CritMultiplier")
					{
						CritMultiplier = Convert.ToInt32(childNode.Value);
					}
				}
			}
			catch (System.Xml.XmlException e)
			{
				MessageBox.Show(e.ToString());
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
