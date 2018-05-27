using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPGSystems.StatSystem{
	[System.Serializable]
	public abstract class RPGStatModifier{
		[SerializeField]
		private float modValue = 0f;

		[SerializeField]
		private bool stacks = true;

		public event EventHandler OnValueChange;

		public abstract int Order {get;}

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

		public bool Stacks {
			get { return stacks; } 
			set{ stacks = value; }
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
}