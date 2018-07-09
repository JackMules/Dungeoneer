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
			//  Create the simple command - calls DoSimpleCommand.
			_setPartyCommand = new Command(DoSetPartyCommand);

			LoadValues();
		}

		public ObservableCollection<Actor> Characters
		{
			get;
			set;
		}

		public void LoadValues()
		{
			ObservableCollection<Actor> characters = new ObservableCollection<Actor>
			{
				new Actor { ActorName = "Kolnik", InitiativeMod = -1 },
				new Actor { ActorName = "Atrion", InitiativeMod = 5 },
				new Actor { ActorName = "Thrasin", InitiativeMod = 7 },
				new Actor { ActorName = "Joshua", InitiativeMod = 10 }
			};

			Characters = characters;
		}

		public ObservableCollection<InitiativeItem> InitiativeTrack
		{
			get;
			set;
		}

		private void DoSetPartyCommand(object selectedCharacters)
		{
			IList<Actor> selectedCharactersList = (IList<Actor>)selectedCharacters;
			
		}

		private Command _setPartyCommand;

		public Command SetPartyCommand
		{
			get { return _setPartyCommand; }
		}
	}
}
