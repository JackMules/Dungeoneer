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
		public CreatureInitiativeViewModel(EncounterViewModel encounterViewModel)
		{
			encounterViewModel.OnWeaponListChange += OnWeaponListChange;
			_doDamage = new Command(ExecuteDoDamage);
			_actor = new Model.Creature();
			_weaponList = encounterViewModel.WeaponList;
			_showEffectsWindow = new Command(ExecuteShowEffectsWindow);
		}

		private FullyObservableCollection<Model.WeaponSet> _weaponList;
		private Command _doDamage;
		private EffectsWindowViewModel _effectsWindowViewModel;
		private Command _showEffectsWindow;

		public void OnWeaponListChange(FullyObservableCollection<Model.WeaponSet> weaponList)
		{
			WeaponList = weaponList;
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

		public new Model.Creature Actor
		{
			get { return _actor as Model.Creature; }
			set
			{
				_actor = value;
				ActorUpdated();
			}
		}

		public string ArmorClass
		{
			get { return GetAffectedActor().ArmorClass.ToString(); }
		}

		public string HitPoints
		{
			get { return GetAffectedActor().HitPoints.ToString(); }
		}

		// Implement properties for attack set view models

		protected override void ActorUpdated()
		{
			base.ActorUpdated();
			ArmorClassUpdated();
			HitPointsUpdated();
		}

		private void ArmorClassUpdated()
		{
			NotifyPropertyChanged("ArmorClass");
		}

		private void HitPointsUpdated()
		{
			Active = (Actor.HitPoints > 0);
			BackgroundColor = Active ? Colors.LightGray : Colors.DarkRed;
			NotifyPropertyChanged("HitPoints");
		}

		public override void StartTurn()
		{
			foreach (Model.Effect.Effect effect in Effects)
			{
				if (effect.PerTurn && effect is Model.Effect.CreatureEffect)
				{
					Actor = (effect as Model.Effect.CreatureEffect).ApplyTo(Actor);
				}
			}

			base.StartTurn();
		}

		private Model.Creature GetAffectedActor()
		{
			Model.Creature affectedActor = Actor;

			foreach (Model.Effect.Effect effect in Effects)
			{
				if (!effect.PerTurn && effect is Model.Effect.CreatureEffect)
				{
					affectedActor = (effect as Model.Effect.CreatureEffect).ApplyTo(affectedActor);
				}
			}

			return affectedActor;
		}

		public Command DoDamage
		{
			get { return _doDamage; }
		}

		private void ExecuteDoDamage()
		{
			DoDamageDialogViewModel doDamageDialogViewModel = new DoDamageDialogViewModel(WeaponList);
			Model.Creature creature = doDamageDialogViewModel.DoDamage(Actor, ref _effects);
			if (creature != null)
			{
				Actor = creature;
			}
		}

		public Command ShowEffectsWindow
		{
			get { return _showEffectsWindow; }
		}

		private void ExecuteShowEffectsWindow()
		{
			_effectsWindowViewModel = new EffectsWindowViewModel(Effects);
			_effectsWindowViewModel.Show();
			Effects = _effectsWindowViewModel.Effects;
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("CreatureInitiativeViewModel");
		}

		public override void WriteActorXML(XmlWriter xmlWriter)
		{
			Actor.WriteXML(xmlWriter);
		}

		public override void ReadActorXML(XmlNode xmlNode)
		{
			Model.Creature creature = new Model.Creature();
			creature.ReadXML(xmlNode);
			Actor = creature;
		}
	}
}
