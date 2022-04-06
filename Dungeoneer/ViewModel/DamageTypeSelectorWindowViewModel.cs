using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class DamageTypeSelectorWindowViewModel : BaseViewModel
	{
		public DamageTypeSelectorWindowViewModel(Model.DamageDescriptorSet immunity = null)
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

		public Model.DamageDescriptorSet GetDamageTypes()
		{
			bool askForInput = true;
			string feedback = null;
			Model.DamageDescriptorSet damageTypes = null;
			while (askForInput)
			{
				View.DamageTypeSelectorWindow damageTypesWindow = new View.DamageTypeSelectorWindow(feedback);
				damageTypesWindow.DataContext = this;

				if (damageTypesWindow.ShowDialog() == true)
				{
					damageTypes = DamageTypeSelectorViewModel.GetDamageDescriptorSet();
					askForInput = false;
				}
				else
				{
					askForInput = false;
				}
			}

			return damageTypes;
		}
	}
}
