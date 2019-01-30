using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.Model.Effect
{
	public class FastHealing : Effect
	{
		public FastHealing()
			: base(true)
		{
			Name = GetType().Name;
		}

		private uint _healingAmount;

		public uint HealingAmount
		{
			get { return _healingAmount; }
			set
			{
				_healingAmount = value;
				NotifyPropertyChanged("HealingAmount");
			}
		}

		public override void ApplyTo(ActorAttributes modifiedAttributes, ActorAttributes baseAttributes)
		{
			if (modifiedAttributes is CreatureAttributes)
			{
				(modifiedAttributes as CreatureAttributes).HitPoints += (int)HealingAmount;

				if ((modifiedAttributes as CreatureAttributes).HitPoints > 
						(baseAttributes as CreatureAttributes).HitPoints)
				{
					(modifiedAttributes as CreatureAttributes).HitPoints = (baseAttributes as CreatureAttributes).HitPoints;
				}
			}
		}

		public override string ToString()
		{
			return Methods.GetEffectTypeString(Types.Effect.FastHealing);
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement(GetType().Name);
		}

		public override void WritePropertyXML(XmlWriter xmlWriter)
		{
			base.WritePropertyXML(xmlWriter);

			xmlWriter.WriteStartElement("HealingAmount");
			xmlWriter.WriteString(HealingAmount.ToString());
			xmlWriter.WriteEndElement();
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			base.ReadXML(xmlNode);

			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "HealingAmount")
					{
						HealingAmount = Convert.ToUInt32(childNode.InnerText);
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
