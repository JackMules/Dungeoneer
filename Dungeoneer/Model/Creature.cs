using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class Creature : NonPlayerActor
	{
		public uint Strength { get; set; }
		public uint Dexterity { get; set; }
		public uint Constitution { get; set; }
		public uint Intelligence { get; set; }
		public uint Wisdom { get; set; }
		public uint Charisma { get; set; }

		public uint BaseAttackBonus { get; set; }
		public uint HitPoints { get; set; }
		public uint HitDice { get; set; }
		public Utility.DieType HitDiceType { get; set; }

		public uint ArmourClass { get; set; }
		public uint TouchArmourClass { get; set; }
		public uint FlatFootedArmourClass { get; set; }
		public uint DamageReduction { get; set; }
		public string DamageReductionType { get; set; }
		public uint Speed { get; set; }

		public uint FortitudeSave { get; set; }
		public uint ReflexSave { get; set; }
		public uint WillSave { get; set; }
		public bool PowerAttack { get; set; }

		public Utility.Size Size { get; set; }

		public Creature()
			: base()
		{
			Strength = 10;
			Dexterity = 10;
			Constitution = 10;
			Intelligence = 10;
			Wisdom = 10;
			Charisma = 10;
			BaseAttackBonus = 0;
			HitPoints = 3;
			HitDice = 1;
			HitDiceType = Utility.DieType.d3;
			ArmourClass = 10;
			TouchArmourClass = 10;
			FlatFootedArmourClass = 10;
			DamageReduction = 0;
			DamageReductionType = "";
			Speed = 30;
			FortitudeSave = 0;
			ReflexSave = 0;
			WillSave = 0;
			PowerAttack = false;
			Size = Utility.Size.Medium;
		}

		public Creature(
			string displayName,
			string actorName, 
			string type, 
			int initiativeMod,
			float challengeRating,
			List<Attack> attacks,
			uint strength,
			uint dexterity,
			uint constitution,
			uint intelligence,
			uint wisdom,
			uint charisma,
			uint baseAttackBonus,
			uint hitPoints,
			uint hitDice,
			Utility.DieType hitDiceType,
			uint armourClass,
			uint touchArmourClass,
			uint flatFootedArmourClass,
			uint damageReduction,
			string damageReductionType,
			uint speed,
			uint fortitudeSave,
			uint reflexSave,
			uint willSave,
			bool powerAttack,
			Utility.Size size)
			: base(displayName, actorName, type, 
					initiativeMod, challengeRating, attacks)
		{
			Strength = strength;
			Dexterity = dexterity;
			Constitution = constitution;
			Intelligence = intelligence;
			Wisdom = wisdom;
			Charisma = charisma;
			BaseAttackBonus = baseAttackBonus;
			HitPoints = hitPoints; 
			HitDice = hitDice; 
			HitDiceType = hitDiceType; 
			ArmourClass = armourClass; 
			TouchArmourClass = touchArmourClass; 
			FlatFootedArmourClass = flatFootedArmourClass; 
			DamageReduction = damageReduction; 
			DamageReductionType = damageReductionType; 
			Speed = speed; 
			FortitudeSave = fortitudeSave; 
			ReflexSave = reflexSave; 
			WillSave = willSave;
			PowerAttack = powerAttack;
			Size = size;
		}
	}
}
