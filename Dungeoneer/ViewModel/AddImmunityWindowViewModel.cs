using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class AddImmunityWindowViewModel : BaseViewModel
	{
		public AddImmunityWindowViewModel(Model.DamageDescriptorSet immunity = null)
		{
			_damageTypeSelectorViewModel = new DamageTypeSelectorViewModel();

			if (immunity != null)
			{
				_damageTypeSelectorViewModel.SetFromDamageDescriptorSet(immunity);
			}
		}
		
		private DamageTypeSelectorViewModel _damageTypeSelectorViewModel;

		public DamageTypeSelectorViewModel DamageTypeSelectorViewModel
		{
			get { return _damageTypeSelectorViewModel; }
			set { SetField(ref _damageTypeSelectorViewModel, value); }
		}

		public Model.DamageDescriptorSet GetImmunity()
		{
			bool askForInput = true;
			string feedback = null;
			Model.DamageDescriptorSet immunity = null;
			while (askForInput)
			{
				View.AddImmunityWindow addImmunityWindow = new View.AddImmunityWindow(feedback);
				addImmunityWindow.DataContext = this;

				if (addImmunityWindow.ShowDialog() == true)
				{
					immunity = DamageTypeSelectorViewModel.GetDamageDescriptorSet();
					askForInput = false;
				}
				else
				{
					askForInput = false;
				}
			}

			return immunity;
		}
	}
}
