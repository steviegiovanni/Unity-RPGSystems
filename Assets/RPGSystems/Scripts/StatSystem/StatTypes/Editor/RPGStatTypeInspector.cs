using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RPGSystems.StatSystem;

namespace RPGSystems.StatSystem.Editor{
	[CustomEditor(typeof(RPGStatTypeDatabase))]
	public class RPGStatTypeInspector : UnityEditor.Editor {
		//private string output = "";

		public override void OnInspectorGUI(){
			GUILayout.Label ("Database that stores all RPGStatTypes");
			if (GUILayout.Button ("Open Editor Window")) {
				RPGStatTypeWindow.ShoWindow ();
			}


			/*if (GUILayout.Button ("Stat type Dialog Test")) {
				RPGStatTypeDialog.Display ((asset) => {
					output = asset.Name;
				});
			}

			if (output != "") {
				EditorGUILayout.HelpBox (output, MessageType.None);
			}*/
		}
	}

}
