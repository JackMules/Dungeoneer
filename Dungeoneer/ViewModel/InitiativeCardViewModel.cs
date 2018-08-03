using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public class InitiativeCardViewModel : BaseViewModel
	{
		public InitiativeCardViewModel()
		{
			_initiativeValue = new Model.InitiativeValue();
			_openEditInitiativeDialog = new Command(ExecuteOpenEditInitiativeDialog);
		}

		private Command _openEditInitiativeDialog;
		private Model.InitiativeValue _initiativeValue;
		private ActorViewModel _actorViewModel;

		public Model.InitiativeValue InitiativeValue
		{
			get { return _initiativeValue; }
			set
			{
				_initiativeValue = value;
				NotifyPropertyChanged("InitiativeValue");
			}
		}

		public ActorViewModel ActorViewModel
		{
			get { return _actorViewModel; }
			set
			{
				_actorViewModel = value;
				NotifyPropertyChanged("ActorViewModel");
			}
		}

		public string InitiativeScore
		{
			get
			{
				if (InitiativeSet)
				{
					return InitiativeValue.InitiativeScore.ToString();
				}
				else
				{
					return "Not set";
				}
			}
			set
			{
				InitiativeValue.InitiativeScore = Convert.ToInt32(value);
				NotifyPropertyChanged("InitiativeScore");
			}
		}

		public string InitiativeMod
		{
			get
			{
				if (InitiativeSet)
				{
					return InitiativeValue.InitiativeMod.ToString();
				}
				else
				{
					return "Not set";
				}
			}
			set
			{
				InitiativeValue.InitiativeMod = Convert.ToInt32(value);
				NotifyPropertyChanged("InitiativeMod");
			}
		}

		public string InitiativeRoll
		{
			get
			{
				if (InitiativeSet)
				{
					return InitiativeValue.InitiativeRoll.ToString();
				}
				else
				{
					return "Not set";
				}
			}
			set
			{
				InitiativeValue.InitiativeRoll = Convert.ToInt32(value);
				NotifyPropertyChanged("InitiativeRoll");
			}
		}

		public bool InitiativeSet
		{
			get { return InitiativeValue.InitiativeScore.HasValue; }
		}

		public Command OpenEditInitiativeDialog
		{
			get { return _openEditInitiativeDialog; }
		}

		private void ExecuteOpenEditInitiativeDialog()
		{

		}
	}
}
