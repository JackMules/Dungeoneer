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
		public AddDamageWindowViewModel(Model.Damage damage = null)
		{
			_damageTypeSelectorViewModel = new DamageTypeSelectorViewModel();

			if (damage != null)
			{
				_numDice = damage.NumDice.ToString();
				_die = GetDieTypeIndex(damage.Die);
				_modifier = damage.Modifier.ToString();
				_damageTypeSelectorViewModel.SetFromDamageDescriptorSet(damage.DamageDescriptorSet);
			}
		}

		private string _numDice;
		private int _die;
		private string _modifier;
		private DamageTypeSelectorViewModel _damageTypeSelectorViewModel;

		private int GetDieTypeIndex(Types.Die dieType)
		{
			for (int i = 0; i < DieTypes.Count; ++i)
			{
				if (DieTypes[i] == Methods.GetDieTypeString(dieType))
				{
					return i;
				}
			}
			return 0;
		}

		public string NumDice
		{
			get { return _numDice; }
			set { SetField(ref _numDice, value); }
		}

		public int Die
		{
			get { return _die; }
			set { SetField(ref _die, value); }
		}

		public string Modifier
		{
			get { return _modifier; }
			set { SetField(ref _modifier, value); }
		}

		public DamageTypeSelectorViewModel DamageTypeSelectorViewModel
		{
			get { return _damageTypeSelectorViewModel; }
			set
			{
				_damageTypeSelectorViewModel = value;
				NotifyPropertyChanged("DamageTypeSelectorViewModel");
			}
		}

		public List<string> DieTypes
		{
			get
			{
				return Constants.DieTypeStrings;
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
							DamageDescriptorSet = DamageTypeSelectorViewModel.GetDamageDescriptorSet(),
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
