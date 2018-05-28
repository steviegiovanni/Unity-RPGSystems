using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// I stat current value change.
	/// </summary>
	public interface IStatCurrentValueChange{
		/// <summary>
		/// Occurs when on current value change.
		/// </summary>
		event EventHandler OnCurrentValueChange;
	}

}