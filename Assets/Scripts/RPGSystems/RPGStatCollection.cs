using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGStatCollection{
	private Dictionary<RPGStatType, RPGStat> statDict;

	public RPGStatCollection(){
		statDict = new Dictionary<RPGStatType,RPGStat> ();
		ConfigureStats ();
	}

	protected virtual void ConfigureStats (){
	}

	public bool Contains(RPGStatType statType){
		return statDict.ContainsKey (statType);
	}

	public RPGStat GetStat(RPGStatType statType){
		if (Contains (statType))
			return statDict [statType];
		return null;
	}

	protected RPGStat CreateStat(RPGStatType statType){
		RPGStat stat = new RPGStat ();
		statDict.Add(statType, stat);
		return stat;
	}

	protected RPGStat CreateOrGetStat(RPGStatType statType){
		RPGStat stat = GetStat (statType);
		if (stat == null)
			stat = CreateStat (statType);
		return stat;
	}
}
