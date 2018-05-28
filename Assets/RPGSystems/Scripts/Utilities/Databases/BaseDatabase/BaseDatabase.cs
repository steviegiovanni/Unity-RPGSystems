using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.Utility.Database{

	public class BaseDatabase<T> : AbstractDatabase<T> where T: BaseDatabaseAsset{

	#region implemented abstract members of AbstractDatabase

	protected override void OnAddObject (T obj)
	{
		#if UNITY_EDITOR
		UnityEditor.EditorUtility.SetDirty(this);
		#endif
	}

	protected override void OnRemoveObject (T obj)
	{
		#if UNITY_EDITOR
		UnityEditor.EditorUtility.SetDirty(this);
		#endif
	}

	#endregion
}

}