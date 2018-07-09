using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class NonPlayerActor : Actor
	{
		public string Type { get; set; }
		public float ChallengeRating { get; set; }
		public List<Attack> Attacks;

		public NonPlayerActor()
			: base()
		{
			Type = "No Type";
			ChallengeRating = 1;
			Attacks = null;
		}

		public NonPlayerActor(
			string name,
			string type,
			int initiativeMod,
			float challengeRating,
			List<Attack> attacks)
			: base(name, initiativeMod)
		{
			Type = type;
			ChallengeRating = challengeRating;
			Attacks = attacks;
		}
	}
}
