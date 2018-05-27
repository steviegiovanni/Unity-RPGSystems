using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.StatSystem{
	[System.Serializable]
	public class RPGStatModBasePercent: RPGStatModifier{
		#region implemented abstract members of RPGStatModifier

		public override int ApplyModifier (int statValue, float modValue)
		{
			return (int)(statValue * modValue);
		}

		public override int Order {
			get {
				return 1;
			}
		}

		#endregion

		public RPGStatModBasePercent(float value): base (value){}
		public RPGStatModBasePercent(float value, bool stacks): base(value,stacks){}
	}
}