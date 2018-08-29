using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class DoDamageDialogViewModel2 : BaseViewModel
	{
		public DoDamageDialogViewModel2()
		{
			_damage = "";
			_selectedWeapon = 0;
			_adamantine = false;
			_coldIron = false;
			_magic = false;
			_silver = false;
			_subdual = false;
			_good = false;
			_evil = false;
			_law = false;
			_chaos = false;
			_acid = false;
			_bludgeoning = false;
			_cold = false;
			_divine = false;
			_electricity = false;
			_fire = false;
			_force = false;
			_negativeEnergy = false;
			_piercing = false;
			_positiveEnergy = false;
			_slashing = false;
			_sonic = false;
			_untyped = false;
		}

		private string _damage;
		private int _selectedWeapon;
		private bool _adamantine;
		private bool _coldIron;
		private bool _magic;
		private bool _silver;
		private bool _subdual;
		private bool _good;
		private bool _evil; 
		private bool _law; 
		private bool _chaos;
		private bool _acid;
		private bool _bludgeoning;
		private bool _cold;
		private bool _divine;
		private bool _electricity;
		private bool _fire;
		private bool _force;
		private bool _negativeEnergy;
		private bool _piercing;
		private bool _positiveEnergy;
		private bool _slashing;
		private bool _sonic;
		private bool _untyped;

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

		public bool ColdIron
		{
			get { return _coldIron; }
			set
			{
				_coldIron = value;
				NotifyPropertyChanged("ColdIron");
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

		public bool Silver
		{
			get { return _silver; }
			set
			{
				_silver = value;
				NotifyPropertyChanged("Silver");
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

		public bool Good
		{
			get { return _good; }
			set
			{
				_good = value;
				NotifyPropertyChanged("Good");
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

		public bool Law
		{
			get { return _law; }
			set
			{
				_law = value;
				NotifyPropertyChanged("Law");
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

		public bool Acid
		{
			get { return _acid; }
			set
			{
				_acid = value;
				NotifyPropertyChanged("Acid");
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

		public bool Cold
		{
			get { return _cold; }
			set
			{
				_cold = value;
				NotifyPropertyChanged("Cold");
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

		public bool PostitiveEnergy
		{
			get { return _positiveEnergy; }
			set
			{
				_positiveEnergy = value;
				NotifyPropertyChanged("PositiveEnergy");
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

		public List<string> Weapons
		{
			get
			{
				return GetPlayerWeapons();
			}
		}

		public string GetNewHitPoints(Model.Creature creature)
		{
			string hitPoints = creature.HitPoints.ToString();
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
						hitPoints = CalculateNewHitPoints(creature, damage, damageType).ToString();
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

			return hitPoints;
		}

		public static int CalculateNewHitPoints(Model.Creature creature, int damage, Types.Damage damageType)
		{


			Model.DamageReduction dr = creature.DamageReductions?.SingleOrDefault(i => i.DamageType == damageType);

			if (dr != null)
			{
				damage -= dr.Value;

				if (damage < 0)
				{
					damage = 0;
				}
			}

			return creature.HitPoints - damage;
		}
	}
}
