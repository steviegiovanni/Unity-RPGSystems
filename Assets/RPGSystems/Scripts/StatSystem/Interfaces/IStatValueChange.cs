using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// I stat value change.
	/// </summary>
	public interface IStatValueChange{

		/// <summary>
		/// Occurs when on value change.
		/// </summary>
		event EventHandler OnValueChange;
	}
}
