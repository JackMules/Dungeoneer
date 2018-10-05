using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class AddAttackSetWindowViewModel : BaseViewModel
	{
		public AddAttackSetWindowViewModel()
		{
			_name = "Attack";
			_attackViewModels = new FullyObservableCollection<AttackViewModel>();
			_addAttack = new Command(ExecuteAddAttack);
			_removeAttack = new Command(ExecuteRemoveAttack);
		}

		private string _name;
		private FullyObservableCollection<AttackViewModel> _attackViewModels;
		private Command _addAttack;
		private Command _removeAttack;

		public int SelectedAttack { get; set; }

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public FullyObservableCollection<AttackViewModel> AttackViewModels
		{
			get { return _attackViewModels; }
			set
			{
				_attackViewModels = value;
				NotifyPropertyChanged("AttackViewModels");
			}
		}

		public Model.AttackSet GetAttackSet()
		{
			bool askForInput = true;
			string feedback = null;
			Model.AttackSet attackSet = null;
			while (askForInput)
			{
				View.AddAttackSetWindow addAttackSetWindow = new View.AddAttackSetWindow(feedback);
				addAttackSetWindow.DataContext = this;

				if (addAttackSetWindow.ShowDialog() == true)
				{
					try
					{
						attackSet = new Model.AttackSet
						{
							Name = Name,
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

			return attackSet;
		}

		public Command AddAttack
		{
			get { return _addAttack; }
		}

		public Command RemoveAttack
		{
			get { return _removeAttack; }
		}

		private void ExecuteAddAttack()
		{
			AddAttackWindowViewModel addAttackWindowViewModel = new AddAttackWindowViewModel();
			Model.Attack attack = addAttackWindowViewModel.GetAttack();
			if (attack != null)
			{
				AttackViewModel attackViewModel = new AttackViewModel { Attack = attack };
				AttackViewModels.Add(attackViewModel);
			}
		}

		private void ExecuteRemoveAttack()
		{
			AttackViewModels.RemoveAt(SelectedAttack);
		}
	}
}
