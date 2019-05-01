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
		public AddWeaponWindowViewModel(Model.Weapon weapon = null)
		{
			_damageTypeSelectorViewModel1 = new DamageTypeSelectorViewModel();
			_damageTypeSelectorViewModel2 = new DamageTypeSelectorViewModel();
			_damageTypeSelectorViewModel3 = new DamageTypeSelectorViewModel();

			if (weapon != null)
			{
				_name = weapon.Name;
				_abilityDamage = weapon.AbilityDamage;
				_abilityDamageValue = weapon.AbilityDamageValue.ToString();
				_selectedAbility = GetAbilityIndex(weapon.Ability);

				if (weapon.DamageDescriptorSets.Count > 0)
				{
					_damageTypeSelectorViewModel1.SetFromDamageDescriptorSet(weapon.DamageDescriptorSets[0]);
				}
				if (weapon.DamageDescriptorSets.Count > 1)
				{
					_damageTypeSelectorViewModel2.SetFromDamageDescriptorSet(weapon.DamageDescriptorSets[1]);
				}
				if (weapon.DamageDescriptorSets.Count > 2)
				{
					_damageTypeSelectorViewModel3.SetFromDamageDescriptorSet(weapon.DamageDescriptorSets[2]);
				}
			}
			else
			{
				_name = "";
				_abilityDamage = false;
			}
		}

		private string _name;
		private bool _abilityDamage;
		private string _abilityDamageValue;
		private int _selectedAbility;
		private DamageTypeSelectorViewModel _damageTypeSelectorViewModel1;
		private DamageTypeSelectorViewModel _damageTypeSelectorViewModel2;
		private DamageTypeSelectorViewModel _damageTypeSelectorViewModel3;

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

		public string Name
		{
			get { return _name; }
			set { SetField(ref _name, value); }
		}

		public bool AbilityDamage
		{
			get { return _abilityDamage; }
			set { SetField(ref _abilityDamage, value); }
		}

		public string AbilityDamageValue
		{
			get { return _abilityDamageValue; }
			set { SetField(ref _abilityDamageValue, value); }
		}

		public int SelectedAbility
		{
			get { return _selectedAbility; }
			set { SetField(ref _selectedAbility, value); }
		}

		public Types.Ability Ability
		{
			get { return Methods.GetAbilityFromString(Abilities.ElementAt(SelectedAbility)); }
		}

		public List<string> Abilities
		{
			get { return Constants.AbilityStrings; }
		}

		public DamageTypeSelectorViewModel DamageTypeSelectorViewModel1
		{
			get { return _damageTypeSelectorViewModel1; }
			set { SetField(ref _damageTypeSelectorViewModel1, value); }
		}

		public DamageTypeSelectorViewModel DamageTypeSelectorViewModel2
		{
			get { return _damageTypeSelectorViewModel2; }
			set { SetField(ref _damageTypeSelectorViewModel2, value); }
		}

		public DamageTypeSelectorViewModel DamageTypeSelectorViewModel3
		{
			get { return _damageTypeSelectorViewModel3; }
			set { SetField(ref _damageTypeSelectorViewModel3, value); }
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
						weapon = new Model.Weapon
						{
							Name = Name,
							AbilityDamage = AbilityDamage,
							AbilityDamageValue = Convert.ToInt32(AbilityDamageValue),
							Ability = Ability
						};

						weapon.DamageDescriptorSets.Add(DamageTypeSelectorViewModel1.GetDamageDescriptorSet());
						weapon.DamageDescriptorSets.Add(DamageTypeSelectorViewModel2.GetDamageDescriptorSet());
						weapon.DamageDescriptorSets.Add(DamageTypeSelectorViewModel3.GetDamageDescriptorSet());
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
