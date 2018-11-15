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
	public class CreatureInitiativeViewModel : ActorInitiativeViewModel
	{
		public CreatureInitiativeViewModel(Model.Creature creature, EncounterViewModel encounterViewModel)
		{
			_actor = new Model.Creature(creature);
			encounterViewModel.OnWeaponListChange += OnWeaponListChange;
			_weaponList = encounterViewModel.WeaponList;
			InitCommands();
		}

		public CreatureInitiativeViewModel(XmlNode creatureXml, EncounterViewModel encounterViewModel)
		{
			_actor = new Model.Creature(creatureXml);
			encounterViewModel.OnWeaponListChange += OnWeaponListChange;
			_weaponList = encounterViewModel.WeaponList;
			InitCommands();
		}

		protected override void InitCommands()
		{
			base.InitCommands();
			_doDamage = new Command(ExecuteDoDamage);
			_showEffectsWindow = new Command(ExecuteShowEffectsWindow);
		}

		private FullyObservableCollection<Model.WeaponSet> _weaponList;
		private EffectsWindowViewModel _effectsWindowViewModel;
		private Command _doDamage;
		private Command _showEffectsWindow;

		public float ChallengeRating
		{
			get { return Actor.ChallengeRating; }
			set
			{
				Actor.ChallengeRating = value;
				NotifyPropertyChanged("ChallengeRating");
			}
		}

		public FullyObservableCollection<Model.AttackSet> AttackSets
		{
			get { return Actor.AttackSets; }
			set
			{
				Actor.AttackSets = value;
				NotifyPropertyChanged("AttackSets");
			}
		}

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
			get { return Actor.ArmorClass.ToString(); }
		}

		public string HitPoints
		{
			get { return Actor.HitPoints.ToString(); }
		}

		public override void ActorUpdated()
		{
			base.ActorUpdated();
			ArmorClassUpdated();
			HitPointsUpdated();
			AttackSetsUpdated();
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

		private void AttackSetsUpdated()
		{
			NotifyPropertyChanged("AttackSets");
		}

		public Command DoDamage
		{
			get { return _doDamage; }
		}

		private void ExecuteDoDamage()
		{
			DoDamageDialogViewModel doDamageDialogViewModel = new DoDamageDialogViewModel(WeaponList);
			doDamageDialogViewModel.DoDamage(Actor);
			HitPointsUpdated();
		}

		public Command ShowEffectsWindow
		{
			get { return _showEffectsWindow; }
		}

		private void ExecuteShowEffectsWindow()
		{
			_effectsWindowViewModel = new EffectsWindowViewModel(Actor.Effects);
			_effectsWindowViewModel.ShowDialog();
			Actor.Effects = _effectsWindowViewModel.Effects;
			ActorUpdated();
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
			Model.Creature creature = new Model.Creature(xmlNode);
			Actor = creature;
		}
	}
}
