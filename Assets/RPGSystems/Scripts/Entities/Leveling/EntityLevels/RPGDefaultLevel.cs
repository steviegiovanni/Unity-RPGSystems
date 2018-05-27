using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGDefaultLevel : RPGEntityLevel {
	#region implemented abstract members of RPGEntityLevel
	public override int GetExpRequiredForLevel (int level)
	{
		return (int)(Mathf.Pow (Level, 2f) * 100) + 100;
	}
	#endregion
}
