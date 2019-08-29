using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeoneer.Utility;

namespace Dungeoneer.Model.Effect
{
	public interface IAbilityEffect
	{
		Types.Ability Ability
		{
			get;
			set;
		}
	}
}
