using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// I stat scalable.
	/// </summary>
	public interface IStatScalable{
		/// <summary>
		/// Scales the stat.
		/// </summary>
		/// <param name="level">Level.</param>
		void ScaleStat (int level);
	}
}