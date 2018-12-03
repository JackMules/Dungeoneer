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
	public class SpeedSet : BaseModel
	{
		public SpeedSet()
		{
			_landSpeed = 0;
			Init();
		}

		public SpeedSet(int landSpeed)
		{
			LandSpeed = landSpeed;
			Init();
		}

		private void Init()
		{
			_speeds = new FullyObservableCollection<Speed>();
		}

		private int _landSpeed;
		private FullyObservableCollection<Speed> _speeds;
		
		public int LandSpeed
		{
			get { return _landSpeed; }
			set
			{
				_landSpeed = value;
				NotifyPropertyChanged("LandSpeed");
			}
		}

		public FullyObservableCollection<Speed> Speeds
		{
			get { return _speeds; }
			set
			{
				_speeds = value;
				NotifyPropertyChanged("Speeds");
			}
		}

		public override string ToString()
		{
			string str = LandSpeed.ToString() + " ft.";

			foreach (Speed speed in Speeds)
			{
				str += ", " + speed.ToString();
			}

			return str;
		}

		public void WriteXML(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("LandSpeed");
			xmlWriter.WriteString(LandSpeed.ToString());
			xmlWriter.WriteEndElement();

			foreach (Speed speed in Speeds)
			{
				speed.WriteXML(xmlWriter);
			}
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
						Speeds.Add(new Speed(childNode));
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
