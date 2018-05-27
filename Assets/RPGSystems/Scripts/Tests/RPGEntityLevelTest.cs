using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGSystems.StatSystem;

public class RPGEntityLevelTest : MonoBehaviour {
	public RPGEntity entity;

	void Update(){
		entity.EntityLevel.ModifyExp (100);
	}
}
