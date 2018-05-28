using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// RPG stat modifier.
	/// </summary>
	[System.Serializable]
	public abstract class RPGStatModifier{
		/// <summary>
		/// The value.
		/// </summary>
		[SerializeField]
		private float _value = 0f;

		/// <summary>
		/// The stacks.
		/// </summary>
		[SerializeField]
		private bool _stacks = true;

		/// <summary>
		/// Occurs when Value property changes.
		/// </summary>
		public event EventHandler OnValueChange;

		/// <summary>
		/// Gets the order.
		/// </summary>
		/// <value>The order.</value>
		public abstract int Order {get;}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		public float Value{
			get{ return _value;}
			set{ 
				if (_value != value) {
					_value = value;
					if (OnValueChange != null) {
						OnValueChange (this, null);
					}
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="RPGSystems.StatSystem.RPGStatModifier"/> is stacks.
		/// </summary>
		/// <value><c>true</c> if stacks; otherwise, <c>false</c>.</value>
		public bool Stacks {
			get { return _stacks; } 
			set{ _stacks = value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGStatModifier"/> class.
		/// </summary>
		/// <param name="value">Value.</param>
		public RPGStatModifier(float value){
			_value = 0;
			Stacks = false;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGStatModifier"/> class.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="stacks">If set to <c>true</c> stacks.</param>
		public RPGStatModifier(float value, bool stacks){
			_value = value;
			Stacks = stacks;
		}

		/// <summary>
		/// Applies the modifier.
		/// </summary>
		/// <returns>The modifier.</returns>
		/// <param name="statValue">Stat value.</param>
		/// <param name="modValue">Mod value.</param>
		public abstract int ApplyModifier (int statValue, float modValue);
	}
}