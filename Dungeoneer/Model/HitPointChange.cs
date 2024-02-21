using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dungeoneer.Model
{
	public interface IHitPointChange : INotifyPropertyChanged
	{
		int GetHitPointChange();
		void WriteXML(XmlWriter xmlWriter);
	}
}
