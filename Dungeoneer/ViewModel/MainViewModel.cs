using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	class MainViewModel : ViewModel
	{
		public MainViewModel()
		{
			LoadValues();
		}

		public ObservableCollection<Model.PlayerActor> Characters
		{
			get;
			set;
		}

		public ObservableCollection<Model.NonPlayerActor> Enemies
		{
			get;
			set;
		}
		
		public void LoadValues()
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

		public ObservableCollection<Model.InitiativeItem> InitiativeTrack
		{
			get;
			set;
		}

		public void UpdateInitiativeTrack() // What's the point of this function? Is this the right way to do this?
		{
			// for each character in Characters, if selected, add 
			foreach (Model.PlayerActor character in Characters)
			{
				if (character.Selected)
				{
					bool bActorAlreadyPresent = false;
					foreach (Model.InitiativeItem initItem in InitiativeTrack)
					{
						if (initItem.Actor == character)
						{
							bActorAlreadyPresent = true;
						}
					}

					if (!bActorAlreadyPresent)
					{
						InitiativeTrack.Add(new Model.InitiativeItem { Actor = character });
					}
				}
			}
		}

	}
}
