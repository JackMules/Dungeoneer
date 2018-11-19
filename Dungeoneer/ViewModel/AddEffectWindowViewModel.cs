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

		private int _selectedIndex;
		private string _value;
		private string _duration;

		public List<string> EffectNames
		{
			get { return Constants.EffectStrings; }
		}

		public int SelectedIndex
		{
			get { return _selectedIndex; }
			set
			{
				_selectedIndex = value;
				NotifyPropertyChanged("SelectedIndex");
				NotifyPropertyChanged("SelectedEffectType");
				NotifyPropertyChanged("TimedEffect");
			}
		}

		public bool TimedEffect
		{
			get { return GetSelectedEffect() is Model.Effect.TimedEffect; }
		}

		private Model.Effect.Effect GetSelectedEffect()
		{
			return Model.Effect.EffectFactory.GetEffect(SelectedEffectType);
		}

		private Types.Effect SelectedEffectType
		{
			get { return Methods.GetEffectTypeFromString(EffectNames[_selectedIndex]); }
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
