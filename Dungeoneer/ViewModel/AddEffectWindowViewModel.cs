using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class AddEffectWindowViewModel : BaseViewModel
	{
		public AddEffectWindowViewModel()
		{

		}

		private int _selectedEffectIndex;
		private string _value;
		private string _duration;
		private string _ability;
		private int _selectedAbilityIndex;

		public List<string> EffectNames
		{
			get { return Constants.EffectStrings; }
		}

		public List<string> Abilities
		{
			get { return Constants.AbilityStrings; }
		}

		public int SelectedEffectIndex
		{
			get { return _selectedEffectIndex; }
			set
			{
				_selectedEffectIndex = value;
				NotifyPropertyChanged("SelectedEffectIndex");
				NotifyPropertyChanged("SelectedEffectType");
				NotifyPropertyChanged("TimedEffect");
				NotifyPropertyChanged("ValueEffect");
				NotifyPropertyChanged("AbilityEffect");
			}
		}

		public bool TimedEffect
		{
			get { return GetSelectedEffect() is Model.Effect.TimedEffect; }
		}

		public bool ValueEffect
		{
			get { return GetSelectedEffect() is Model.Effect.ValueEffect; }
		}

		public bool AbilityEffect
		{
			get { return GetSelectedEffect() is Model.Effect.AbilityEffect; }
		}

		public int SelectedAbilityIndex
		{
			get { return _selectedAbilityIndex; }
			set
			{
				_selectedAbilityIndex = value;
				NotifyPropertyChanged("SelectedAbilityIndex");
				NotifyPropertyChanged("SelectedAbility");
			}
		}

		private Model.Effect.Effect GetSelectedEffect()
		{
			return Model.Effect.EffectFactory.GetEffect(SelectedEffectType);
		}

		private Types.Effect SelectedEffectType
		{
			get { return Methods.GetEffectTypeFromString(EffectNames[_selectedEffectIndex]); }
		}

		private Types.Ability SelectedAbility
		{
			get { return Methods.GetAbilityFromString(Abilities[_selectedAbilityIndex]); }
		}

		public string Value
		{
			get { return _value; }
			set
			{
				_value = value;
				NotifyPropertyChanged("Value");
			}
		}

		public string Duration
		{
			get { return _duration; }
			set
			{
				_duration = value;
				NotifyPropertyChanged("Duration");
			}
		}

		public Model.Effect.Effect GetEffect()
		{
			bool askForInput = true;
			string feedback = null;
			Model.Effect.Effect effect = null;
			while (askForInput)
			{
				View.AddEffectWindow addEffectWindow = new View.AddEffectWindow(feedback);
				addEffectWindow.DataContext = this;

				if (addEffectWindow.ShowDialog() == true)
				{
					try
					{
						effect = GetSelectedEffect();
						if (effect is Model.Effect.TimedEffect)
						{
							(effect as Model.Effect.TimedEffect).Duration = Convert.ToInt32(Duration);
						}
						if (effect is Model.Effect.ValueEffect)
						{
							(effect as Model.Effect.ValueEffect).Value = Convert.ToInt32(Value);
						}
						if (effect is Model.Effect.AbilityEffect)
						{
							(effect as Model.Effect.AbilityEffect).Ability = SelectedAbility;
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

			return effect;
		}
	}
}
