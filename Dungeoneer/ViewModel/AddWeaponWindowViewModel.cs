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
			_effects = new FullyObservableCollection<Model.Effect>();
			_addEffect = new Command(ExecuteAddEffect);
			_removeEffect = new Command(ExecuteRemoveEffect);
			_selectedEffect = 0;
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

		private string _name;

		private FullyObservableCollection<Model.Effect> _effects;
		private int _selectedEffect;

		private Command _addEffect;
		private Command _removeEffect;

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

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public FullyObservableCollection<Model.Effect> Effects
		{
			get { return _effects; }
			set
			{
				_effects = value;
				NotifyPropertyChanged("Effects");
			}
		}

		public int SelectedEffect
		{
			get { return _selectedEffect; }
			set
			{
				_selectedEffect = value;
				NotifyPropertyChanged("SelectedEffect");
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

						foreach (EffectViewModel effectViewModel in Effects)
						{
							weapon.Effects.Add(effectViewModel.Effect);
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

			return weapon;
		}

		public Command AddEffect
		{
			get { return _addEffect; }
		}

		public Command RemoveEffect
		{
			get { return _removeEffect; }
		}

		private void ExecuteAddEffect()
		{
			AddEffectWindowViewModel addEffectWindowViewModel = new AddEffectWindowViewModel();
			Model.Effect effect = addEffectWindowViewModel.GetEffect();
			if (effect != null)
			{
				EffectViewModel effectViewModel = new EffectViewModel { Effect = effect };
				Effects.Add(effectViewModel);
			}
		}

		private void ExecuteRemoveEffect()
		{
			Effects.RemoveAt(SelectedEffect);
		}
	}
}
