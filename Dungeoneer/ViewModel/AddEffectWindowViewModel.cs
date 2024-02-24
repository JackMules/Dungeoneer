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
		private bool _timedEffect;
		private int _selectedAbilityIndex;
		private string _customText;

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
				NotifyPropertyChanged("TextEffect");
			}
		}

		public bool TimedEffect
		{
			get { return _timedEffect; }
			set { SetField(ref _timedEffect, value); }
		}

		public bool ValueEffect
		{
			get { return Methods.IsValueEffect(SelectedEffectType); }
		}

		public bool AbilityEffect
		{
			get { return Methods.IsAbilityEffect(SelectedEffectType); }
		}

		public bool TextEffect
		{
			get { return Methods.IsTextEffect(SelectedEffectType); }
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

		private Types.Effect SelectedEffectType
		{
			get { return Methods.GetEffectTypeFromString(EffectNames[SelectedEffectIndex]); }
		}

		private Types.Ability SelectedAbility
		{
			get { return Methods.GetAbilityFromString(Abilities[SelectedAbilityIndex]); }
		}

		public string Value
		{
			get { return _value; }
			set { SetField(ref _value, value); }
		}

		public string Duration
		{
			get { return _duration; }
			set 
			{
				SetField(ref _duration, value);
				TimedEffect = IntDuration > 0;
			}
		}

		public string CustomText
		{
			get { return _customText; }
			set { SetField(ref _customText, value); }
		}

		private int IntDuration
        {
			get
            {
				int duration = 0;
				try
				{
					duration = Convert.ToInt32(Duration);
				}
				catch (FormatException) { }
				return duration;
            }
        }

		private Model.Effect.Effect CreateEffect()
		{
			Model.Effect.Effect effect;
			int duration = IntDuration;
			if (!TimedEffect || duration == 0)
			{
				if (AbilityEffect && ValueEffect)
				{
					effect = new Model.Effect.AbilityValueEffect(SelectedEffectType, SelectedAbility, Convert.ToInt32(Value));
				}
				else if (ValueEffect)
				{
					effect = new Model.Effect.ValueEffect(SelectedEffectType, Convert.ToInt32(Value));
				}
				else if (TextEffect)
				{
					effect = new Model.Effect.TextEffect(SelectedEffectType, CustomText);
				}
				else
				{
					effect = new Model.Effect.Effect(SelectedEffectType);
				}
			}
			else
			{
				if (AbilityEffect && ValueEffect)
				{
					effect = new Model.Effect.TimedAbilityValueEffect(SelectedEffectType, SelectedAbility, 
						Convert.ToInt32(Value), duration);
				}
				else if (ValueEffect)
				{
					effect = new Model.Effect.TimedValueEffect(SelectedEffectType, Convert.ToInt32(Value), duration);
				}
				else if (TextEffect)
				{
					effect = new Model.Effect.TimedTextEffect(SelectedEffectType, CustomText, duration);
				}
				else
				{
					effect = new Model.Effect.TimedEffect(SelectedEffectType, duration);
				}
			}

			return effect;
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
						effect = CreateEffect();
						askForInput = false;
					}
					catch (ArgumentException e)
					{
						feedback = e.Message;
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
