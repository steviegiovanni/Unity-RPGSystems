using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.StatSystem{
	public class RPGStatCollection: MonoBehaviour{
		private Dictionary<RPGStatType, RPGStat> statDict;

		public Dictionary<RPGStatType, RPGStat> StatDict{
			get{
				if (statDict == null)
					statDict = new Dictionary<RPGStatType, RPGStat> ();
				return statDict;
			}
		}

		protected virtual void ConfigureStats (){}

		private void Awake(){
			ConfigureStats ();
		}

		public RPGStatCollection(){
			statDict = new Dictionary<RPGStatType, RPGStat> ();
			ConfigureStats ();
		}

		public bool ContainStat(RPGStatType statType){
			return StatDict.ContainsKey (statType);
		}

		public RPGStat GetStat(RPGStatType statType){
			if (ContainStat (statType))
				return StatDict [statType];
			return null;
		}

		public T GetStat<T>(RPGStatType type) where T : RPGStat{
			return GetStat(type) as T;
		}

		protected T CreateStat<T>(RPGStatType statType) where T: RPGStat{
			T stat = System.Activator.CreateInstance<T>();
			StatDict.Add(statType, (RPGStat)stat);
			return stat;
		}

		protected T CreateOrGetStat<T>(RPGStatType statType) where T:RPGStat{
			T stat = GetStat<T>(statType);
			if (stat == null)
				stat = CreateStat<T>(statType);
			return stat;
		}

		public void AddModifier(RPGStatType target, RPGStatModifier mod){
			AddModifier (target, mod, false);
		}

		public void AddModifier(RPGStatType target, RPGStatModifier mod, bool update){
			if (ContainStat (target)) {
				var modStat = GetStat (target) as IStatModifiable;
				if (modStat != null) {
					modStat.AddModifier (mod);
					if (update == true) {
						modStat.UpdateModifiers ();
					}
				} else {
					Debug.Log ("[RPGStatCollection] Trying to add Stat Modifier to non modifiable stat\"" + target.ToString () + "\"");
				}
			} else {
				Debug.Log ("[RPGStatCollection] Trying to add Stat Modifier to \"" + target.ToString () + "\", but RPGStatCollection does not contain that stat");
			}
		}

		public void RemoveStatModifier(RPGStatType target, RPGStatModifier mod){
			RemoveStatModifier (target, mod, false);
		}

		public void RemoveStatModifier(RPGStatType target, RPGStatModifier mod, bool update){
			if (ContainStat (target)) {
				var modStat = GetStat (target) as IStatModifiable;
				if (modStat != null) {
					modStat.RemoveModifier (mod);
					if (update == true) {
						modStat.UpdateModifiers ();
					}
				} else {
					Debug.Log ("[RPGStatCollection] Trying to remove Stat Modifier to non modifiable stat\"" + target.ToString () + "\"");
				}
			} else {
				Debug.Log ("[RPGStatCollection] Trying to remove Stat Modifier to \"" + target.ToString () + "\", but RPGStatCollection does not contain that stat");
			}
		}

		public void ClearAllStatModifier(){
			ClearAllStatModifier (false);
		}

		public void ClearAllStatModifier(bool update){
			foreach (var key in StatDict.Keys) {
				ClearStatModifier (key, update);
			}
		}

		public void ClearStatModifier(RPGStatType target){
			ClearStatModifier(target, false);
		}

		public void ClearStatModifier(RPGStatType target, bool update){
			if (ContainStat (target)) {
				var modStat = GetStat (target) as IStatModifiable;
				if (modStat != null) {
					modStat.ClearModifiers ();
					if (update == true) {
						modStat.UpdateModifiers ();
					}
				} else {
					Debug.Log ("[RPGStatCollection] Trying to clear Stat Modifiers to non modifiable stat\"" + target.ToString () + "\"");
				}
			} else {
				Debug.Log ("[RPGStatCollection] Trying to clear Stat Modifiers to \"" + target.ToString () + "\", but RPGStatCollection does not contain that stat");
			}
		}

		public void UpdateAllStatModifier(){
			foreach (var key in StatDict.Keys) {
				UpdateStatModifier (key);
			}
		}

		public void UpdateStatModifier(RPGStatType target){
			if (ContainStat (target)) {
				var modStat = GetStat (target) as IStatModifiable;
				if (modStat != null) {
					modStat.UpdateModifiers ();
				} else {
					Debug.Log ("[RPGStatCollection] Trying to update Stat Modifiers to non modifiable stat\"" + target.ToString () + "\"");
				}
			} else {
				Debug.Log ("[RPGStatCollection] Trying to update Stat Modifiers to \"" + target.ToString () + "\", but RPGStatCollection does not contain that stat");
			}
		}

		public void ScaleStatCollection(int level){
			foreach (var key in StatDict.Keys) {
				ScaleStat(key, level);
			}
		}

		public void ScaleStat(RPGStatType target, int level){
			if (ContainStat (target)) {
				var modStat = GetStat (target) as IStatScalable;
				if (modStat != null) {
					modStat.ScaleStat (level);
				} else {
					Debug.Log ("[RPGStatCollection] Trying to scale Stat Modifiers to non modifiable stat\"" + target.ToString () + "\"");
				}
			} else {
				Debug.Log ("[RPGStatCollection] Trying to scale Stat Modifiers to \"" + target.ToString () + "\", but RPGStatCollection does not contain that stat");
			}
		}
	}
}