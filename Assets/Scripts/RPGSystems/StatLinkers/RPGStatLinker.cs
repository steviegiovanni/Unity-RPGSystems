using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RPGStatLinker{
	private RPGStat stat;
	public RPGStatLinker(RPGStat stat){
		this.stat = stat;
	}

	public RPGStat Stat{
		get{ return stat;}
	}

	public abstract int Value{ get;}
}
