using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class AddAttackWindowViewModel : BaseViewModel
	{
		public AddAttackWindowViewModel()
		{
			_addDamage = new Command(ExecuteAddDamage);
			_removeDamage = new Command(ExecuteRemoveDamage);
			_name = "";
			_modifier = "";
			_type = Types.AttackType.Primary;
			_selectedThreatRangeMinimum = 0;
			_selectedCritMultiplier = 0;
			_damages = new FullyObservableCollection<DamageViewModel>();
	}

		private string _name;
		private string _modifier;
		private Types.AttackType _type;
		private int _selectedThreatRangeMinimum;
		private int _selectedCritMultiplier;
		private FullyObservableCollection<DamageViewModel> _damages;
		private Command _addDamage;
		private Command _removeDamage;

		public int SelectedDamage { get; set; }

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
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

		public Types.AttackType AttackType
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
				NotifyPropertyChanged("AttackType");
			}
		}

		public int SelectedThreatRange
		{
			get
			{
				return _selectedThreatRangeMinimum;
			}
			set
			{
				_selectedThreatRangeMinimum = value;
				NotifyPropertyChanged("ThreatRange");
			}
		}

		public int SelectedCritMultiplier
		{
			get
			{
				return _selectedCritMultiplier;
			}
			set
			{
				_selectedCritMultiplier = value;
				NotifyPropertyChanged("CritMultiplier");
			}
		}

		public FullyObservableCollection<DamageViewModel> Damages
		{
			get
			{
				return _damages;
			}
			set
			{
				_damages = value;
				NotifyPropertyChanged("Damages");
			}
		}

		public ObservableCollection<Types.AttackType> AttackTypes
		{
			get { return Constants.AttackTypes; }
		}

		public ObservableCollection<string> ThreatRanges
		{
			get { return Constants.ThreatRanges; }
		}

		public ObservableCollection<string> CritMultipliers
		{
			get { return Constants.CritMultipliers; }
		}

		public Model.Attack GetAttack()
		{
			bool askForInput = true;
			string feedback = null;
			Model.Attack attack = null;
			while (askForInput)
			{
				View.AddAttackWindow addAttackWindow = new View.AddAttackWindow(feedback);
				addAttackWindow.DataContext = this;

				if (addAttackWindow.ShowDialog() == true)
				{
					try
					{
						attack = new Model.Attack
						{
							Name = Name,
							Modifier = Convert.ToInt32(Modifier),
							Type = AttackType,
							ThreatRangeMin = Methods.GetThreatRangeMinFromString(ThreatRanges.ElementAt(SelectedThreatRange)),
							CritMultiplier = Methods.GetCritMultiplierFromString(CritMultipliers.ElementAt(SelectedCritMultiplier)),
						};

						foreach (DamageViewModel damageViewModel in Damages)
						{
							attack.Damages.Add(damageViewModel.Damage);
						}

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

			return attack;
		}

		public Command AddDamage
		{
			get { return _addDamage; }
		}

		public Command RemoveDamage
		{
			get { return _removeDamage; }
		}

		private void ExecuteAddDamage()
		{
			AddDamageWindowViewModel addDamageWindowViewModel = new AddDamageWindowViewModel();
			Model.Damage damage = addDamageWindowViewModel.GetDamage();
			if (damage != null)
			{
				DamageViewModel damageViewModel = new DamageViewModel { Damage = damage };
				Damages.Add(damageViewModel);
			}
		}

		private void ExecuteRemoveDamage()
		{
			Damages.RemoveAt(SelectedDamage);
		}
	}
}
