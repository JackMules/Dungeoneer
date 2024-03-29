﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class HitPointChangeDialogViewModel : BaseViewModel
	{
		public HitPointChangeDialogViewModel(FullyObservableCollection<Model.WeaponSet> weaponList,
			string currentActorName)
		{
			_weaponList = weaponList;
			_currentActorName = currentActorName;
			_damageTypeSelectorViewModel1 = new DamageTypeSelectorViewModel();
			_damageTypeSelectorViewModel2 = new DamageTypeSelectorViewModel();
			_damageTypeSelectorViewModel3 = new DamageTypeSelectorViewModel();
			_damage1 = "";
			_damage2 = "";
			_damage3 = "";
			_healing = "";
			_selectedWeapon = 0;
			_abilityDamage = false;
			_weaponName = "";
		}

		public HitPointChangeDialogViewModel(FullyObservableCollection<Model.WeaponSet> weaponList,
			string currentActorName, Model.IHitPointChange hitPointChange)
		{
			_weaponList = weaponList;
			_currentActorName = currentActorName;

			_damageTypeSelectorViewModel1 = new DamageTypeSelectorViewModel();
			_damageTypeSelectorViewModel2 = new DamageTypeSelectorViewModel();
			_damageTypeSelectorViewModel3 = new DamageTypeSelectorViewModel();

			if (hitPointChange is Model.Hit)
			{
				Model.Hit hit = hitPointChange as Model.Hit;

				_healing = "";
				_damage1 = "";
				_damage2 = "";
				_damage3 = "";

				_damage1 = hit.DamageSets[0].Amount.ToString();
				if (hit.DamageSets.Count > 1)
				{
					_damage2 = hit.DamageSets[1].Amount.ToString();
					if (hit.DamageSets.Count > 2)
					{
						_damage3 = hit.DamageSets[2].Amount.ToString();
					}
				}

				int weaponIndex = GetWeaponIndexInList(hit.Weapon);
				if (weaponIndex >= 0)
				{
					SelectedWeapon = weaponIndex;
				}
			}
			else if (hitPointChange is Model.Heal)
			{
				Model.Heal heal = hitPointChange as Model.Heal;
				_healing = heal.Amount.ToString();

				_damage1 = "";
				_damage2 = "";
				_damage3 = "";
				_selectedWeapon = 0;
				_abilityDamage = false;
			}
			else
			{
				_damage1 = "";
				_damage2 = "";
				_damage3 = "";
				_healing = "";
				_selectedWeapon = 0;
				_abilityDamage = false;
			}
		}

		private FullyObservableCollection<Model.WeaponSet> _weaponList;
		private string _currentActorName;
		private string _damage1;
		private string _damage2;
		private string _damage3;
		private string _healing;
		private string _weaponName;
		private int _selectedWeapon;
		private DamageTypeSelectorViewModel _damageTypeSelectorViewModel1;
		private DamageTypeSelectorViewModel _damageTypeSelectorViewModel2;
		private DamageTypeSelectorViewModel _damageTypeSelectorViewModel3;
		private bool _abilityDamage;
		private string _abilityDamageValue;
		private string _selectedAbility;

		public DamageTypeSelectorViewModel DamageTypeSelectorViewModel1
		{
			get { return _damageTypeSelectorViewModel1; }
			set
			{
				_damageTypeSelectorViewModel1 = value;
				NotifyPropertyChanged("DamageTypeSelectorViewModel1");
			}
		}

		public DamageTypeSelectorViewModel DamageTypeSelectorViewModel2
		{
			get { return _damageTypeSelectorViewModel2; }
			set
			{
				_damageTypeSelectorViewModel2 = value;
				NotifyPropertyChanged("DamageTypeSelectorViewModel2");
			}
		}

		public DamageTypeSelectorViewModel DamageTypeSelectorViewModel3
		{
			get { return _damageTypeSelectorViewModel3; }
			set
			{
				_damageTypeSelectorViewModel3 = value;
				NotifyPropertyChanged("DamageTypeSelectorViewModel3");
			}
		}

		public FullyObservableCollection<Model.WeaponSet> WeaponList
		{
			get { return _weaponList; }
			set { SetField(ref _weaponList, value); }
		}

		public string CurrentActorName
		{
			get { return _currentActorName; }
			set { SetField(ref _currentActorName, value); }
		}

		public string Damage1
		{
			get { return _damage1; }
			set { SetField(ref _damage1, value); }
		}

		public string Damage2
		{
			get { return _damage2; }
			set { SetField(ref _damage2, value); }
		}

		public string Damage3
		{
			get { return _damage3; }
			set { SetField(ref _damage3, value); }
		}

		public string Healing
		{
			get { return _healing; }
			set { SetField(ref _healing, value); }
		}

		public int SelectedWeapon
		{
			get { return _selectedWeapon; }
			set
			{
				SetField(ref _selectedWeapon, value);
				if (SelectedWeapon != 0)
				{
					Model.Weapon weapon = GetFlatWeaponList().ElementAt(SelectedWeapon - 1).Item2;

					if (weapon.DamageDescriptorSets.Count > 0)
					{
						DamageTypeSelectorViewModel1.SetFromDamageDescriptorSet(weapon.DamageDescriptorSets[0]);
					}
					if (weapon.DamageDescriptorSets.Count > 1)
					{
						DamageTypeSelectorViewModel2.SetFromDamageDescriptorSet(weapon.DamageDescriptorSets[1]);
					}
					if (weapon.DamageDescriptorSets.Count > 2)
					{
						DamageTypeSelectorViewModel3.SetFromDamageDescriptorSet(weapon.DamageDescriptorSets[2]);
					}

					WeaponName = weapon.Name;
					AbilityDamage = weapon.AbilityDamage;
					SelectedAbility = Methods.GetAbilityString(weapon.Ability);
					AbilityDamageValue = weapon.AbilityDamageValue.ToString();
				}
				else
				{
					Reset();
				}
			}
		}

		private void Reset()
		{
			WeaponName = "";
			DamageTypeSelectorViewModel1.SetFromDamageDescriptorSet(new Model.DamageDescriptorSet());
			DamageTypeSelectorViewModel2.SetFromDamageDescriptorSet(new Model.DamageDescriptorSet());
			DamageTypeSelectorViewModel3.SetFromDamageDescriptorSet(new Model.DamageDescriptorSet());
			AbilityDamage = false;
		}

		public string SelectedAbility
		{
			get { return _selectedAbility; }
			set { SetField(ref _selectedAbility, value); }
		}

		public string WeaponName
		{
			get { return _weaponName; }
			set { SetField(ref _weaponName, value); }
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

		public Types.Ability Ability
		{
			get { return Methods.GetAbilityFromString(SelectedAbility); }
		}

		public List<string> Abilities
		{
			get { return Constants.AbilityStrings; }
		}

		private List<Tuple<string, Model.Weapon>> GetFlatWeaponList()
		{
			List<Tuple<string, Model.Weapon>> weapons = new List<Tuple<string, Model.Weapon>>();
			foreach (Model.WeaponSet weaponSet in WeaponList)
			{
				foreach (Model.Weapon weapon in weaponSet.Weapons)
				{
					weapons.Add(Tuple.Create(weaponSet.Owner, weapon));
				}
			}
			return weapons;
		}

		private List<string> GetWeaponStringList()
		{
			List<string> weapons = new List<string>();
			foreach (Tuple<string, Model.Weapon> weapon in GetFlatWeaponList())
			{
				weapons.Add(weapon.Item1 + " - " + weapon.Item2.Name);
			}
			return weapons;
		}

		private int GetWeaponIndexInList(Model.Weapon weapon)
		{
			List<Tuple<string, Model.Weapon>> weaponList = GetFlatWeaponList();
			for (int index = 0; index < weaponList.Count; ++index)
			{
				if (weapon.Name.Equals(weaponList[index].Item2.Name))
				{
					return index;
				}
			}

			return -1;
		}

		public List<string> Weapons
		{
			get
			{
				List<string> weapons = GetWeaponStringList();
				weapons.Insert(0, "");
				return weapons;
			}
		}

		public Model.Weapon GetWeapon()
		{
			Model.Weapon weapon = new Model.Weapon();
			weapon.Name = WeaponName;
			weapon.DamageDescriptorSets.Add(DamageTypeSelectorViewModel1.GetDamageDescriptorSet());
			weapon.DamageDescriptorSets.Add(DamageTypeSelectorViewModel2.GetDamageDescriptorSet());
			weapon.DamageDescriptorSets.Add(DamageTypeSelectorViewModel3.GetDamageDescriptorSet());
			weapon.AbilityDamage = AbilityDamage;
			if (AbilityDamage)
			{
				weapon.Ability = Ability;
				weapon.AbilityDamageValue = Convert.ToInt32(AbilityDamageValue);
			}
			return weapon;
		}

		private void SetSelectedWeapon()
		{
			List<string> weapons = GetWeaponStringList();
			for (int i = 0; i < weapons.Count; ++i)
			{
				int splitAt = weapons[i].IndexOf(" - ");
				string actorName = weapons[i].Substring(0, splitAt);
				if (CurrentActorName == actorName)
				{
					SelectedWeapon = i + 1;
					break;
				}
			}
		}

		public Model.IHitPointChange GetHit(Model.CreatureAttributes creatureAttributes)
		{
			Model.IHitPointChange hitPointChange = null;
			bool askForInput = true;
			string feedback = null;
			while (askForInput)
			{
				SetSelectedWeapon();

				View.HitPointChangeDialog damageDialog = new View.HitPointChangeDialog(feedback);
				damageDialog.DataContext = this;
				if (damageDialog.ShowDialog() == true)
				{
					List<int> damage = new List<int>();
					try
					{
						if (Healing != "")
						{
							int healing = Convert.ToInt32(Healing);
							hitPointChange = new Model.Heal(healing);
						}
						else
						{
							if (Damage1 != "")
							{
								damage.Add(Convert.ToInt32(Damage1));
							}
							if (Damage2 != "")
							{
								damage.Add(Convert.ToInt32(Damage2));
							}
							if (Damage3 != "")
							{
								damage.Add(Convert.ToInt32(Damage3));
							}

							Model.Weapon weapon = GetWeapon();

							hitPointChange = new Model.Hit(damage, weapon, creatureAttributes);
						}

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

			return hitPointChange;
		}
	}
}
