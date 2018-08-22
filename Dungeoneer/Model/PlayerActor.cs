﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dungeoneer.Model
{
	public class PlayerActor : Actor
	{
		public PlayerActor()
			: base()
		{

		}

		public PlayerActor(
			string displayName,
			string actorName,
			int initiativeMod,
			Utility.FullyObservableCollection<Condition> conditions)
			: base(displayName, actorName, initiativeMod, conditions)
		{
		}

		public override void WriteXMLStartElement(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("PlayerActor");
		}
	}
}
