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

		public SetInitiativeWindowViewModel(int initMod)
		{
			_modifier = initMod.ToString();
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
				string score;
				if (value.Equals("0"))
				{
					score = "";
				}
				else
				{
					score = value;
				}
				SetField(ref _score, score);
			}
		}

		public string Adjust
		{
			get { return _adjust; }
			set
			{
				string adjust;
				if (value.Equals("0"))
				{
					adjust = "";
				}
				else
				{
					adjust = value;
				}
				SetField(ref _adjust, adjust);
			}
		}

		public string Modifier
		{
			get { return _modifier; }
			set
			{
				string modifier;
				if (value.Equals("0"))
				{
					modifier = "";
				}
				else
				{
					modifier = value;
				}
				SetField(ref _modifier, modifier);
			}
		}

		public string Roll
		{
			get { return _roll; }
			set
			{
				string roll;
				if (value.Equals("0"))
				{
					roll = "";
				}
				else
				{
					roll = value;
				}
				SetField(ref _roll, roll);
			}
		}

		public Model.InitiativeValue GetInitiative()
		{
			string feedback = null;
			Model.InitiativeValue initiativeValue = null;
			View.SetInitiativeWindow initDialog = new View.SetInitiativeWindow(feedback);
			initDialog.DataContext = this;
			if (initDialog.ShowDialog() == true)
			{
				int score = 0;
				int adjust = 0;
				int modifier = 0;
				int roll = 0;

				try
				{
					score = Convert.ToInt32(Score);
				}
				catch (FormatException)
				{
					
				}

				try
				{
					adjust = Convert.ToInt32(Adjust);
				}
				catch (FormatException)
				{

				}

				try
				{
					modifier = Convert.ToInt32(Modifier);
				}
				catch (FormatException)
				{

				}

				try
				{
					roll = Convert.ToInt32(Roll);
				}
				catch (FormatException)
				{

				}

				initiativeValue = new Model.InitiativeValue
				{
					Score = score,
					Adjust = adjust,
					Modifier = modifier,
					Roll = roll,
				};
			}

			return initiativeValue;
		}
	}
}
