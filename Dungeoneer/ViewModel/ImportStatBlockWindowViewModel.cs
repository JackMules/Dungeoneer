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
			_statBlockText = "";
			_importFormat = ImportFormat.SRD;
		}

		private string _statBlockText;
		private ImportFormat _importFormat;

		public string StatBlockText
		{
			get { return _statBlockText; }
			set { SetField(ref _statBlockText, value); }
		}

		public ImportFormat ImportFormat
		{
			get { return _importFormat; }
			set { SetField(ref _importFormat, value); }
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
						if (ImportFormat == ImportFormat.SRD)
						{
							creature = StatBlockImporter.ParseSRDText(StatBlockText);
							askForInput = false;
						}
						else if (ImportFormat == ImportFormat.MM4)
						{
							creature = StatBlockImporter.ParseMM4Text(StatBlockText);
							askForInput = false;
						}
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
