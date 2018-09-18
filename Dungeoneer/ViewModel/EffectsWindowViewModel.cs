using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class EffectsWindowViewModel : BaseViewModel
	{
		public EffectsWindowViewModel(FullyObservableCollection<Model.Effect.Effect> effects)
		{
			_effects = effects;
			_addEffect = new Command(ExecuteAddEffect);
			_removeEffect = new Command(ExecuteRemoveEffect);
		}

		private FullyObservableCollection<Model.Effect.Effect> _effects;
		private Command _addEffect;
		private Command _removeEffect;

		public FullyObservableCollection<Model.Effect.Effect> Effects
		{
			get { return _effects; }
			set
			{
				_effects = value;
				NotifyPropertyChanged("Effects");
			}
		}

		public int SelectedEffect { get; set; }

		public void Show()
		{
			View.EffectsWindow effectsWindow = new View.EffectsWindow();
			effectsWindow.Show();
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
			}
		}

		private void ExecuteRemoveEffect()
		{
			Effects.RemoveAt(SelectedEffect);
		}
	}
}
