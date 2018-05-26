using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGStatModBaseAdd : RPGStatModifier {
	#region implemented abstract members of RPGStatModifier

	public override int ApplyModifier (int statValue, float modValue)
	{
		return (int)(modValue);
	}

	public override int Order {
		get {
			return 2;
		}
	}

	#endregion

	public RPGStatModBaseAdd(float value): base (value){}
	public RPGStatModBaseAdd(float value, bool stacks): base(value,stacks){}
	}
