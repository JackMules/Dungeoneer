using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;
using System.Xml;
using System.Windows.Forms;

namespace Dungeoneer.Model
{
	[Serializable]
	public class Speed : BaseModel
	{
		public Speed() { }

		public Speed(int distance, Types.Movement movementType, Types.Manouverability manouverability)
		{
			Distance = distance;
			MovementType = movementType;
			Manouverability = manouverability;
		}

		public Speed(XmlNode xmlNode)
		{
			ReadXML(xmlNode);
		}

		private int _distance;
		private Types.Movement _movementType;
		private Types.Manouverability _manouverability;

		public int Distance
		{
			get { return _distance; }
			set
			{
				_distance = value;
				NotifyPropertyChanged("Distance");
			}
		}

		public Types.Movement MovementType
		{
			get { return _movementType; }
			set
			{
				_movementType = value;
				NotifyPropertyChanged("MovementType");
			}
		}

		public Types.Manouverability Manouverability
		{
			get { return _manouverability; }
			set
			{
				_manouverability = value;
				NotifyPropertyChanged("Manouverability");
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Speed");

			xmlWriter.WriteStartElement("Distance");
			xmlWriter.WriteString(Distance.ToString());
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("MovementType");
			xmlWriter.WriteString(Methods.GetMovementTypeString(MovementType));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteStartElement("Manouverability");
			xmlWriter.WriteString(Methods.GetManouverabilityString(Manouverability));
			xmlWriter.WriteEndElement();

			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "Distance")
					{
						Distance = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "MovementType")
					{
						MovementType = Methods.GetMovementTypeFromString(childNode.InnerText);
					}
					else if (childNode.Name == "Manouverability")
					{
						Manouverability = Methods.GetManouverabilityFromString(childNode.InnerText);
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
