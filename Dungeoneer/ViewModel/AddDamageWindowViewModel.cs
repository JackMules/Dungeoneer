using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class AddDamageWindowViewModel : BaseViewModel
	{
		public AddDamageWindowViewModel()
		{

		}

		private string _numDice;
		private int _die;
		private string _modifier;
		private int _type;

		public string NumDice
		{
			get { return _numDice; }
			set
			{
				_numDice = value;
				NotifyPropertyChanged("NumDice");
			}
		}

		public int Die
		{
			get
			{
				return _die;
			}
			set
			{
				_die = value;
				NotifyPropertyChanged("Die");
			}
		}

		public string Modifier
		{
			get
			{
				return _modifier;
			}
			set
			{
				_modifier = value;
				NotifyPropertyChanged("Modifier");
			}
		}

		public int Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
				NotifyPropertyChanged("Type");
			}
		}

		public List<string> DieTypes
		{
			get
			{
				return Constants.DieTypeStrings;
			}
		}

		public List<string> DamageTypes
		{
			get
			{
				return Constants.DamageTypeStrings;
			}
		}

		public Model.Damage GetDamage()
		{
			bool askForInput = true;
			string feedback = null;
			Model.Damage damage = null;
			while (askForInput)
			{
				View.AddDamageWindow addDamageWindow = new View.AddDamageWindow(feedback);
				addDamageWindow.DataContext = this;

				if (addDamageWindow.ShowDialog() == true)
				{
					try
					{
						damage = new Model.Damage
						{
							NumDice = Convert.ToInt32(NumDice),
							Die = Methods.GetDieTypeFromString(DieTypes.ElementAt(Die)),
							Modifier = Convert.ToInt32(Modifier),
							Type = Methods.GetDamageTypeFromString(DamageTypes.ElementAt(Type)),
						};
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

			return damage;
		}
	}
}
