using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.ViewModel
{
	public class CreateActorWindowViewModel : BaseViewModel
	{
		public CreateActorWindowViewModel()
		{
			_actorName = "";
			_initiativeMod = "0";
		}

		private string _actorName;
		private string _initiativeMod;
		private string _type;
		private string _challengeRating;

		public string ActorName
		{
			get { return _actorName; }
			set
			{
				_actorName = value;
				NotifyPropertyChanged("ActorName");
			}
		}

		public string InitiativeMod
		{
			get { return _initiativeMod; }
			set
			{
				_initiativeMod = value;
				NotifyPropertyChanged("InitiativeMod");
			}
		}

		public string Type
		{
			get { return _type; }
			set
			{
				_type = value;
				NotifyPropertyChanged("Type");
			}
		}

		public string ChallengeRating
		{
			get { return _challengeRating; }
			set
			{
				_challengeRating = value;
				NotifyPropertyChanged("ChallengeRating");
			}
		}

		public Model.PlayerActor GetPlayerActor()
		{
			bool askForInput = true;
			string feedback = null;
			Model.PlayerActor playerActor = null;
			while (askForInput)
			{
				View.CreatePlayerActorWindow createActorWindow = new View.CreatePlayerActorWindow(feedback);
				createActorWindow.DataContext = this;
				if (createActorWindow.ShowDialog() == true)
				{
					try
					{
						playerActor = new Model.PlayerActor
						{
							ActorName = ActorName,
							InitiativeMod = Convert.ToInt32(InitiativeMod)
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

			return playerActor;
		}

		public Model.NonPlayerActor GetNonPlayerActor()
		{
			bool askForInput = true;
			string feedback = null;
			Model.NonPlayerActor nonPlayerActor = null;
			while (askForInput)
			{
				View.CreateNonPlayerActorWindow createActorWindow = new View.CreateNonPlayerActorWindow(feedback);
				createActorWindow.DataContext = this;
				if (createActorWindow.ShowDialog() == true)
				{
					try
					{
						nonPlayerActor = new Model.NonPlayerActor
						{
							ActorName = ActorName,
							InitiativeMod = Convert.ToInt32(InitiativeMod),
							Type = Type,
							ChallengeRating = Convert.ToInt32(ChallengeRating),
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

			return nonPlayerActor;
		}
	}
