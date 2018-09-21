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
		private int _selectedEnergyTypeIndex;
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
			}
		}

		public Types.Effect SelectedEffectType
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

		public int SelectedEnergyTypeIndex
		{
			get { return _selectedEnergyTypeIndex; }
			set
			{
				_selectedEnergyTypeIndex = value;
				NotifyPropertyChanged("SelectedEnergyType");
			}
		}

		public Types.Damage SelectedEnergyType
		{
			get { return Methods.GetDamageTypeFromString(Constants.EnergyTypeStrings[_selectedEnergyTypeIndex]); }
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
						effect = Model.Effect.EffectFactory.GetEffect(SelectedEffectType);
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
