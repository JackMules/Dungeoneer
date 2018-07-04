using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer
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

		public uint ChallengeRating { get; set; }
		public uint FortitudeSave { get; set; }
		public uint ReflexSave { get; set; }
		public uint WillSave { get; set; }
		public bool PowerAttack { get; set; }

		public Utility.Size Size { get; set; }

		public Creature(
			string name, 
			string type, 
			NamedValue initiativeMod,
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
			uint challengeRating,
			uint fortitudeSave,
			uint reflexSave,
			uint willSave,
			bool powerAttack,
			Utility.Size size)
			: base(name, type, initiativeMod, attacks)
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
			ChallengeRating = challengeRating; 
			FortitudeSave = fortitudeSave; 
			ReflexSave = reflexSave; 
			WillSave = willSave;
			PowerAttack = powerAttack;
			Size = size;
		}
	}
}
