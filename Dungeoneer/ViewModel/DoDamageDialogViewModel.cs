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
		public DoDamageDialogViewModel()
		{
			_damage = "";
			_selectedDamageType = 8;
			_adamantine = false;
			_coldIron = false;
			_magic = true;
			_silver = false;
			_subdual = false;
			_good = false;
			_evil = false;
			_law = false;
			_chaos = false;
		}

		private string _damage;
		private int _selectedDamageType;
		private bool _adamantine;
		private bool _coldIron;
		private bool _magic;
		private bool _silver;
		private bool _subdual;
		private bool _good;
		private bool _evil; 
		private bool _law; 
		private bool _chaos;

		public string Damage
		{
			get { return _damage; }
			set
			{
				_damage = value;
				NotifyPropertyChanged("Damage");
			}
		}

		public int SelectedDamageType
		{
			get { return _selectedDamageType; }
			set
			{
				_selectedDamageType = value;
				NotifyPropertyChanged("SelectedDamageType");
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

		public List<string> DamageTypes
		{
			get
			{
				return Constants.DamageTypeStrings;
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
						Types.Damage damageType = Methods.GetDamageTypeFromString(DamageTypes.ElementAt(SelectedDamageType));
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


/*			Model.DamageReduction dr = creature.DamageReductions?.SingleOrDefault(i => i.DamageType == damageType);

			if (dr != null)
			{
				damage -= dr.Value;

				if (damage < 0)
				{
					damage = 0;
				}
			}
			*/
			return creature.HitPoints - damage;
		}
	}
}
