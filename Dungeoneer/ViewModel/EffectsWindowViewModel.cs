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
			_closeEffectsWindow = new Command(ExecuteCloseEffectsWindow);
		}

		private Command _closeEffectsWindow;
		private FullyObservableCollection<Model.Effect.Effect> _effects;
		private View.EffectsWindow _effectsWindow;
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
			_effectsWindow = new View.EffectsWindow();
			_effectsWindow.DataContext = this;
			_effectsWindow.Show();
		}

		public void ExecuteCloseEffectsWindow()
		{
			_effectsWindow.Close();
		}

		public Command CloseEffectsWindow
		{
			get { return _closeEffectsWindow; }
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
