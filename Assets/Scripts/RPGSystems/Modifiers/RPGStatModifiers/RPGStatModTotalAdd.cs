using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RPGStatModTotalAdd  : RPGStatModifier {
	#region implemented abstract members of RPGStatModifier

	public override int ApplyModifier (int statValue, float modValue)
	{
		return (int)(modValue);
	}

	public override int Order {
		get {
			return 4;
		}
	}

	#endregion

	public RPGStatModTotalAdd(float value): base (value){}
	public RPGStatModTotalAdd(float value, bool stacks): base(value,stacks){}
}
