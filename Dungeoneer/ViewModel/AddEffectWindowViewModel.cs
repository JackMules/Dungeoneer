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
			_selectedEffect = null;
		}

		private int _selectedIndex;
		private Model.Effect.Effect _selectedEffect;

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
				Types.Effect effectType = Methods.GetEffectTypeFromString(EffectNames[_selectedIndex]);
				SelectedEffect = Model.Effect.EffectFactory.GetEffect(effectType);
			}
		}

		public Model.Effect.Effect SelectedEffect
		{
			get { return _selectedEffect; }
			set
			{
				_selectedEffect = value;
				NotifyPropertyChanged("SelectedEffect");
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
						effect = SelectedEffect;
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
