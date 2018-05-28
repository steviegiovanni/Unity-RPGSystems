using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.StatSystem{
	[System.Serializable]
	/// <summary>
	/// RPG stat mod total add.
	/// </summary>
	public class RPGStatModTotalAdd  : RPGStatModifier {
		#region implemented abstract members of RPGStatModifier
		/// <summary>
		/// Applies the modifier.
		/// </summary>
		/// <returns>The modifier.</returns>
		/// <param name="statValue">Stat value.</param>
		/// <param name="modValue">Mod value.</param>
		public override int ApplyModifier (int statValue, float modValue)
		{
			return (int)(modValue);
		}

		/// <summary>
		/// Gets the order.
		/// </summary>
		/// <value>The order.</value>
		public override int Order {
			get {
				return 4;
			}
		}

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGStatModTotalAdd"/> class.
		/// </summary>
		/// <param name="value">Value.</param>
		public RPGStatModTotalAdd(float value): base (value){}

		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGStatModTotalAdd"/> class.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="stacks">If set to <c>true</c> stacks.</param>
		public RPGStatModTotalAdd(float value, bool stacks): base(value,stacks){}
	}
}