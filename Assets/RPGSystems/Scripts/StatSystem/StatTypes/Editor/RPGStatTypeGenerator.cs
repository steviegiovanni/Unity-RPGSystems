using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Text;
using RPGSystems.StatSystem;

namespace RPGSystems.StatSystem.Editor{
	static public class RPGStatTypeGenerator{
		const string defaultFilename = "RPGStatType.cs";

		static public void CheckAndGenerateFile(){
			string assetPath = GetAssetPathForFile (defaultFilename);
			if (string.IsNullOrEmpty (assetPath)) {
				string genAssetPath = GetAssetPathForFile ("RPGStatTypeGenerator.cs");
				assetPath = genAssetPath.Replace ("Editor/RPGStatTypeGenerator.cs",defaultFilename);
			}

			WriteStatTypesToFile (assetPath);
		}

		static string GetAssetPathForFile(string name){
			string[] assetPaths = AssetDatabase.GetAllAssetPaths ();
			foreach (var path in assetPaths) {
				if (path.Contains (name)) {
					return path;
				}
			}
			return string.Empty;
		}

		static public void WriteStatTypesToFile(string filepath){
			using(StreamWriter file = File.CreateText(filepath)){
				file.WriteLine ("/// auto generated file");
				file.WriteLine ("namespace RPGSystems.StatSystem{");
				file.WriteLine ("\tpublic enum RPGStatType {");
				file.WriteLine ("\t\tNone = 0,");

				for (int i = 0; i < RPGStatTypeDatabase.Instance.Count; i++) {
					var statType = RPGStatTypeDatabase.GetAt (i);

					if (!string.IsNullOrEmpty (statType.Name)) {

						file.WriteLine (string.Format ("\t\t{0} = {1},",
							statType.Name.Replace (" ", string.Empty),
							statType.Id));
					}
				}

				file.WriteLine ("\t}\n}");
				AssetDatabase.Refresh ();
			}
		}
	}

}