using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// RPG vital.
	/// </summary>
	public class RPGVital : RPGAttribute, IStatCurrentValueChange{
		/// <summary>
		/// The stat current value.
		/// </summary>
		private int _statCurrentValue;

		/// <summary>
		/// Occurs when on current value change.
		/// </summary>
		public event EventHandler OnCurrentValueChange;

		/// <summary>
		/// Gets or sets the stat current value.
		/// </summary>
		/// <value>The stat current value.</value>
		public int StatCurrentValue{
			get{
				if (_statCurrentValue > StatValue) {
					_statCurrentValue = StatValue;
				} else if (_statCurrentValue < 0) {
					_statCurrentValue = 0;
				}
				return _statCurrentValue;
			}
			set{
				if (_statCurrentValue != value) {
					_statCurrentValue = value;
					TriggerCurrentValueChange ();
				}
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGVital"/> class.
		/// </summary>
		public RPGVital(){
			_statCurrentValue = 0;
		}

		/// <summary>
		/// Sets the current value to max.
		/// </summary>
		public void SetCurrentValueToMax(){
			StatCurrentValue = StatValue;
		}

		/// <summary>
		/// Triggers the current value change.
		/// </summary>
		private void TriggerCurrentValueChange(){
			if (OnCurrentValueChange != null) {
				OnCurrentValueChange (this, null);
			}
		}
	}
}