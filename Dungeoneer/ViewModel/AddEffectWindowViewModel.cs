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
				SetupView(Methods.GetEffectTypeFromString(EffectNames[_selectedIndex]));
			}
		}

		public Types.Effect SelectedEffect
		{
			get { return Methods.GetEffectTypeFromString(EffectNames[_selectedIndex]); }
		}

		private void ResetView()
		{

		}

		private void SetupView(Types.Effect effectType)
		{
			
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
						effect = Model.Effect.EffectFactory.GetEffect(SelectedEffect);
						
					}
					catch (FormatException)
					{

					}
				}
			}

			return effect;
		}
	}
}
