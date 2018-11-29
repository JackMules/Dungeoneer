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
	public class SpeedSet : BaseModel
	{
		public SpeedSet()
		{
			_landSpeed = 0;
		}

		public SpeedSet(int landSpeed)
		{
			LandSpeed = landSpeed;
		}

		private void Init()
		{
			_speeds = new List<Types.Speed>();
			_manouverability = Types.Manouverability.None;
		}

		private int _landSpeed;
		private List<Types.Speed> _speeds;
		private Types.Manouverability _manouverability;
		
		public int LandSpeed
		{
			get { return _landSpeed; }
			set
			{
				_landSpeed = value;
				NotifyPropertyChanged("LandSpeed");
			}
		}

		public List<Types.Speed> Speeds
		{
			get { return _speeds; }
			set
			{
				_speeds = value;
				NotifyPropertyChanged("Speeds");
			}
		}

		public Types.Manouverability Manouverability
		{
			get { return _manouverability; }
			set
			{
				_manouverability = value;
			}
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("LandSpeed");
			xmlWriter.WriteString(LandSpeed.ToString());
			xmlWriter.WriteEndElement();

			foreach (Types.Speed speed in Speeds)
			{
				xmlWriter.WriteStartElement("Speed");

				xmlWriter.WriteStartElement("Distance");
				xmlWriter.WriteString(speed.Distance.ToString());
				xmlWriter.WriteEndElement();

				xmlWriter.WriteStartElement("Type");
				xmlWriter.WriteString(speed.Type);
				xmlWriter.WriteEndElement();

				xmlWriter.WriteEndElement();
			}

			xmlWriter.WriteStartElement("Manouverability");
			xmlWriter.WriteString(Methods.GetManouverabilityString(Manouverability));
			xmlWriter.WriteEndElement();
		}

		public void ReadXML(XmlNode xmlNode)
		{
			try
			{
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode.Name == "LandSpeed")
					{
						LandSpeed = Convert.ToInt32(childNode.InnerText);
					}
					else if (childNode.Name == "Speed")
					{
						Types.Speed speed = new Types.Speed();

						foreach (XmlNode speedNode in childNode.ChildNodes)
						{
							if (speedNode.Name == "Distance")
							{
								speed.Distance = Convert.ToInt32(speedNode.InnerText);
							}
							else if (speedNode.Name == "Type")
							{
								speed.Type = speedNode.InnerText;
							}
						}

						Speeds.Add(speed);
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
