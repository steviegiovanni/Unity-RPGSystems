using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RPGVital : RPGAttribute{
	private int statCurrentValue;

	public event EventHandler OnCurrentValueChange;

	public int StatCurrentValue{
		get{
			if (statCurrentValue > StatValue) {
				statCurrentValue = StatValue;
			} else if (statCurrentValue < 0) {
				statCurrentValue = 0;
			}
			return statCurrentValue;
		}
		set{
			if (statCurrentValue != value) {
				statCurrentValue = value;
				TriggerCurrentValueChange ();
			}
		}
	}

	public RPGVital(){
		statCurrentValue = 0;
	}

	public void SetCurrentValueToMax(){
		StatCurrentValue = StatValue;
	}

	private void TriggerCurrentValueChange(){
		if (OnCurrentValueChange != null) {
			OnCurrentValueChange (this, null);
		}
	}
}
