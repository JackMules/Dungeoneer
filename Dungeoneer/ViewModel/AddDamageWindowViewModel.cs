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
		private Types.DieType _die;
		private string _modifier;
		private Types.DamageType _type;

		public string NumDice
		{
			get { return _numDice; }
			set
			{
				_numDice = value;
				NotifyPropertyChanged("NumDice");
			}
		}

		public Types.DieType Die
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

		public Types.DamageType Type
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

		public ObservableCollection<Types.DieType> DieTypes
		{
			get
			{
				return Constants.DieTypes;
			}
		}

		public ObservableCollection<Types.DamageType> DamageTypes
		{
			get
			{
				return Constants.DamageTypes;
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
//				addDamageWindow.DieTypeComboBox.ItemsSource = Constants.DieTypes;
//				addDamageWindow.DamageTypeComboBox.ItemsSource = Constants.DamageTypes;

				if (addDamageWindow.ShowDialog() == true)
				{
					try
					{
						damage = new Model.Damage
						{
							NumDice = Convert.ToInt32(NumDice),
							Die = Die,
							Modifier = Convert.ToInt32(Modifier),
							Type = Type,
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
