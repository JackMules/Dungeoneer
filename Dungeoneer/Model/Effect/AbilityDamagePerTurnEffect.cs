using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.Model.Effect
{
	public class AbilityDamagePerTurnEffect : Effect
	{
		public AbilityDamagePerTurnEffect()
		{

		}

		private Types.Ability _ability;

		public Types.Ability Ability
		{
			get { return _ability; }
			set
			{
				_ability = value;
				NotifyPropertyChanged("Ability");
			}
		}

		public override Creature DoPerTurnBehaviour(Creature creature)
		{
			Weapon weapon = new Weapon();
			creature.HitPoints = Methods.CalculateNewHitPoints(creature, Value, weapon);
			return creature;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("AbilityDamagePerTurnEffect");
		}
	}
}
