using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.StatSystem{
	public class RPGStatLinkerBasic : RPGStatLinker {
		private float ratio;

		public override int Value{
			get{ return (int)(Stat.StatValue * ratio);}
		}

		public RPGStatLinkerBasic (RPGStat stat, float ratio): base(stat){
			this.ratio = ratio;
		}
	}
}