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
			_selectedDamageType = 10;
		}

		private string _damage;
		private int _selectedDamageType;

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
						Types.DamageType damageType = Methods.GetDamageTypeFromString(DamageTypes.ElementAt(SelectedDamageType));
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

		public static int CalculateNewHitPoints(Model.Creature creature, int damage, Types.DamageType damageType)
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
