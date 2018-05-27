using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPGSystems.StatSystem{
	public interface IStatValueChange{
		event EventHandler OnValueChange;
	}
}
