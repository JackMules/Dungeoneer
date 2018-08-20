using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Dungeoneer.ViewModel
{
	public class CreatureViewModel : NonPlayerActorViewModel
	{
		public CreatureViewModel()
		{
			_openDamageDialog = new Command(ExecuteOpenDamageDialog);
		}

		private Command _openDamageDialog;

		public new Model.Creature Actor
		{
			get { return _actor as Model.Creature; }
			set
			{
				_actor = value;
				NotifyPropertyChanged("Actor");
			}
		}

		public string ArmourClass
		{
			get { return Actor.ArmourClass.ToString(); }
			set
			{
				Actor.ArmourClass = Convert.ToInt32(value);
				NotifyPropertyChanged("ArmourClass");
			}
		}

		public string HitPoints
		{
			get { return Actor.HitPoints.ToString(); }
			set
			{
				Actor.HitPoints = Convert.ToInt32(value);
				NotifyPropertyChanged("HitPoints");
				Active = (Actor.HitPoints > 0);
				BackgroundColor = Active ? Colors.LightGray : Colors.DarkRed;
			}
		}

		public Command OpenDamageDialog
		{
			get { return _openDamageDialog; }
		}

		private void ExecuteOpenDamageDialog()
		{
			bool askForInput = true;
			string feedback = null;
			while (askForInput)
			{
				View.DamageDialog damageDialog = new View.DamageDialog(feedback);
				if (damageDialog.ShowDialog() == true)
				{
					try
					{
						int damage = Convert.ToInt32(damageDialog.Damage);
						Utility.Types.DamageType damageType = Utility.Methods.GetDamageTypeFromString(damageDialog.DamageType);
						HitPoints = Utility.Methods.CalculateNewHitPoints(Actor, damage, damageType).ToString();
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
		}
	}
}
