using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RPGVitalTest : MonoBehaviour {
	private RPGStatCollection stats;

	// Use this for initialization
	void Start () {
		stats = new RPGDefaultStats();

		var health = stats.GetStat<RPGVital> (RPGStatType.Health);
		health.OnCurrentValueChange += OnStatValueChange;

		DisplayStatValues ();

		health.StatCurrentValue -= 75;

		DisplayStatValues();
	}

	void OnStatValueChange(object sender, EventArgs args){
		RPGVital vital = (RPGVital)sender;
		if (vital != null) {
			Debug.Log (string.Format ("Vital {0}'s OnStateValueChange event was triggered", vital.StatName));
		}
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
				RPGVital vital = stat as RPGVital;
				if(vital != null)
					Debug.Log (string.Format ("Stat {0}'s value is {1}/{2}", stat.StatName, vital.StatCurrentValue,stat.StatValue));
				else
					Debug.Log (string.Format ("Stat {0}'s value is {1}", stat.StatName, stat.StatValue));
			}
		});
	}
}
