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
		public AttackSetViewModel()
		{

		}

		private Model.AttackSet _attackSet;

		public Model.AttackSet AttackSet
		{
			get { return _attackSet; }
			set
			{
				_attackSet = value;
				NotifyPropertyChanged("AttackSet");
			}
		}
	}
}
