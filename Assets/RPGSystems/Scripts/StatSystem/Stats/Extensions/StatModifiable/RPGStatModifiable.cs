using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace RPGSystems.StatSystem{
	public class RPGStatModifiable : RPGStat, IStatModifiable, IStatValueChange {
		private List<RPGStatModifier> statMods;
		private int statModValue;

		public override int StatValue{
			get{ return base.StatValue + StatModifierValue;}
		}

		#region IStatValueChange implementation

		public event System.EventHandler OnValueChange;

		#endregion

		#region IStatModifiable implementation

		public void AddModifier (RPGStatModifier mod)
		{
			statMods.Add (mod);
			mod.OnValueChange += OnModValueChange;
		}

		public void RemoveModifier (RPGStatModifier mod)
		{
			statMods.Remove (mod);
			mod.OnValueChange -= OnModValueChange;
		}

		public void ClearModifiers ()
		{
			foreach(var mod in statMods){
				mod.OnValueChange -= OnModValueChange;
			}
			statMods.Clear ();
		}

		public void UpdateModifiers ()
		{
			statModValue = 0;

			var orderGroups = statMods.OrderBy (m=>m.Order).GroupBy (m => m.Order);
			foreach (var group in orderGroups) {
				float sum = 0, max = 0;
				foreach (var mod in group) {
					if (!mod.Stacks) {
						if (mod.ModValue > max) {
							max = mod.ModValue;
						}
					} else {
						sum += mod.ModValue;
					}
				}

				statModValue += group.First ().ApplyModifier (
					StatBaseValue + statModValue,
					(sum > max) ? sum : max
				);
			}

			TriggerValueChange ();
		}

		public int StatModifierValue {
			get {
				return statModValue;
			}
		}

		#endregion

		public RPGStatModifiable(){
			statModValue = 0;
			statMods = new List<RPGStatModifier> ();
		}

		protected void TriggerValueChange(){
			if (OnValueChange != null) {
				OnValueChange (this, null);
			}
		}

		public void OnModValueChange(object modifier, System.EventArgs args){
			UpdateModifiers ();
		}
	}
}