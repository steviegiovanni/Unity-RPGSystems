using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// Allow stat to use modifiers
	/// </summary>
	public interface IStatModifiable{
		/// <summary>
		/// Gets the stat modifier value.
		/// </summary>
		/// <value>The stat modifier value.</value>
		int StatModifierValue{ get;}

		/// <summary>
		/// Adds the modifier.
		/// </summary>
		/// <param name="mod">Mod.</param>
		void AddModifier (RPGStatModifier mod);
		/// <summary>
		/// Removes the modifier.
		/// </summary>
		/// <param name="mod">Mod.</param>
		void RemoveModifier (RPGStatModifier mod);
		/// <summary>
		/// Clears the modifiers.
		/// </summary>
		void ClearModifiers ();
		/// <summary>
		/// Updates the modifiers.
		/// </summary>
		void UpdateModifiers ();
	}
}