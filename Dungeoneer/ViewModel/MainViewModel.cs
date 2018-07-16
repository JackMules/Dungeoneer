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
			Encounter = new Model.Encounter();

			LoadActorLibrary();
		}

		public Model.Encounter Encounter;

		// If one of the PC checkboxes changes, send all currently checked PCs to Encounter. 

		// Each time an enemy add button is clicked, pass that enemy object to Encounter

		public void LoadActorLibrary()
		{
			Data.ActorLibrary.LoadValues();
		}
	}
}
