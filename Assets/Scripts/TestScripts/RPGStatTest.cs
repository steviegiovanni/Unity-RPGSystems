using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGStatTest : MonoBehaviour {
	private RPGStatCollection stats;

	// Use this for initialization
	void Start () {
		stats = new RPGDefaultStats();

		DisplayStatValues ();

		//var health = stats.GetStat<RPGStatModifiable> (RPGStatType.Health);
		//health.AddModifier(new RPGStatModifier(RPGStatType.Health, RPGStatModifier.Types.BaseValuePercent, 1.0f));
		//health.AddModifier(new RPGStatModifier(RPGStatType.Health, RPGStatModifier.Types.BaseValueAdd, 50));
		//health.AddModifier(new RPGStatModifier(RPGStatType.Health, RPGStatModifier.Types.TotalValuePercent, 1.0f));
		//health.UpdateModifiers();

		//var stamina = stats.GetStat<RPGAttribute> (RPGStatType.Stamina);
		//stamina.ScaleStat (16);

		stats.GetStat<RPGAttribute> (RPGStatType.Stamina).ScaleStat(5);
		stats.GetStat<RPGAttribute> (RPGStatType.Wisdom).ScaleStat(10);

		DisplayStatValues();
	}

	void ForEachEnum<T>(System.Action<T> action){
		if (action != null) {
			var statTypes = System.Enum.GetValues(typeof(T));
			foreach (var statType in statTypes) {
				action ((T)statType);
			}
		}
	}

	void DisplayStatValues(){
		ForEachEnum<RPGStatType>((statType)=>{
			RPGStat stat = stats.GetStat((RPGStatType)statType);
			if (stat != null) {
				Debug.Log (string.Format ("Stat {0}'s value is {1}", stat.StatName, stat.StatValue));
			}
		});
	}
}
