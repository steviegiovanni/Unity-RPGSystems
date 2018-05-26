using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RPGStatModTotalPercent : RPGStatModifier {
	#region implemented abstract members of RPGStatModifier

	public override int ApplyModifier (int statValue, float modValue)
	{
		return (int)(statValue * modValue);
	}

	public override int Order {
		get {
			return 3;
		}
	}

	#endregion

	public RPGStatModTotalPercent(float value): base (value){}
	public RPGStatModTotalPercent(float value, bool stacks): base(value,stacks){}
}
