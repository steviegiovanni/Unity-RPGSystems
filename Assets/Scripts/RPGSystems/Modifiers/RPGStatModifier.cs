using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGStatModifier{
	public enum Types{
		None,
		BaseValuePercent,
		BaseValueAdd,
		TotalValuePercent,
		TotalValueAdd
	}

	private Types modType;
	private float modValue;
	private RPGStatType statType;

	public Types ModType{
		get{ return modType;}
		set{ modType = value;}
	}

	public float ModValue{
		get{ return modValue;}
		set{ modValue = value;}
	}

	public RPGStatType StatType{
		get{ return statType;}
		set{ statType = value;}
	}

	public RPGStatModifier(){
		ModType = Types.None;
		ModValue = 0;
		StatType = RPGStatType.None;
	}

	public RPGStatModifier(RPGStatType targetStat, Types modType, float modValue){
		ModType = modType;
		ModValue = modValue;
		StatType = targetStat;
	}
}
