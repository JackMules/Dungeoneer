﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.ViewModel
{
	public class AddEffectWindowViewModel : BaseViewModel
	{
		public AddEffectWindowViewModel()
		{

		}

		public List<Model.Effect> EffectList
		{
			get { return }
		}

		public Model.Effect GetEffect()
		{
			bool askForInput = true;
			string feedback = null;
			Model.Effect effect = null;
			while (askForInput)
			{
				View.AddEffectWindow addEffectWindow = new View.AddEffectWindow(feedback);
				addEffectWindow.DataContext = this;

				if (addEffectWindow.ShowDialog() == true)
				{
					try
					{
						effect = new Model.Effect();

						effect.Name = Name;
						effect.
					}
					catch (FormatException e)
					{

					}
				}
			}

			return effect;
		}
	}
}