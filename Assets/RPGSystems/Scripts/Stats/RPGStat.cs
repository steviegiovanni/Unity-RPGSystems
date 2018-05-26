using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGStat{
	private string statName;
	private int statBaseValue;

	public string StatName{
		get{ return statName; }
		set{ statName = value;}
	}

	public virtual int StatValue{
		get{ return StatBaseValue;}
	}

	public virtual int StatBaseValue{
		get{ return statBaseValue;}
		set{ statBaseValue = value;}
	}

	public RPGStat(){
		this.StatName = string.Empty;
		this.StatBaseValue = 0;
	}

	public RPGStat(string name, int value){
		this.StatName = name;
		this.StatBaseValue = value;
	}
}
