using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	}

	#endregion

	#region IStatLinkable implementation

	public void AddLinker (RPGStatLinker linker)
	{
		statLinkers.Add (linker);
	}

	public void ClearLinkers ()
	{
		statLinkers.Clear ();
	}

	public void UpdateLinkers ()
	{
		statLinkerValue = 0;
		foreach (RPGStatLinker link in statLinkers)
			statLinkerValue += link.Value;
	}

	public int StatLinkerValue {
		get {
			UpdateLinkers ();
			return statLinkerValue;
		}
	}

	#endregion

	public RPGAttribute(){
		statLinkers = new List<RPGStatLinker> ();
	}
}
