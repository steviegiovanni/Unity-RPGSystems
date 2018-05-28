using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// RPG stat modifiable.
	/// </summary>
	public class RPGStatModifiable : RPGStat, IStatModifiable, IStatValueChange {
		/// <summary>
		/// The stat mods.
		/// </summary>
		private List<RPGStatModifier> _statMods;

		/// <summary>
		/// The stat mod value.
		/// </summary>
		private float _statModValue;

		/// <summary>
		/// Gets the stat value.
		/// </summary>
		/// <value>The stat value.</value>
		public override float StatValue{
			get{ return base.StatValue + StatModifierValue;}
		}

		#region IStatValueChange implementation

		/// <summary>
		/// Occurs when on value change.
		/// </summary>
		public event System.EventHandler OnValueChange;

		#endregion

		#region IStatModifiable implementation

		/// <summary>
		/// Adds the modifier.
		/// </summary>
		/// <param name="mod">Mod.</param>
		public void AddModifier (RPGStatModifier mod)
		{
			_statMods.Add (mod);
			mod.OnValueChange += OnModValueChange;
		}

		/// <summary>
		/// Removes the modifier.
		/// </summary>
		/// <param name="mod">Mod.</param>
		public void RemoveModifier (RPGStatModifier mod)
		{
			_statMods.Remove (mod);
			mod.OnValueChange -= OnModValueChange;
		}

		/// <summary>
		/// Clears the modifiers.
		/// </summary>
		public void ClearModifiers ()
		{
			foreach(var mod in _statMods){
				mod.OnValueChange -= OnModValueChange;
			}
			_statMods.Clear ();
		}

		/// <summary>
		/// Updates the modifiers.
		/// </summary>
		public void UpdateModifiers ()
		{
			_statModValue = 0;

			var orderGroups = _statMods.OrderBy (m=>m.Order).GroupBy (m => m.Order);
			foreach (var group in orderGroups) {
				float sum = 0, max = 0;
				foreach (var mod in group) {
					if (!mod.Stacks) {
						if (mod.Value > max) {
							max = mod.Value;
						}
					} else {
						sum += mod.Value;
					}
				}

				_statModValue += group.First ().ApplyModifier (
					StatBaseValue + _statModValue,
					(sum > max) ? sum : max
				);
			}

			TriggerValueChange ();
		}

		/// <summary>
		/// Gets the stat modifier value.
		/// </summary>
		/// <value>The stat modifier value.</value>
		public float StatModifierValue {
			get {
				return _statModValue;
			}
		}

		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGStatModifiable"/> class.
		/// </summary>
		public RPGStatModifiable(){
			_statModValue = 0;
			_statMods = new List<RPGStatModifier> ();
		}

		/// <summary>
		/// Triggers the value change.
		/// </summary>
		protected void TriggerValueChange(){
			if (OnValueChange != null) {
				OnValueChange (this, null);
			}
		}

		/// <summary>
		/// Raises the mod value change event.
		/// </summary>
		/// <param name="modifier">Modifier.</param>
		/// <param name="args">Arguments.</param>
		public void OnModValueChange(object modifier, System.EventArgs args){
			UpdateModifiers ();
		}
	}
}