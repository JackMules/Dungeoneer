using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;
using System.Xml;

namespace Dungeoneer.Model.Effect
{
	public static class EffectFactory
	{
		
		public static Effect GetEffect(Types.Effect effectType)
		{
			return new AbilityDamagePerTurnEffect();
		}

		public static Effect GetEffectFromXML(XmlNode xmlNode)
		{

			return new AbilityDamagePerTurnEffect();
		}
		
	}
}
