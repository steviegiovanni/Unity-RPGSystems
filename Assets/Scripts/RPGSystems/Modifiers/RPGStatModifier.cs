using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class RPGStatModifier{
	private float modValue;

	public event EventHandler OnValueChange;

	public abstract int Order {get;}

	public bool Stacks {get; set;}

	public float ModValue{
		get{ return modValue;}
		set{ 
			if (modValue != value) {
				modValue = value;
				if (OnValueChange != null) {
					OnValueChange (this, null);
				}
			}
		}
	}

	public RPGStatModifier(float value){
		modValue = 0;
		Stacks = false;
	}

	public RPGStatModifier(float value, bool stacks){
		modValue = value;
		Stacks = stacks;
	}

	public abstract int ApplyModifier (int statValue, float modValue);
}
