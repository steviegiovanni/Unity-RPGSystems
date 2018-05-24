using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGStat{
	private string statName;
	private int statValue;

	public string StatName{
		get{ return statName; }
		set{ statName = value;}
	}

	public int StatValue{
		get{ return statValue;}
		set{ statValue = value;}
	}

	public RPGStat(){
		this.StatName = string.Empty;
		this.StatValue = 0;
	}

	public RPGStat(string name, int value){
		this.StatName = name;
		this.StatValue = value;
	}
}
