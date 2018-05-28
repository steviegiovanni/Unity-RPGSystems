using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGEntity : MonoBehaviour {
	/// <summary>
	/// The entity level.
	/// </summary>
	[SerializeField]
	private RPGEntityLevel _entityLevel;

	/// <summary>
	/// Gets or sets the entity level.
	/// </summary>
	/// <value>The entity level.</value>
	public RPGEntityLevel EntityLevel{
		get{ return _entityLevel;}
		set{ _entityLevel = value;}
	}

	/// <summary>
	/// Awake this instance.
	/// </summary>
	private void Awake(){
		if (EntityLevel == null) {
			EntityLevel = GetComponent<RPGEntityLevel> ();
			if (EntityLevel == null) {
				Debug.LogWarning ("No RPGEntityLevel assigned to RPGEntity");
			}
		}
	}
}
