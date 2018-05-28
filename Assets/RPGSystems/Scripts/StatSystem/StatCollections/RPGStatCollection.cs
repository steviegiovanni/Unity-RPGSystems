using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// RPG stat collection.
	/// </summary>
	public class RPGStatCollection: MonoBehaviour{
		/// <summary>
		/// The stat dict.
		/// </summary>
		private Dictionary<RPGStatType, RPGStat> _statDict;

		/// <summary>
		/// Gets the stat dict.
		/// </summary>
		/// <value>The stat dict.</value>
		public Dictionary<RPGStatType, RPGStat> StatDict{
			get{
				if (_statDict == null)
					_statDict = new Dictionary<RPGStatType, RPGStat> ();
				return _statDict;
			}
		}

		/// <summary>
		/// Configures the stats.
		/// </summary>
		protected virtual void ConfigureStats (){}

		/// <summary>
		/// Awake this instance.
		/// </summary>
		private void Awake(){
			ConfigureStats ();
		}

		/// <summary>
		/// Contains the stat.
		/// </summary>
		/// <returns><c>true</c>, if stat was contained, <c>false</c> otherwise.</returns>
		/// <param name="statType">Stat type.</param>
		public bool ContainStat(RPGStatType statType){
			return StatDict.ContainsKey (statType);
		}

		/// <summary>
		/// Gets the stat.
		/// </summary>
		/// <returns>The stat.</returns>
		/// <param name="statType">Stat type.</param>
		public RPGStat GetStat(RPGStatType statType){
			if (ContainStat (statType))
				return StatDict [statType];
			return null;
		}

		/// <summary>
		/// Gets the stat.
		/// </summary>
		/// <returns>The stat.</returns>
		/// <param name="type">Type.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public T GetStat<T>(RPGStatType type) where T : RPGStat{
			return GetStat(type) as T;
		}

		/// <summary>
		/// Creates the stat.
		/// </summary>
		/// <returns>The stat.</returns>
		/// <param name="statType">Stat type.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		protected T CreateStat<T>(RPGStatType statType) where T: RPGStat{
			T stat = System.Activator.CreateInstance<T>();
			StatDict.Add(statType, (RPGStat)stat);
			return stat;
		}
			
		/// <summary>
		/// Creates the or get stat.
		/// </summary>
		/// <returns>The or get stat.</returns>
		/// <param name="statType">Stat type.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		protected T CreateOrGetStat<T>(RPGStatType statType) where T:RPGStat{
			T stat = GetStat<T>(statType);
			if (stat == null)
				stat = CreateStat<T>(statType);
			return stat;
		}

		/// <summary>
		/// Adds the modifier.
		/// </summary>
		/// <param name="target">Target.</param>
		/// <param name="mod">Mod.</param>
		public void AddModifier(RPGStatType target, RPGStatModifier mod){
			AddModifier (target, mod, false);
		}

		/// <summary>
		/// Adds the modifier.
		/// </summary>
		/// <param name="target">Target.</param>
		/// <param name="mod">Mod.</param>
		/// <param name="update">If set to <c>true</c> update.</param>
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

		/// <summary>
		/// Removes the stat modifier.
		/// </summary>
		/// <param name="target">Target.</param>
		/// <param name="mod">Mod.</param>
		public void RemoveStatModifier(RPGStatType target, RPGStatModifier mod){
			RemoveStatModifier (target, mod, false);
		}

		/// <summary>
		/// Removes the stat modifier.
		/// </summary>
		/// <param name="target">Target.</param>
		/// <param name="mod">Mod.</param>
		/// <param name="update">If set to <c>true</c> update.</param>
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

		/// <summary>
		/// Clears all stat modifier.
		/// </summary>
		public void ClearAllStatModifier(){
			ClearAllStatModifier (false);
		}

		/// <summary>
		/// Clears all stat modifier.
		/// </summary>
		/// <param name="update">If set to <c>true</c> update.</param>
		public void ClearAllStatModifier(bool update){
			foreach (var key in StatDict.Keys) {
				ClearStatModifier (key, update);
			}
		}

		/// <summary>
		/// Clears the stat modifier.
		/// </summary>
		/// <param name="target">Target.</param>
		public void ClearStatModifier(RPGStatType target){
			ClearStatModifier(target, false);
		}

		/// <summary>
		/// Clears the stat modifier.
		/// </summary>
		/// <param name="target">Target.</param>
		/// <param name="update">If set to <c>true</c> update.</param>
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

		/// <summary>
		/// Updates all stat modifier.
		/// </summary>
		public void UpdateAllStatModifier(){
			foreach (var key in StatDict.Keys) {
				UpdateStatModifier (key);
			}
		}

		/// <summary>
		/// Updates the stat modifier.
		/// </summary>
		/// <param name="target">Target.</param>
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

		/// <summary>
		/// Scales the stat collection.
		/// </summary>
		/// <param name="level">Level.</param>
		public void ScaleStatCollection(int level){
			foreach (var key in StatDict.Keys) {
				ScaleStat(key, level);
			}
		}

		/// <summary>
		/// Scales the stat.
		/// </summary>
		/// <param name="target">Target.</param>
		/// <param name="level">Level.</param>
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