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
		public AddAttackSetWindowViewModel(Model.AttackSet attackSet = null)
		{
			_attackViewModels = new FullyObservableCollection<AttackViewModel>();
			_addAttack = new Command(ExecuteAddAttack);
			_editAttack = new Command(ExecuteEditAttack);
			_removeAttack = new Command(ExecuteRemoveAttack);

			if (attackSet != null)
			{
				_name = attackSet.Name;
				foreach (Model.Attack attack in attackSet.Attacks)
				{
					_attackViewModels.Add(new AttackViewModel(attack));
				}
			}
			else
			{
				_name = "Attack";
			}
		}

		private string _name;
		private FullyObservableCollection<AttackViewModel> _attackViewModels;
		private Command _addAttack;
		private Command _editAttack;
		private Command _removeAttack;

		public int SelectedAttack { get; set; }

		public string Name
		{
			get { return _name; }
			set { SetField(ref _name, value); }
		}

		public FullyObservableCollection<AttackViewModel> AttackViewModels
		{
			get { return _attackViewModels; }
			set { SetField(ref _attackViewModels, value); }
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

		public Command EditAttack
		{
			get { return _editAttack; }
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

		private void ExecuteEditAttack()
		{
			if (SelectedAttack < AttackViewModels.Count)
			{
				AddAttackWindowViewModel addAttackWindowViewModel = new AddAttackWindowViewModel(AttackViewModels[SelectedAttack].Attack);
				Model.Attack attack = addAttackWindowViewModel.GetAttack();
				if (attack != null)
				{
					AttackViewModel attackViewModel = new AttackViewModel { Attack = attack };
					AttackViewModels[SelectedAttack] = attackViewModel;
				}
			}
		}

		private void ExecuteRemoveAttack()
		{
			AttackViewModels.RemoveAt(SelectedAttack);
		}
	}
}
