using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class AddEnergyResistanceWindowViewModel : BaseViewModel
	{
		public AddEnergyResistanceWindowViewModel(Model.EnergyResistance er = null)
		{
			_energyTypeSelectorViewModel = new EnergyTypeSelectorViewModel();

			if (er != null)
			{
				_value = er.Value.ToString();

				_energyTypeSelectorViewModel.SetEnergyType(er.EnergyType);
			}
		}
		
		private string _value;
		private EnergyTypeSelectorViewModel _energyTypeSelectorViewModel;

		public string Value
		{
			get { return _value; }
			set
			{
				SetField(ref _value, value);
			}
		}

		public EnergyTypeSelectorViewModel EnergyTypeSelectorViewModel
		{
			get { return _energyTypeSelectorViewModel; }
			set
			{
				SetField(ref _energyTypeSelectorViewModel, value);
			}
		}

		public Model.EnergyResistance GetEnergyResistance()
		{
			bool askForInput = true;
			string feedback = null;
			Model.EnergyResistance dr = null;
			while (askForInput)
			{
				View.AddEnergyResistanceWindow addEnergyResistanceWindow = new View.AddEnergyResistanceWindow(feedback);
				addEnergyResistanceWindow.DataContext = this;

				if (addEnergyResistanceWindow.ShowDialog() == true)
				{
					try
					{
						dr = new Model.EnergyResistance
						{
							Value = Convert.ToInt32(Value),
							EnergyType = EnergyTypeSelectorViewModel.GetEnergyType(),
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
