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

			encounterViewModel.OnInitiativeTrackChange += OnInitiativeTrackChange;
			if (encounterViewModel.InitiativeTrack.Count > 0)
			{
				_currentActorName = encounterViewModel.InitiativeTrack.First().ActorViewModel.ActorName;
			}
		}

		protected override void InitCommands()
		{
			base.InitCommands();
			_addEffect = new Command(ExecuteAddEffect);
			_removeEffect = new Command(ExecuteRemoveEffect);
			_addHitPointChange = new Command(ExecuteAddHitPointChange);
			_removeHitPointChange = new Command(ExecuteRemoveHitPointChange);
			_incrementAttacksOfOpportunity = new Command(ExecuteIncrementAttacksOfOpportunity);
			_decrementAttacksOfOpportunity = new Command(ExecuteDecrementAttacksOfOpportunity, Threatening);
		}

		private FullyObservableCollection<Model.WeaponSet> _weaponList;
		private string _currentActorName;
		private Command _addEffect;
		private Command _removeEffect;
		private Command _addHitPointChange;
		private Command _removeHitPointChange;
		private Command _incrementAttacksOfOpportunity;
		private Command _decrementAttacksOfOpportunity;

		public int SelectedEffect { get; set; }
		public int SelectedHitPointChange { get; set; }

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

		public FullyObservableCollection<Model.HitPointChange> HitPointChanges
		{
			get { return Actor.HitPointChanges; }
			set
			{
				Actor.HitPointChanges = value;
				NotifyPropertyChanged("HitPointChanges");
			}
		}

		public string Strength
		{
			get { return Actor.Strength.ToString(); }
		}

		public string Dexterity
		{
			get { return Actor.Dexterity.ToString(); }
		}

		public string Constitution
		{
			get { return Actor.Constitution.ToString(); }
		}

		public string Intelligence
		{
			get { return Actor.Intelligence.ToString(); }
		}

		public string Wisdom
		{
			get { return Actor.Wisdom.ToString(); }
		}

		public string Charisma
		{
			get { return Actor.Charisma.ToString(); }
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
			get { return String.Join(", ", Actor.SpecialQualities); }
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

		public void OnInitiativeTrackChange(string actorName)
		{
			CurrentActorName = actorName;
		}

		public FullyObservableCollection<Model.WeaponSet> WeaponList
		{
			get { return _weaponList; }
			set { SetField(ref _weaponList, value); }
		}

		public string CurrentActorName
		{
			get { return _currentActorName; }
			set { SetField(ref _currentActorName, value); }
		}

		public new Model.Creature Actor
		{
			get { return _actor as Model.Creature; }
			set
			{
				if (SetField(ref _actor, value))
				{
					ActorUpdated();
				}
			}
		}


		public string AttacksOfOpportunity
		{
			get { return Actor.AttacksOfOpportunity.ToString(); }
		}

		public bool Threatening
		{
			get { return Actor.Threatening; }
		}

		public string ArmorClass
		{
			get { return Actor.ArmorClass.ToString(); }
		}

		public string TouchArmorClass
		{
			get { return Actor.TouchArmorClass.ToString(); }
		}

		public string FlatFootedArmorClass
		{
			get { return Actor.FlatFootedArmorClass.ToString(); }
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
			AbilitiesUpdated();
			NotifyPropertyChanged("AttacksOfOpportunity");
		}

		public void AbilitiesUpdated()
		{
			NotifyPropertyChanged("Strength");
			NotifyPropertyChanged("Dexterity");
			NotifyPropertyChanged("Constitution");
			NotifyPropertyChanged("Intelligence");
			NotifyPropertyChanged("Wisdom");
			NotifyPropertyChanged("Charisma");
		}

		private void ArmorClassUpdated()
		{
			NotifyPropertyChanged("ArmorClass");
			NotifyPropertyChanged("TouchArmorClass");
			NotifyPropertyChanged("FlatFootedArmorClass");
			NotifyPropertyChanged("Threatening");
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

		public Command AddHitPointChange
		{
			get { return _addHitPointChange; }
		}

		public Command RemoveHitPointChange
		{
			get { return _removeHitPointChange; }
		}

		private void ExecuteAddHitPointChange()
		{
			HitPointChangeDialogViewModel hitPointChangeDialogViewModel = new HitPointChangeDialogViewModel(WeaponList, CurrentActorName);
			Model.HitPointChange hitPointChange = hitPointChangeDialogViewModel.GetHit(Actor.GetEffectiveAttributes());
			if (hitPointChange != null &&
				(hitPointChange is Model.Heal ||
				hitPointChange is Model.Hit))
			{
				Actor.AddHitPointChange(hitPointChange);
				ActorUpdated();
			}
		}

		private void ExecuteRemoveHitPointChange()
		{
			if (SelectedHitPointChange >= 0 && SelectedHitPointChange < HitPointChanges.Count)
			{
				HitPointChanges.RemoveAt(SelectedHitPointChange);
				ActorUpdated();
			}
		}

		public Command IncrementAttacksOfOpportunity
		{
			get { return _incrementAttacksOfOpportunity; }
		}

		public Command DecrementAttacksOfOpportunity
		{
			get { return _decrementAttacksOfOpportunity; }
		}

		private void ExecuteIncrementAttacksOfOpportunity()
		{
			Actor.IncrementAttacksOfOpportunity();
			ActorUpdated();
		}

		private void ExecuteDecrementAttacksOfOpportunity()
		{
			Actor.DecrementAttacksOfOpportunity();
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
