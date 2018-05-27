using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.StatSystem{
	public interface IStatModifiable{
		int StatModifierValue{ get;}

		void AddModifier (RPGStatModifier mod);
		void RemoveModifier (RPGStatModifier mod);
		void ClearModifiers ();
		void UpdateModifiers ();
	}
}