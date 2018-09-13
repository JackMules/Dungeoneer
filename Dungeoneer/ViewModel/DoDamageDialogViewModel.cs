using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class DoDamageDialogViewModel : BaseViewModel
	{
		public DoDamageDialogViewModel(FullyObservableCollection<Model.WeaponSet> weaponList)
		{
			_weaponList = weaponList;
			_damage = "";
			_selectedWeapon = 0;
			_damageTypeSelectorViewModel = new DamageTypeSelectorViewModel();
			_abilityDamage = false;
		}

		private FullyObservableCollection<Model.WeaponSet> _weaponList;
		private string _damage;
		private int _selectedWeapon;
		private DamageTypeSelectorViewModel _damageTypeSelectorViewModel;
		private bool _abilityDamage;
		private string _abilityDamageValue;

		public DamageTypeSelectorViewModel DamageTypeSelectorViewModel
		{
			get { return _damageTypeSelectorViewModel; }
			set
			{
				_damageTypeSelectorViewModel = value;
				NotifyPropertyChanged("DamageTypeSelectorViewModel");
			}
		}

		public FullyObservableCollection<Model.WeaponSet> WeaponList
		{
			get { return _weaponList; }
			set
			{
				_weaponList = value;
				NotifyPropertyChanged("WeaponList");
			}
		}

		public string Damage
		{
			get { return _damage; }
			set
			{
				_damage = value;
				NotifyPropertyChanged("Damage");
			}
		}

		public int SelectedWeapon
		{
			get { return _selectedWeapon; }
			set
			{
				_selectedWeapon = value;
				NotifyPropertyChanged("SelectedWeapon");
				if (SelectedWeapon != 0)
				{
					Model.Weapon weapon = GetFlatWeaponList().ElementAt(SelectedWeapon - 1).Item2;
					DamageTypeSelectorViewModel.SetFromDamageDescriptorSet(weapon.DamageDescriptorSet);
					AbilityDamage = weapon.AbilityDamage;
					SelectedAbility = Abilities.IndexOf(Methods.GetAbilityString(weapon.Ability));
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
			DamageTypeSelectorViewModel.SetFromDamageDescriptorSet(new Model.DamageDescriptorSet());
			AbilityDamage = false;
		}

		public int SelectedAbility { get; set; }

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
			get { return Methods.GetAbilityFromString(Abilities.ElementAt(SelectedAbility)); }
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
			weapon.DamageDescriptorSet = DamageTypeSelectorViewModel.GetDamageDescriptorSet();
			weapon.AbilityDamage = AbilityDamage;
			weapon.Ability = Ability;
			weapon.AbilityDamageValue = Convert.ToInt32(AbilityDamageValue);
			return weapon;
		}

		public Model.Creature DoDamage(Model.Creature creature)
		{
			bool askForInput = true;
			string feedback = null;
			while (askForInput)
			{
				View.DoDamageDialog damageDialog = new View.DoDamageDialog(feedback);
				damageDialog.DataContext = this;
				if (damageDialog.ShowDialog() == true)
				{
					try
					{
						int damage = Convert.ToInt32(Damage);
						Model.Weapon weapon = GetWeapon();
						creature.HitPoints = Methods.DoHitPointDamage(creature, damage, weapon);

						if (weapon.AbilityDamage)
						{
							if (weapon.Ability == Types.Ability.Constitution)
							{
								int oldModifier = Methods.GetAbilityModifier(creature.Constitution);
								creature.Constitution -= weapon.AbilityDamageValue;
								int newModifier = Methods.GetAbilityModifier(creature.Constitution);

								int change = oldModifier - newModifier;
								creature.HitPoints -= creature.HitDice * change;
							}
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

			return creature;
		}
	}
}
