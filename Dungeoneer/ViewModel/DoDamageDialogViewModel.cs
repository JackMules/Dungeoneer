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
		}

		private FullyObservableCollection<Model.WeaponSet> _weaponList;
		private string _damage;
		private int _selectedWeapon;
		private DamageTypeSelectorViewModel _damageTypeSelectorViewModel;

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
					Model.Weapon weapon = GetFlatWeaponList().ElementAt(SelectedWeapon).Item2;

					DamageTypeSelectorViewModel.Acid						= weapon.DamageQualities.Exists(d => d == Types.Damage.Acid);
					DamageTypeSelectorViewModel.Adamantine			= weapon.DamageQualities.Exists(d => d == Types.Damage.Adamantine);
					DamageTypeSelectorViewModel.Bludgeoning			= weapon.DamageQualities.Exists(d => d == Types.Damage.Bludgeoning);
					DamageTypeSelectorViewModel.Chaos						= weapon.DamageQualities.Exists(d => d == Types.Damage.Chaos);
					DamageTypeSelectorViewModel.Cold						= weapon.DamageQualities.Exists(d => d == Types.Damage.Cold);
					DamageTypeSelectorViewModel.ColdIron				= weapon.DamageQualities.Exists(d => d == Types.Damage.ColdIron);
					DamageTypeSelectorViewModel.Divine					= weapon.DamageQualities.Exists(d => d == Types.Damage.Divine);
					DamageTypeSelectorViewModel.Electricity			= weapon.DamageQualities.Exists(d => d == Types.Damage.Electricity);
					DamageTypeSelectorViewModel.Epic						= weapon.DamageQualities.Exists(d => d == Types.Damage.Epic);
					DamageTypeSelectorViewModel.Evil						= weapon.DamageQualities.Exists(d => d == Types.Damage.Evil);
					DamageTypeSelectorViewModel.Fire						= weapon.DamageQualities.Exists(d => d == Types.Damage.Fire);
					DamageTypeSelectorViewModel.Force						= weapon.DamageQualities.Exists(d => d == Types.Damage.Force);
					DamageTypeSelectorViewModel.Good						= weapon.DamageQualities.Exists(d => d == Types.Damage.Good);
					DamageTypeSelectorViewModel.Law							= weapon.DamageQualities.Exists(d => d == Types.Damage.Law);
					DamageTypeSelectorViewModel.Magic						= weapon.DamageQualities.Exists(d => d == Types.Damage.Magic);
					DamageTypeSelectorViewModel.NegativeEnergy	= weapon.DamageQualities.Exists(d => d == Types.Damage.NegativeEnergy);
					DamageTypeSelectorViewModel.Piercing				= weapon.DamageQualities.Exists(d => d == Types.Damage.Piercing);
					DamageTypeSelectorViewModel.PositiveEnergy	= weapon.DamageQualities.Exists(d => d == Types.Damage.PositiveEnergy);
					DamageTypeSelectorViewModel.Silver					= weapon.DamageQualities.Exists(d => d == Types.Damage.Silver);
					DamageTypeSelectorViewModel.Slashing				= weapon.DamageQualities.Exists(d => d == Types.Damage.Slashing);
					DamageTypeSelectorViewModel.Sonic						= weapon.DamageQualities.Exists(d => d == Types.Damage.Sonic);
					DamageTypeSelectorViewModel.Subdual					= weapon.DamageQualities.Exists(d => d == Types.Damage.Subdual);
				}
			}
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
				weapons.Add(weapon.Item1 + weapon.Item2.Name);
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
			
			if (DamageTypeSelectorViewModel.Acid)
			{
				weapon.DamageQualities.Add(Types.Damage.Acid);
			}
			if (DamageTypeSelectorViewModel.Adamantine)
			{
				weapon.DamageQualities.Add(Types.Damage.Adamantine);
			}
			if (DamageTypeSelectorViewModel.Bludgeoning)
			{
				weapon.DamageQualities.Add(Types.Damage.Bludgeoning);
			}
			if (DamageTypeSelectorViewModel.Chaos)
			{
				weapon.DamageQualities.Add(Types.Damage.Chaos);
			}
			if (DamageTypeSelectorViewModel.Cold)
			{
				weapon.DamageQualities.Add(Types.Damage.Cold);
			}
			if (DamageTypeSelectorViewModel.ColdIron)
			{
				weapon.DamageQualities.Add(Types.Damage.ColdIron);
			}
			if (DamageTypeSelectorViewModel.Divine)
			{
				weapon.DamageQualities.Add(Types.Damage.Divine);
			}
			if (DamageTypeSelectorViewModel.Electricity)
			{
				weapon.DamageQualities.Add(Types.Damage.Electricity);
			}
			if (DamageTypeSelectorViewModel.Epic)
			{
				weapon.DamageQualities.Add(Types.Damage.Epic);
			}
			if (DamageTypeSelectorViewModel.Evil)
			{
				weapon.DamageQualities.Add(Types.Damage.Evil);
			}
			if (DamageTypeSelectorViewModel.Fire)
			{
				weapon.DamageQualities.Add(Types.Damage.Fire);
			}
			if (DamageTypeSelectorViewModel.Force)
			{
				weapon.DamageQualities.Add(Types.Damage.Force);
			}
			if (DamageTypeSelectorViewModel.Good)
			{
				weapon.DamageQualities.Add(Types.Damage.Good);
			}
			if (DamageTypeSelectorViewModel.Law)
			{
				weapon.DamageQualities.Add(Types.Damage.Law);
			}
			if (DamageTypeSelectorViewModel.Magic)
			{
				weapon.DamageQualities.Add(Types.Damage.Magic);
			}
			if (DamageTypeSelectorViewModel.NegativeEnergy)
			{
				weapon.DamageQualities.Add(Types.Damage.NegativeEnergy);
			}
			if (DamageTypeSelectorViewModel.Piercing)
			{
				weapon.DamageQualities.Add(Types.Damage.Piercing);
			}
			if (DamageTypeSelectorViewModel.PositiveEnergy)
			{
				weapon.DamageQualities.Add(Types.Damage.PositiveEnergy);
			}
			if (DamageTypeSelectorViewModel.Silver)
			{
				weapon.DamageQualities.Add(Types.Damage.Silver);
			}
			if (DamageTypeSelectorViewModel.Slashing)
			{
				weapon.DamageQualities.Add(Types.Damage.Slashing);
			}
			if (DamageTypeSelectorViewModel.Sonic)
			{
				weapon.DamageQualities.Add(Types.Damage.Sonic);
			}
			if (DamageTypeSelectorViewModel.Subdual)
			{
				weapon.DamageQualities.Add(Types.Damage.Subdual);
			}

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
						creature.HitPoints = Methods.CalculateNewHitPoints(creature, damage, weapon);

						askForInput = false;
					}
					catch (FormatException)
					{
						// Failed to parse input
						feedback = "Invalid format";
					}
				}
			}

			return creature;
		}
	}
}
