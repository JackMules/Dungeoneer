using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public class SetInitiativeWindowViewModel : BaseViewModel
	{
		public SetInitiativeWindowViewModel()
		{

		}

		private string _score;
		private string _adjust;
		private string _modifier;
		private string _roll;

		public string Score
		{
			get { return _score; }
			set
			{
				_score = value;
				NotifyPropertyChanged("Score");
			}
		}

		public string Adjust
		{
			get { return _adjust; }
			set
			{
				_adjust = value;
				NotifyPropertyChanged("Adjust");
			}
		}

		public string Modifier
		{
			get { return _modifier; }
			set
			{
				_modifier = value;
				NotifyPropertyChanged("Modifier");
			}
		}

		public string Roll
		{
			get { return _roll; }
			set
			{
				_roll = value;
				NotifyPropertyChanged("Roll");
			}
		}

		public Model.InitiativeValue GetInitiative()
		{
			bool askForInput = true;
			string feedback = null;
			Model.InitiativeValue initiativeValue = null;
			while (askForInput)
			{
				View.SetInitiativeWindow initDialog = new View.SetInitiativeWindow(feedback);
				if (initDialog.ShowDialog() == true)
				{
					try
					{
						initiativeValue = new Model.InitiativeValue
						{
							Score = Convert.ToInt32(Score),
							Adjust = Convert.ToInt32(Adjust),
							Modifier = Convert.ToInt32(Modifier),
							Roll = Convert.ToInt32(Roll),
						};

						askForInput = false;
					}
					catch (FormatException)
					{
						// Failed to parse input
						feedback = "Invalid format";
					}
				}
				else
				{
					askForInput = false;
				}
			}

			return initiativeValue;
		}
	}
}
