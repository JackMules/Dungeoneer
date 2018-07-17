using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	public class Encounter
	{
		public Encounter()
		{

		}

		public ObservableCollection<Model.InitiativeItem> InitiativeTrack
		{
			get;
			set;
		}

		public void AddActor(Model.Actor actor)
		{
			InitiativeTrack.Add( new InitiativeItem() { Actor = actor } );
		}

		/*
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
		*/
	}
}
