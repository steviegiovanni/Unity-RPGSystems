using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.Utility.Database{

	public class SODatabase<T> : AbstractDatabase<T> where T: SODatabaseAsset {

		#region implemented abstract members of AbstractDatabase

		protected override void OnAddObject (T obj)
		{
			#if UNITY_EDITOR
			//obj.hideFlags = HideFlags.HideInHierarchy;
			UnityEditor.AssetDatabase.AddObjectToAsset(obj, this);
			UnityEditor.EditorUtility.SetDirty(this);
			#endif
		}

		protected override void OnRemoveObject (T obj)
		{
			#if UNITY_EDITOR
			DestroyImmediate(obj, true);
			UnityEditor.EditorUtility.SetDirty(this);
			#endif
		}

		#endregion
	}

}