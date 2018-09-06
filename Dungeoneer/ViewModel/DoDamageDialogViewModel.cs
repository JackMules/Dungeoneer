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
			_acid = false;
			_adamantine = false;
			_bludgeoning = false;
			_chaos = false;
			_cold = false;
			_coldIron = false;
			_divine = false;
			_electricity = false;
			_epic = false;
			_evil = false;
			_fire = false;
			_force = false;
			_good = false;
			_law = false;
			_magic = false;
			_negativeEnergy = false;
			_piercing = false;
			_positiveEnergy = false;
			_silver = false;
			_slashing = false;
			_subdual = false;
			_sonic = false;
		}

		private FullyObservableCollection<Model.WeaponSet> _weaponList;
		private string _damage;
		private int _selectedWeapon;

		private bool _acid;
		private bool _adamantine;
		private bool _bludgeoning;
		private bool _chaos;
		private bool _cold;
		private bool _coldIron;
		private bool _divine;
		private bool _electricity;
		private bool _epic;
		private bool _evil; 
		private bool _fire;
		private bool _force;
		private bool _good;
		private bool _law; 
		private bool _magic;
		private bool _negativeEnergy;
		private bool _piercing;
		private bool _positiveEnergy;
		private bool _silver;
		private bool _slashing;
		private bool _sonic;
		private bool _subdual;

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

					Acid						= weapon.DamageQualities.Exists(d => d == Types.Damage.Acid);
					Adamantine			= weapon.DamageQualities.Exists(d => d == Types.Damage.Adamantine);
					Bludgeoning			= weapon.DamageQualities.Exists(d => d == Types.Damage.Bludgeoning);
					Chaos						= weapon.DamageQualities.Exists(d => d == Types.Damage.Chaos);
					Cold						= weapon.DamageQualities.Exists(d => d == Types.Damage.Cold);
					ColdIron				= weapon.DamageQualities.Exists(d => d == Types.Damage.ColdIron);
					Divine					= weapon.DamageQualities.Exists(d => d == Types.Damage.Divine);
					Electricity			= weapon.DamageQualities.Exists(d => d == Types.Damage.Electricity);
					Epic						= weapon.DamageQualities.Exists(d => d == Types.Damage.Epic);
					Evil						= weapon.DamageQualities.Exists(d => d == Types.Damage.Evil);
					Fire						= weapon.DamageQualities.Exists(d => d == Types.Damage.Fire);
					Force						= weapon.DamageQualities.Exists(d => d == Types.Damage.Force);
					Good						= weapon.DamageQualities.Exists(d => d == Types.Damage.Good);
					Law							= weapon.DamageQualities.Exists(d => d == Types.Damage.Law);
					Magic						= weapon.DamageQualities.Exists(d => d == Types.Damage.Magic);
					NegativeEnergy	= weapon.DamageQualities.Exists(d => d == Types.Damage.NegativeEnergy);
					Piercing				= weapon.DamageQualities.Exists(d => d == Types.Damage.Piercing);
					PositiveEnergy	= weapon.DamageQualities.Exists(d => d == Types.Damage.PositiveEnergy);
					Silver					= weapon.DamageQualities.Exists(d => d == Types.Damage.Silver);
					Slashing				= weapon.DamageQualities.Exists(d => d == Types.Damage.Slashing);
					Sonic						= weapon.DamageQualities.Exists(d => d == Types.Damage.Sonic);
					Subdual					= weapon.DamageQualities.Exists(d => d == Types.Damage.Subdual);
				}
			}
		}

		public bool Acid
		{
			get { return _acid; }
			set
			{
				_acid = value;
				NotifyPropertyChanged("Acid");
			}
		}

		public bool Adamantine
		{
			get { return _adamantine; }
			set
			{
				_adamantine = value;
				NotifyPropertyChanged("Adamantine");
			}
		}

		public bool Bludgeoning
		{
			get { return _bludgeoning; }
			set
			{
				_bludgeoning = value;
				NotifyPropertyChanged("Bludgeoning");
			}
		}

		public bool Chaos
		{
			get { return _chaos; }
			set
			{
				_chaos = value;
				NotifyPropertyChanged("Chaos");
			}
		}

		public bool Cold
		{
			get { return _cold; }
			set
			{
				_cold = value;
				NotifyPropertyChanged("Cold");
			}
		}

		public bool ColdIron
		{
			get { return _coldIron; }
			set
			{
				_coldIron = value;
				NotifyPropertyChanged("ColdIron");
			}
		}

		public bool Divine
		{
			get { return _divine; }
			set
			{
				_divine = value;
				NotifyPropertyChanged("Divine");
			}
		}

		public bool Electricity
		{
			get { return _electricity; }
			set
			{
				_electricity = value;
				NotifyPropertyChanged("Electricity");
			}
		}
		public bool Epic
		{
			get { return _epic; }
			set
			{
				_epic = value;
				NotifyPropertyChanged("Epic");
			}
		}

		public bool Evil
		{
			get { return _evil; }
			set
			{
				_evil = value;
				NotifyPropertyChanged("Evil");
			}
		}

		public bool Fire
		{
			get { return _fire; }
			set
			{
				_fire = value;
				NotifyPropertyChanged("Fire");
			}
		}

		public bool Force
		{
			get { return _force; }
			set
			{
				_force = value;
				NotifyPropertyChanged("Force");
			}
		}

		public bool Good
		{
			get { return _good; }
			set
			{
				_good = value;
				NotifyPropertyChanged("Good");
			}
		}

		public bool Law
		{
			get { return _law; }
			set
			{
				_law = value;
				NotifyPropertyChanged("Law");
			}
		}

		public bool Magic
		{
			get { return _magic; }
			set
			{
				_magic = value;
				NotifyPropertyChanged("Magic");
			}
		}

		public bool NegativeEnergy
		{
			get { return _negativeEnergy; }
			set
			{
				_negativeEnergy = value;
				NotifyPropertyChanged("NegativeEnergy");
			}
		}

		public bool Piercing
		{
			get { return _piercing; }
			set
			{
				_piercing = value;
				NotifyPropertyChanged("Piercing");
			}
		}

		public bool PositiveEnergy
		{
			get { return _positiveEnergy; }
			set
			{
				_positiveEnergy = value;
				NotifyPropertyChanged("PositiveEnergy");
			}
		}

		public bool Silver
		{
			get { return _silver; }
			set
			{
				_silver = value;
				NotifyPropertyChanged("Silver");
			}
		}

		public bool Slashing
		{
			get { return _slashing; }
			set
			{
				_slashing = value;
				NotifyPropertyChanged("Slashing");
			}
		}

		public bool Sonic
		{
			get { return _sonic; }
			set
			{
				_sonic = value;
				NotifyPropertyChanged("Sonic");
			}
		}

		public bool Subdual
		{
			get { return _subdual; }
			set
			{
				_subdual = value;
				NotifyPropertyChanged("Subdual");
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

		public string HitPoints { get; set; }

		public FullyObservableCollection<Model.Effect.Effect> Effects { get; set; }

		public Model.Weapon GetWeapon()
		{
			Model.Weapon weapon = new Model.Weapon();
			
			if (Acid)
			{
				weapon.DamageQualities.Add(Types.Damage.Acid);
			}
			if (Adamantine)
			{
				weapon.DamageQualities.Add(Types.Damage.Adamantine);
			}
			if (Bludgeoning)
			{
				weapon.DamageQualities.Add(Types.Damage.Bludgeoning);
			}
			if (Chaos)
			{
				weapon.DamageQualities.Add(Types.Damage.Chaos);
			}
			if (Cold)
			{
				weapon.DamageQualities.Add(Types.Damage.Cold);
			}
			if (ColdIron)
			{
				weapon.DamageQualities.Add(Types.Damage.ColdIron);
			}
			if (Divine)
			{
				weapon.DamageQualities.Add(Types.Damage.Divine);
			}
			if (Electricity)
			{
				weapon.DamageQualities.Add(Types.Damage.Electricity);
			}
			if (Epic)
			{
				weapon.DamageQualities.Add(Types.Damage.Epic);
			}
			if (Evil)
			{
				weapon.DamageQualities.Add(Types.Damage.Evil);
			}
			if (Fire)
			{
				weapon.DamageQualities.Add(Types.Damage.Fire);
			}
			if (Force)
			{
				weapon.DamageQualities.Add(Types.Damage.Force);
			}
			if (Good)
			{
				weapon.DamageQualities.Add(Types.Damage.Good);
			}
			if (Law)
			{
				weapon.DamageQualities.Add(Types.Damage.Law);
			}
			if (Magic)
			{
				weapon.DamageQualities.Add(Types.Damage.Magic);
			}
			if (NegativeEnergy)
			{
				weapon.DamageQualities.Add(Types.Damage.NegativeEnergy);
			}
			if (Piercing)
			{
				weapon.DamageQualities.Add(Types.Damage.Piercing);
			}
			if (PositiveEnergy)
			{
				weapon.DamageQualities.Add(Types.Damage.PositiveEnergy);
			}
			if (Silver)
			{
				weapon.DamageQualities.Add(Types.Damage.Silver);
			}
			if (Slashing)
			{
				weapon.DamageQualities.Add(Types.Damage.Slashing);
			}
			if (Sonic)
			{
				weapon.DamageQualities.Add(Types.Damage.Sonic);
			}
			if (Subdual)
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
