using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dungeoneer.Utility;
using System.Xml;

namespace Dungeoneer.Model
{
	public class Weapon : BaseModel
	{
		public Weapon()
		{

		}

		private string _name;
		private List<Types.Damage> _damageQualities;
		private List<Effect> _effects;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public List<Types.Damage> DamageQualities
		{
			get { return _damageQualities; }
			set
			{
				_damageQualities = value;
				NotifyPropertyChanged("DamageQualities");
			}
		}

		public List<Effect> Effects
		{
			get { return _effects; }
			set
			{
				_effects = value;
				NotifyPropertyChanged("Effects");
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Weapon");
			
			xmlWriter.WriteStartElement("Name");
			xmlWriter.WriteString(Name);
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("DamageQualities");
			foreach (Types.Damage damage in DamageQualities)
			{
				xmlWriter.WriteStartElement("Damage");
				xmlWriter.WriteString(Methods.GetDamageTypeString(damage));
				xmlWriter.WriteEndElement();
			}

			xmlWriter.WriteStartElement("Effects");
			foreach (Effect effect in Effects)
			{
				effect.WriteXML(xmlWriter);
			}

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
					else if (childNode.Name == "DamageQualities")
					{
						foreach (XmlNode damageNode in childNode.ChildNodes)
						{
							if (damageNode.Name == "Damage")
							{
								DamageQualities.Add(Methods.GetDamageTypeFromString(damageNode.InnerText));
							}
						}
					}
					else if (childNode.Name == "Effects")
					{
						foreach (XmlNode effectNode in childNode.ChildNodes)
						{
							Effect effect = new Effect();
							effect.ReadXML(effectNode);
							Effects.Add(effect);
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
