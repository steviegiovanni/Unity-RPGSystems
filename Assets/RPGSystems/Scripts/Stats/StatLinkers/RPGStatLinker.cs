using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class RPGStatLinker: IStatValueChange{
	private RPGStat stat;

	#region IStatValueChange implementation


	public event EventHandler OnValueChange;


	#endregion

	public RPGStatLinker(RPGStat stat){
		this.stat = stat;
		IStatValueChange iValueChange = this.stat as IStatValueChange;
		if (iValueChange != null) {
			iValueChange.OnValueChange += OnLinkStatValueChange;
		}
	}

	public RPGStat Stat{
		get{ return stat;}
	}

	public abstract int Value{ get;}

	private void OnLinkStatValueChange (object stat, EventArgs args){
		if (OnValueChange != null) {
			OnValueChange (this, null);
		}
	}
}
