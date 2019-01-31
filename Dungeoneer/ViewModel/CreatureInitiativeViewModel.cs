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
			_actor = creature.Clone();
			InitWeaponList(encounterViewModel);
			InitCommands();
		}

		public CreatureInitiativeViewModel(XmlNode xmlNode, EncounterViewModel encounterViewModel)
		{
			ReadXML(xmlNode);
			InitWeaponList(encounterViewModel);
			InitCommands();
		}

		protected virtual void InitWeaponList(EncounterViewModel encounterViewModel)
		{
			encounterViewModel.OnWeaponListChange += OnWeaponListChange;
			_weaponList = encounterViewModel.WeaponList;
		}

		protected override void InitCommands()
		{
			base.InitCommands();
			_changeHitPoints = new Command(ExecuteChangeHitPoints);
			_addEffect = new Command(ExecuteAddEffect);
			_removeEffect = new Command(ExecuteRemoveEffect);
		}

		private FullyObservableCollection<Model.WeaponSet> _weaponList;
		private Command _changeHitPoints;
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

		public string CreatureInfo
		{
			get { return ActorName + " CR" + ChallengeRating.ToString(); }
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

		public string Size
		{
			get { return Methods.GetSizeString(Actor.Size); }
		}

		public string Space
		{
			get { return Actor.Space.ToString(); }
		}

		public string Reach
		{
			get { return Actor.Reach.ToString(); }
		}

		public string SpecialAttacks
		{
			get { return Actor.SpecialAttacks; }
		}

		public string SpecialQualities
		{
			get { return Actor.SpecialQualities; }
		}

		public string FortitudeSave
		{
			get { return Methods.GetSignedNumberString(Actor.FortitudeSave); }
		}

		public string ReflexSave
		{
			get { return Methods.GetSignedNumberString(Actor.ReflexSave); }
		}

		public string WillSave
		{
			get { return Methods.GetSignedNumberString(Actor.WillSave); }
		}

		public string Speed
		{
			get
			{
				return "speed " + Actor.Speed.ToString();
			}
		}

		public int SpellResistance
		{
			get { return Actor.SpellResistance; }
		}

		public bool HasSpellResistance
		{
			get { return Actor.SpellResistance > 0; }
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
			SpellResistanceUpdated();
		}

		private void ArmorClassUpdated()
		{
			NotifyPropertyChanged("ArmorClass");
		}

		private void HitPointsUpdated()
		{
			NotifyPropertyChanged("HitPoints");
			NotifyPropertyChanged("FortitudeSave");
			NotifyPropertyChanged("ReflexSave");
			NotifyPropertyChanged("WillSave");
			NotifyPropertyChanged("Dead");
		}

		private void AttackSetsUpdated()
		{
			NotifyPropertyChanged("AttackSets");
		}

		private void SpellResistanceUpdated()
		{
			NotifyPropertyChanged("SpellResistance");
			NotifyPropertyChanged("HasSpellResistance");
		}

		public bool Dead
		{
			get { return Actor.HitPoints <= 0; }
		}

		public Command ChangeHitPoints
		{
			get { return _changeHitPoints; }
		}

		private void ExecuteChangeHitPoints()
		{
			HitPointChangeDialogViewModel hitPointChangeDialogViewModel = new HitPointChangeDialogViewModel(WeaponList);
			hitPointChangeDialogViewModel.ChangeHitPoints(Actor);
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
			if (SelectedEffect >= 0 && SelectedEffect < Effects.Count)
			{
				Effects.RemoveAt(SelectedEffect);
				ActorUpdated();
			}
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
