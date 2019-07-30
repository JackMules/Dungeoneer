using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeoneer.Model
{
	[Serializable]
	public class HitPointChange : BaseModel
	{
		public HitPointChange()
		{

		}

		public virtual int GetHitPointChange()
		{
			return 0;
		}
		public override string ToString()
		{
			return "no change";
		}
	}
}
