using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// I stat linkable.
	/// </summary>
	public interface IStatLinkable{
		/// <summary>
		/// Gets the stat linker value.
		/// </summary>
		/// <value>The stat linker value.</value>
		int StatLinkerValue{get;}

		/// <summary>
		/// Adds the linker.
		/// </summary>
		/// <param name="linker">Linker.</param>
		void AddLinker (RPGStatLinker linker);

		/// <summary>
		/// Removes the linker.
		/// </summary>
		/// <param name="linker">Linker.</param>
		void RemoveLinker (RPGStatLinker linker);

		/// <summary>
		/// Clears the linkers.
		/// </summary>
		void ClearLinkers();

		/// <summary>
		/// Updates the linkers.
		/// </summary>
		void UpdateLinkers ();
	}
}