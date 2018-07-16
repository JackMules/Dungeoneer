using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Data
{
	public static class ActorLibrary
	{

		public static ObservableCollection<Model.PlayerActor> Characters
		{
			get;
			set;
		}

		public static ObservableCollection<Model.NonPlayerActor> Enemies
		{
			get;
			set;
		}

		public static void LoadValues()
		{
			ObservableCollection<Model.PlayerActor> characters = new ObservableCollection<Model.PlayerActor>
			{
				new Model.PlayerActor { ActorName = "Kolnik", InitiativeMod = -1, Selected = false },
				new Model.PlayerActor { ActorName = "Atrion", InitiativeMod = 5, Selected = false },
				new Model.PlayerActor { ActorName = "Thrasin", InitiativeMod = 7, Selected = false },
				new Model.PlayerActor { ActorName = "Joshua", InitiativeMod = 10, Selected = false }
			};

			Characters = characters;

			ObservableCollection<Model.NonPlayerActor> enemies = new ObservableCollection<Model.NonPlayerActor>
			{
				new Model.Creature { ActorName = "Orc", InitiativeMod = 3, ChallengeRating = 0.5f },
				new Model.Creature { ActorName = "Orc", InitiativeMod = 3, ChallengeRating = 0.5f },
				new Model.Creature { ActorName = "Goblin", InitiativeMod = 2, ChallengeRating = 0.25f },
				new Model.NonPlayerActor { ActorName = "Poison Dart Trap", InitiativeMod = 6, ChallengeRating = 4 }
			};

			Enemies = enemies;
		}
	}
}
