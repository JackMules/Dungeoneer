using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class AddWeaponWindowViewModel : BaseViewModel
	{
		public AddWeaponWindowViewModel()
		{
			_name = "";
			_abilityDamage = false;
			_damageTypeSelectorViewModel = new DamageTypeSelectorViewModel();
		}

		private string _name;
		private bool _abilityDamage;
		private string _abilityDamageValue;
		private Types.Ability _ability;
		private DamageTypeSelectorViewModel _damageTypeSelectorViewModel;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public bool AbilityDamage
		{
			get { return _abilityDamage; }
			set
			{
				_abilityDamage = value;
				NotifyPropertyChanged("AbilityDamage");
			}
		}

		public string AbilityDamageValue
		{
			get { return _abilityDamageValue; }
			set
			{
				_abilityDamageValue = value;
				NotifyPropertyChanged("AbilityDamageValue");
			}
		}

		public Types.Ability Ability
		{
			get { return _ability; }
			set
			{
				_ability = value;
				NotifyPropertyChanged("Ability");
			}
		}

		public List<string> Abilities
		{
			get { return Constants.AbilityStrings; }
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

		public Model.Weapon GetWeapon()
		{
			bool askForInput = true;
			string feedback = null;
			Model.Weapon weapon = null;
			while (askForInput)
			{
				View.AddWeaponWindow addWeaponWindow = new View.AddWeaponWindow(feedback);
				addWeaponWindow.DataContext = this;

				if (addWeaponWindow.ShowDialog() == true)
				{
					try
					{
						weapon = new Model.Weapon();

						weapon.Name = Name;
						weapon.AbilityDamage = AbilityDamage;
						weapon.AbilityDamageValue = Convert.ToInt32(AbilityDamageValue);
						weapon.Ability = Ability;
						weapon.DamageDescriptorSet = DamageTypeSelectorViewModel.GetDamageDescriptorSet();
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

			return weapon;
		}
	}
}
