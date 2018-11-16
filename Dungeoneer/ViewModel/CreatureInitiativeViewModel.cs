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

		public CreatureInitiativeViewModel(XmlNode xmlNode, EncounterViewModel encounterViewModel)
		{
			ReadXML(xmlNode);
			encounterViewModel.OnWeaponListChange += OnWeaponListChange;
			_weaponList = encounterViewModel.WeaponList;
			InitCommands();
		}

		protected override void InitCommands()
		{
			base.InitCommands();
			_doDamage = new Command(ExecuteDoDamage);
			_addEffect = new Command(ExecuteAddEffect);
			_removeEffect = new Command(ExecuteRemoveEffect);
		}

		private FullyObservableCollection<Model.WeaponSet> _weaponList;
		private Command _doDamage;
		private Command _addEffect;
		private Command _removeEffect;

		public int SelectedEffect { get; set; }

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

		public FullyObservableCollection<Model.Effect.Effect> Effects
		{
			get { return Actor.Effects; }
			set
			{
				Actor.Effects = value;
				NotifyPropertyChanged("Effects");
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
			BackgroundColor = Dead ? Colors.DarkRed : Colors.LightGray;
			NotifyPropertyChanged("HitPoints");
			NotifyPropertyChanged("Dead");
		}

		private void AttackSetsUpdated()
		{
			NotifyPropertyChanged("AttackSets");
		}

		public bool Dead
		{
			get { return Actor.HitPoints > 0; }
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
			Model.Effect.Effect effect = addEffectWindowViewModel.GetEffect();
			if (effect != null)
			{
				Effects.Add(effect);
				ActorUpdated();
			}
		}

		private void ExecuteRemoveEffect()
		{
			Effects.RemoveAt(SelectedEffect);
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
