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
		public AddAttackWindowViewModel(Model.Attack attack = null)
		{
			_addDamage = new Command(ExecuteAddDamage);
			_editDamage = new Command(ExecuteEditDamage);
			_removeDamage = new Command(ExecuteRemoveDamage);
			_damages = new FullyObservableCollection<DamageViewModel>();

			if (attack != null)
			{
				_name = attack.Name;
				_modifier = attack.Modifier.ToString();
				_type = GetTypeIndex(attack.Type);
				_ability = GetAbilityIndex(attack.Ability);
				_selectedThreatRangeMinimum = GetThreatRangeIndex(attack.ThreatRangeMin);
				_selectedCritMultiplier = GetCritMultiplierIndex(attack.CritMultiplier);

				foreach (Model.Damage damage in attack.Damages)
				{
					DamageViewModel damageVM = new DamageViewModel
					{
						Damage = damage,
					};
					_damages.Add(damageVM);
				}
			}
			else
			{
				_name = "";
				_modifier = "";
				_type = 0;
				_ability = 0;
				_selectedThreatRangeMinimum = 0;
				_selectedCritMultiplier = 0;
			}
		}

		private string _name;
		private string _modifier;
		private int _type;
		private int _ability;
		private int _selectedThreatRangeMinimum;
		private int _selectedCritMultiplier;
		private FullyObservableCollection<DamageViewModel> _damages;
		private Command _addDamage;
		private Command _editDamage;
		private Command _removeDamage;

		public int SelectedDamage { get; set; }

		private int GetTypeIndex(Types.Attack attackType)
		{
			for (int i = 0; i < AttackTypes.Count; ++i)
			{
				if (AttackTypes[i] == Methods.GetAttackTypeString(attackType))
				{
					return i;
				}
			}
			return 0;
		}

		private int GetAbilityIndex(Types.Ability ability)
		{
			for (int i = 0; i < Abilities.Count; ++i)
			{
				if (Abilities[i] == Methods.GetAbilityString(ability))
				{
					return i;
				}
			}
			return 0;
		}

		private int GetThreatRangeIndex(int threatRangeMin)
		{
			for (int i = 0; i < ThreatRanges.Count; ++i)
			{
				if (ThreatRanges[i] == Methods.GetThreatRangeString(threatRangeMin))
				{
					return i;
				}
			}
			return 0;
		}

		private int GetCritMultiplierIndex(int critMultiplier)
		{
			for (int i = 0; i < CritMultipliers.Count; ++i)
			{
				if (CritMultipliers[i] == Methods.GetCritMultiplierString(critMultiplier))
				{
					return i;
				}
			}
			return 0;
		}

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

		public int Ability
		{
			get
			{
				return _ability;
			}
			set
			{
				_ability = value;
				NotifyPropertyChanged("Ability");
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

		public List<string> AttackTypes
		{
			get { return Constants.AttackTypeStrings; }
		}

		public List<string> Abilities
		{
			get { return new List<string> { Constants.AbilityStrength, Constants.AbilityDexterity, }; }
		}

		public List<string> ThreatRanges
		{
			get { return Constants.ThreatRangeStrings; }
		}

		public List<string> CritMultipliers
		{
			get { return Constants.CritMultiplierStrings; }
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
							Type = Methods.GetAttackTypeFromString(AttackTypes.ElementAt(Type)),
							Ability = Methods.GetAbilityFromString(Abilities.ElementAt(Ability)),
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

		public Command EditDamage
		{
			get { return _editDamage; }
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

		private void ExecuteEditDamage()
		{
			if (SelectedDamage < Damages.Count)
			{
				AddDamageWindowViewModel addDamageWindowViewModel = new AddDamageWindowViewModel(Damages[SelectedDamage].Damage);
				Model.Damage damage = addDamageWindowViewModel.GetDamage();
				if (damage != null)
				{
					DamageViewModel damageViewModel = new DamageViewModel { Damage = damage };
					Damages[SelectedDamage] = damageViewModel;
				}
			}
		}

		private void ExecuteRemoveDamage()
		{
			Damages.RemoveAt(SelectedDamage);
		}
	}
}
