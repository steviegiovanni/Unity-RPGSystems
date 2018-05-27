using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.StatSystem{
	public interface IStatLinkable{
		int StatLinkerValue{get;}

		void AddLinker (RPGStatLinker linker);
		void RemoveLinker (RPGStatLinker linker);
		void ClearLinkers();
		void UpdateLinkers ();
	}
}