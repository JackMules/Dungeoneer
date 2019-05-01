using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class ImportStatBlockWindowViewModel : BaseViewModel
	{
		public ImportStatBlockWindowViewModel()
		{

		}

		private string _statBlockText;

		public string StatBlockText
		{
			get { return _statBlockText; }
			set { SetField(ref _statBlockText, value); }
		}

		public Model.Creature GetCreature()
		{
			bool askForInput = true;
			string feedback = null;
			Model.Creature creature = null;
			while (askForInput)
			{
				View.ImportStatBlockWindow importStatBlockWindow = new View.ImportStatBlockWindow(feedback);
				importStatBlockWindow.DataContext = this;

				if (importStatBlockWindow.ShowDialog() == true)
				{
					try
					{
						creature = StatBlockImporter.ParseText(StatBlockText);
						askForInput = false;
					}
					catch (FormatException)
					{
						feedback = "Invalid format";
					}
				}
				else
				{
					askForInput = false;
				}
			}

			return creature;
		}
	}
}
