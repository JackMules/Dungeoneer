using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class AttackSetViewModel : BaseViewModel
	{
		public AttackSetViewModel(Model.AttackSet attackSet = null)
		{
			_attackViewModels = new FullyObservableCollection<AttackViewModel>();
			if (attackSet != null)
			{
				foreach (Model.Attack attack in attackSet.Attacks)
				{
					_attackViewModels.Add(new AttackViewModel(attack));
				}
			}
		}

		private FullyObservableCollection<AttackViewModel> _attackViewModels;

		public FullyObservableCollection<AttackViewModel> AttackViewModels
		{
			get { return _attackViewModels; }
		}
	}
}
