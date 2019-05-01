using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class AddSpeedWindowViewModel : BaseViewModel
	{
		public AddSpeedWindowViewModel(Model.Speed speed = null)
		{
			if (speed != null)
			{
				SelectedMovementType = GetMovementTypeIndex(speed.MovementType);
				Distance = speed.Distance.ToString();
				SelectedManouverability = GetManouverabilityIndex(speed.Manouverability);
			}
		}
		
		private string _distance;

		private bool _enableManouverability;
		private int _selectedMovementType;
		private int _selectedManouverability;

		private int GetMovementTypeIndex(Types.Movement movementType)
		{
			for (int i = 0; i < MovementTypes.Count; ++i)
			{
				if (MovementTypes[i] == Methods.GetMovementTypeString(movementType))
				{
					return i;
				}
			}
			return 0;
		}

		public List<string> MovementTypes
		{
			get
			{
				return Constants.MovementTypeStrings;
			}
		}

		private int GetManouverabilityIndex(Types.Manouverability manouverability)
		{
			for (int i = 0; i < ManouverabilityTypes.Count; ++i)
			{
				if (ManouverabilityTypes[i] == Methods.GetManouverabilityString(manouverability))
				{
					return i;
				}
			}
			return 0;
		}

		public List<string> ManouverabilityTypes
		{
			get { return Constants.ManouverabilityStrings; }
		}

		public string Distance
		{
			get { return _distance; }
			set { SetField(ref _distance, value); }
		}

		public bool EnableManouverability
		{
			get { return _enableManouverability; }
			set { SetField(ref _enableManouverability, value); }
		}

		public int SelectedMovementType
		{
			get { return _selectedMovementType; }
			set
			{
				if (SetField(ref _selectedMovementType, value))
				{
					EnableManouverability = _selectedMovementType == GetMovementTypeIndex(Types.Movement.Fly);
				}
			}
		}

		public int SelectedManouverability
		{
			get { return _selectedManouverability; }
			set { SetField(ref _selectedManouverability, value); }
		}

		public Model.Speed GetSpeed()
		{
			bool askForInput = true;
			string feedback = null;
			Model.Speed speed = null;
			while (askForInput)
			{
				View.AddSpeedWindow addSpeedWindow = new View.AddSpeedWindow(feedback);
				addSpeedWindow.DataContext = this;

				if (addSpeedWindow.ShowDialog() == true)
				{
					try
					{
						speed = new Model.Speed
						{
							MovementType = Methods.GetMovementTypeFromString(MovementTypes.ElementAt(SelectedMovementType)),
							Distance = Convert.ToInt32(Distance),
							Manouverability = Methods.GetManouverabilityFromString(ManouverabilityTypes.ElementAt(SelectedManouverability)),
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

			return speed;
		}
	}
}
