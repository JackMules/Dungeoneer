using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class AddDamageReductionWindowViewModel : BaseViewModel
	{
		public AddDamageReductionWindowViewModel(Model.DamageReduction dr = null)
		{
			_damageTypeSelectorViewModel = new DamageTypeSelectorViewModel();

			if (dr != null)
			{
				_value = dr.Value.ToString();
				_damageTypeSelectorViewModel.SetFromDamageDescriptorSet(dr.DamageTypes);
			}
		}
		
		private string _value;
		private DamageTypeSelectorViewModel _damageTypeSelectorViewModel;

		public string Value
		{
			get { return _value; }
			set { SetField(ref _value, value); }
		}

		public DamageTypeSelectorViewModel DamageTypeSelectorViewModel
		{
			get { return _damageTypeSelectorViewModel; }
			set { SetField(ref _damageTypeSelectorViewModel, value); }
		}

		public Model.DamageReduction GetDamageReduction()
		{
			bool askForInput = true;
			string feedback = null;
			Model.DamageReduction dr = null;
			while (askForInput)
			{
				View.AddDamageReductionWindow addDamageReductionWindow = new View.AddDamageReductionWindow(feedback);
				addDamageReductionWindow.DataContext = this;

				if (addDamageReductionWindow.ShowDialog() == true)
				{
					try
					{
						dr = new Model.DamageReduction
						{
							Value = Convert.ToInt32(Value),
							DamageTypes = DamageTypeSelectorViewModel.GetDamageDescriptorSet(),
						};
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

			return dr;
		}
	}
}
