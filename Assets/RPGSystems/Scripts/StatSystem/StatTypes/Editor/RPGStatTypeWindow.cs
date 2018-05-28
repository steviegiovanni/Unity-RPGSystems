using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RPGSystems.StatSystem.Editor{
	public class RPGStatTypeWindow : EditorWindow {
		private Vector2 scrollPosition;
		private int activeId;

		private GUIStyle toggleButtonStyle;
		public GUIStyle ToggleButtonStyle{
			get{
				if (toggleButtonStyle == null) {
					toggleButtonStyle = new GUIStyle (EditorStyles.toolbarButton);
					toggleButtonStyle.alignment = TextAnchor.MiddleLeft;
				}
				return toggleButtonStyle;
			}
		}

		[MenuItem("Window/RPGSystems/Stat Types")]
		static public void ShoWindow(){
			var wnd = GetWindow<RPGStatTypeWindow> ();
			wnd.titleContent.text = "Stat Types";
			wnd.Show ();
		}

		public void OnEnable(){
		}

		public void OnGUI(){
			scrollPosition = GUILayout.BeginScrollView (scrollPosition);

			for (int i = 0; i < RPGStatTypeDatabase.GetAssetCount (); i++) {
				var asset = RPGStatTypeDatabase.GetAt (i);
				if (asset != null) {
					GUILayout.BeginHorizontal (EditorStyles.toolbar);
					GUILayout.Label (string.Format ("Id: {0}", asset.Id.ToString ("D3")), GUILayout.Width(60));

					bool clicked = GUILayout.Toggle (asset.Id == activeId, asset.Name, ToggleButtonStyle);
					if (clicked != (asset.Id == activeId)) {
						if (clicked) {
							activeId = asset.Id;
							GUI.FocusControl (null);
						} else {
							activeId = -1;
						}
					}
						
					if (GUILayout.Button ("-",EditorStyles.toolbarButton,GUILayout.Width(30)) && EditorUtility.DisplayDialog ("Delete Stat Type", "Are you sure you want to delete " + asset.Name + "stat type?", "Delete", "Cancel")) {
						RPGStatTypeDatabase.Instance.RemoveAt (i);
					}

					GUILayout.EndHorizontal ();

					if (activeId == asset.Id) {
						EditorGUI.BeginChangeCheck ();

						GUILayout.BeginVertical ("Box");

						GUILayout.BeginHorizontal ();

						asset.Icon = (Sprite)EditorGUILayout.ObjectField (asset.Icon, typeof(Sprite), false, GUILayout.Width(72), GUILayout.Height(72));

						GUILayout.BeginVertical ();
						GUILayout.Label ("Name", GUILayout.Width (80));
						EditorGUI.indentLevel++;
						asset.Name = EditorGUILayout.TextField (asset.Name);
						EditorGUI.indentLevel--;
						GUILayout.Label ("Name Short", GUILayout.Width (80));
						EditorGUI.indentLevel++;
						asset.NameShort = EditorGUILayout.TextField (asset.NameShort);
						EditorGUI.indentLevel--;
						GUILayout.EndVertical ();

						GUILayout.EndHorizontal ();

						GUILayout.BeginHorizontal ();
						GUILayout.Label ("Description", GUILayout.Width (80));
						asset.Description = EditorGUILayout.TextArea (asset.Description);
						GUILayout.EndHorizontal ();

						GUILayout.EndVertical ();

						if (EditorGUI.EndChangeCheck ()) {
							EditorUtility.SetDirty (RPGStatTypeDatabase.Instance);
						}
					}
				}
			}

			GUILayout.EndScrollView ();

			GUILayout.BeginHorizontal ();

			if (GUILayout.Button ("Add Type", EditorStyles.toolbarButton)) {
				var newAsset = new RPGStatTypeAsset (RPGStatTypeDatabase.Instance.GetNextId ());

				RPGStatTypeDatabase.Instance.Add (newAsset);
			}

			if (GUILayout.Button ("Generate Enum", EditorStyles.toolbarButton)) {
				RPGStatTypeGenerator.CheckAndGenerateFile ();
			}

			GUILayout.EndHorizontal ();
		}
	}
}
