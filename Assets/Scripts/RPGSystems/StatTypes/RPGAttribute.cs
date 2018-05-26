using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RPGAttribute: RPGStatModifiable, IStatScalable, IStatLinkable{
	private int statLevelValue;
	private int statLinkerValue;
	private List<RPGStatLinker> statLinkers;

	public int StatLevelValue{
		get { return statLevelValue;}
	}

	public override int StatBaseValue{
		get{return base.StatBaseValue + StatLevelValue + StatLinkerValue; }
	}

	#region IStatScalable implementation

	public virtual void ScaleStat (int level)
	{
		statLevelValue = level;
		TriggerValueChange ();
	}

	#endregion

	#region IStatLinkable implementation

	public void AddLinker (RPGStatLinker linker)
	{
		statLinkers.Add (linker);
		linker.OnValueChange += OnLinkerValueChange;
	}

	public void ClearLinkers ()
	{
		foreach (var linker in statLinkers) {
			linker.OnValueChange -= OnLinkerValueChange;
		}

		statLinkers.Clear ();
	}

	public void UpdateLinkers ()
	{
		statLinkerValue = 0;
		foreach (RPGStatLinker link in statLinkers)
			statLinkerValue += link.Value;
		TriggerValueChange ();
	}

	public int StatLinkerValue {
		get {
			return statLinkerValue;
		}
	}

	#endregion

	public RPGAttribute(){
		statLinkers = new List<RPGStatLinker> ();
	}

	private void OnLinkerValueChange(object linker, EventArgs args){
		UpdateLinkers ();
	}
}
