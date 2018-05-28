using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// RPG stat linker.
	/// </summary>
	public abstract class RPGStatLinker: IStatValueChange{
		/// <summary>
		/// The stat.
		/// </summary>
		private RPGStat _stat;

		#region IStatValueChange implementation

		/// <summary>
		/// Occurs when on value change.
		/// </summary>
		public event EventHandler OnValueChange;


		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGStatLinker"/> class.
		/// </summary>
		/// <param name="stat">Stat.</param>
		public RPGStatLinker(RPGStat stat){
			this._stat = stat;
			IStatValueChange iValueChange = this._stat as IStatValueChange;
			if (iValueChange != null) {
				iValueChange.OnValueChange += OnLinkStatValueChange;
			}
		}

		/// <summary>
		/// Gets the stat.
		/// </summary>
		/// <value>The stat.</value>
		public RPGStat Stat{
			get{ return _stat;}
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		public abstract int Value{ get;}

		/// <summary>
		/// Raises the link stat value change event.
		/// </summary>
		/// <param name="stat">Stat.</param>
		/// <param name="args">Arguments.</param>
		private void OnLinkStatValueChange (object stat, EventArgs args){
			if (OnValueChange != null) {
				OnValueChange (this, null);
			}
		}
	}
}