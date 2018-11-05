using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.Model
{
	public class NonPlayerActorAttributes : ActorAttributes
	{
		public NonPlayerActorAttributes()
			: base()
		{
			Type = "No Type";
			ChallengeRating = 1;
			AttackSets = new FullyObservableCollection<AttackSet>();
		}

		public NonPlayerActorAttributes(NonPlayerActorAttributes other)
			: base(other)
		{
			Type = other._type;
			ChallengeRating = other._challengeRating;
			AttackSets = other._attackSets;
		}

		private string _type;
		private float _challengeRating;
		private FullyObservableCollection<AttackSet> _attackSets;

		public string Type
		{
			get { return _type; }
			set
			{
				_type = value;
				NotifyPropertyChanged("Type");
			}
		}

		public float ChallengeRating
		{
			get { return _challengeRating; }
			set
			{
				_challengeRating = value;
				NotifyPropertyChanged("ChallengeRating");
			}
		}

		public FullyObservableCollection<AttackSet> AttackSets
		{
			get { return _attackSets; }
			set
			{
				_attackSets = value;
				NotifyPropertyChanged("Attacks");
			}
		}

		public void ChangeAttackModifier(Types.Ability ability, int change)
		{
			for (int set = 0; set < AttackSets.Count; ++set)
			{
				for (int attack = 0; attack < AttackSets[set].Attacks.Count; ++attack)
				{
					bool meleeAttack = false;
					bool rangedAttack = false;

					if ((AttackSets[set].Attacks[attack].Type == Types.Attack.Melee) ||
						(AttackSets[set].Attacks[attack].Type == Types.Attack.MeleeTouch))
					{
						meleeAttack = true;
					}
					else
					{
						rangedAttack = true;
					}

					if ((meleeAttack && ability == Types.Ability.Strength) ||
						(rangedAttack && ability == Types.Ability.Dexterity))
					{
						int newAttackMod = Convert.ToInt32(AttackSets[set].Attacks[attack].Modifier) + change;
						AttackSets[set].Attacks[attack].Modifier = newAttackMod;
					}
				}
			}
		}
	}
}
