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

		private EffectViewModel _effectViewModel;

		public EffectViewModel EffectViewModel
		{
			get { return _effectViewModel; }
			set
			{
				_effectViewModel = value;
				NotifyPropertyChanged("EffectViewModel");
			}
		}

		public List<string> Effects
		{
			get { return }
		}

		public List<Model.Effect.Effect> EffectList
		{
			get { return }
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
						effect = new Model.Effect.Effect();

						effect.Name = Name;
						effect.
					}
					catch (FormatException e)
					{

					}
				}
			}

			return effect;
		}
	}
}
