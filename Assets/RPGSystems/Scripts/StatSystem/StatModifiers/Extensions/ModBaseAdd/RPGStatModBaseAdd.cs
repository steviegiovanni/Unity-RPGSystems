using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// RPG stat mod base add.
	/// </summary>
	[System.Serializable]
	public class RPGStatModBaseAdd : RPGStatModifier {
		#region implemented abstract members of RPGStatModifier
		/// <summary>
		/// Applies the modifier.
		/// </summary>
		/// <returns>The modifier.</returns>
		/// <param name="statValue">Stat value.</param>
		/// <param name="modValue">Mod value.</param>
		public override float ApplyModifier (float statValue, float modValue)
		{
			return (modValue);
		}

		/// <summary>
		/// Gets the order.
		/// </summary>
		/// <value>The order.</value>
		public override int Order {
			get {
				return 2;
			}
		}

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGStatModBaseAdd"/> class.
		/// </summary>
		/// <param name="value">Value.</param>
		public RPGStatModBaseAdd(float value): base (value){}

		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGStatModBaseAdd"/> class.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="stacks">If set to <c>true</c> stacks.</param>
		public RPGStatModBaseAdd(float value, bool stacks): base(value,stacks){}
		}
}