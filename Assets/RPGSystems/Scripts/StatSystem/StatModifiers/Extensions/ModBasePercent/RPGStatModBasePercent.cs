using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// RPG stat mod base percent.
	/// </summary>
	[System.Serializable]
	public class RPGStatModBasePercent: RPGStatModifier{
		#region implemented abstract members of RPGStatModifier
		/// <summary>
		/// Applies the modifier.
		/// </summary>
		/// <returns>The modifier.</returns>
		/// <param name="statValue">Stat value.</param>
		/// <param name="modValue">Mod value.</param>
		public override int ApplyModifier (int statValue, float modValue)
		{
			return (int)(statValue * modValue);
		}

		/// <summary>
		/// Gets the order.
		/// </summary>
		/// <value>The order.</value>
		public override int Order {
			get {
				return 1;
			}
		}

		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGStatModBasePercent"/> class.
		/// </summary>
		/// <param name="value">Value.</param>
		public RPGStatModBasePercent(float value): base (value){}

		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGStatModBasePercent"/> class.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="stacks">If set to <c>true</c> stacks.</param>
		public RPGStatModBasePercent(float value, bool stacks): base(value,stacks){}
	}
}