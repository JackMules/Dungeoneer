using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class CreatureInitiativeViewModel : NonPlayerActorInitiativeViewModel
	{
		public CreatureInitiativeViewModel()
		{
			_doDamage = new Command(ExecuteDoDamage);
			_actor = new Model.Creature();
		}

		private Command _doDamage;

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

		public Command DoDamage
		{
			get { return _doDamage; }
		}

		private void ExecuteDoDamage()
		{
			DoDamageDialogViewModel doDamageDialogViewModel = new DoDamageDialogViewModel();
			HitPoints = doDamageDialogViewModel.GetNewHitPoints(Actor);
		}

		public override void ReadXML(XmlNode xmlNode)
		{
			Model.Creature creature = new Model.Creature();
			creature.ReadXML(xmlNode);
			Actor = creature;
		}
	}
}
