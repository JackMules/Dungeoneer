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
			_damage1 = "";
			_damage2 = "";
			_damage3 = "";
			_selectedWeapon = 0;
			_damageTypeSelectorViewModel1 = new DamageTypeSelectorViewModel();
			_damageTypeSelectorViewModel2 = new DamageTypeSelectorViewModel();
			_damageTypeSelectorViewModel3 = new DamageTypeSelectorViewModel();
			_abilityDamage = false;
		}

		private FullyObservableCollection<Model.WeaponSet> _weaponList;
		private string _damage1;
		private string _damage2;
		private string _damage3;
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
			set
			{
				_weaponList = value;
				NotifyPropertyChanged("WeaponList");
			}
		}

		public string Damage1
		{
			get { return _damage1; }
			set
			{
				_damage1 = value;
				NotifyPropertyChanged("Damage1");
			}
		}

		public string Damage2
		{
			get { return _damage2; }
			set
			{
				_damage2 = value;
				NotifyPropertyChanged("Damage2");
			}
		}

		public string Damage3
		{
			get { return _damage3; }
			set
			{
				_damage3 = value;
				NotifyPropertyChanged("Damage3");
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
			DamageTypeSelectorViewModel1.SetFromDamageDescriptorSet(new Model.DamageDescriptorSet());
			DamageTypeSelectorViewModel2.SetFromDamageDescriptorSet(new Model.DamageDescriptorSet());
			DamageTypeSelectorViewModel3.SetFromDamageDescriptorSet(new Model.DamageDescriptorSet());
			AbilityDamage = false;
		}

		public string SelectedAbility
		{
			get { return _selectedAbility; }
			set
			{
				_selectedAbility = value;
				NotifyPropertyChanged("SelectedAbility");
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
			weapon.DamageDescriptorSets.Add(DamageTypeSelectorViewModel1.GetDamageDescriptorSet());
			weapon.DamageDescriptorSets.Add(DamageTypeSelectorViewModel2.GetDamageDescriptorSet());
			weapon.DamageDescriptorSets.Add(DamageTypeSelectorViewModel3.GetDamageDescriptorSet());
			weapon.AbilityDamage = AbilityDamage;
			weapon.Ability = Ability;
			weapon.AbilityDamageValue = Convert.ToInt32(AbilityDamageValue);
			return weapon;
		}

		public Model.Creature DoDamage(Model.Creature creature, ref FullyObservableCollection<Model.Effect.Effect> effects)
		{
			bool askForInput = true;
			string feedback = null;
			while (askForInput)
			{
				View.DoDamageDialog damageDialog = new View.DoDamageDialog(feedback);
				damageDialog.DataContext = this;
				if (damageDialog.ShowDialog() == true)
				{
					List<int> damage = new List<int> { 0, 0, 0 };
					try
					{
						if (Damage1 != "")
						{
							damage[0] = Convert.ToInt32(Damage1);
						}
						if (Damage2 != "")
						{
							damage[1] = Convert.ToInt32(Damage2);
						}
						if (Damage3 != "")
						{
							damage[2] = Convert.ToInt32(Damage3);
						}

						Model.Weapon weapon = GetWeapon();

						Model.Hit hit = new Model.Hit(damage, weapon);
						int hp = creature.HitPoints;
						creature = Methods.DoHitPointDamage(creature, hit, ref effects);

						if (creature.HitPoints != hp)
						{
							// Damage dealt, apply other effects
							if (weapon.AbilityDamage)
							{
								creature = Methods.ModifyAbilityScore(creature, weapon.Ability, -weapon.AbilityDamageValue);
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
