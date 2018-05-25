using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGStatModifiable : RPGStat, IStatModifiable {
	private List<RPGStatModifier> statMods;
	private int statModValue;

	public override int StatValue{
		get{ return base.StatValue + StatModifierValue;}
	}

	#region IStatModifiable implementation

	public void AddModifier (RPGStatModifier mod)
	{
		statMods.Add (mod);
	}

	public void ClearModiers ()
	{
		statMods.Clear ();
	}

	public void UpdateModifiers ()
	{
		statModValue = 0;

		float statModBaseValueAdd = 0;
		float statModBaseValuePercent = 0;
		float statModTotalValueAdd = 0;
		float statModTotalValuePercent = 0;

		foreach (RPGStatModifier mod in statMods) {
			switch (mod.ModType) {
			case RPGStatModifier.Types.BaseValueAdd:
				statModBaseValueAdd += mod.ModValue;
				break;
			case RPGStatModifier.Types.BaseValuePercent:
				statModBaseValuePercent += mod.ModValue;
				break;
			case RPGStatModifier.Types.TotalValueAdd:
				statModTotalValueAdd += mod.ModValue;
				break;
			case RPGStatModifier.Types.TotalValuePercent:
				statModTotalValuePercent += mod.ModValue;
				break;
			}
		}

		statModValue = (int)((StatBaseValue * statModBaseValuePercent) + statModBaseValueAdd);
		statModValue += (int)((StatValue * statModTotalValuePercent) + statModTotalValueAdd);
	}

	public int StatModifierValue {
		get {
			return statModValue;
		}
	}

	public RPGStatModifiable(){
		statModValue = 0;
		statMods = new List<RPGStatModifier> ();
	}

	#endregion


}
