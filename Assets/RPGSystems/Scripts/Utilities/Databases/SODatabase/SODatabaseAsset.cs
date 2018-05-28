using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.Utility.Database{

	public class SODatabaseAsset : ScriptableObject, IDatabaseAsset {
		[SerializeField]
		private int id;

		[SerializeField]
		private string assetDatabase;

		#region IDatabaseAsset implementation

		public int Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}

		public string Name {
			get {
				return assetDatabase;
			}
			set {
				assetDatabase = value;
			}
		}

		#endregion

		public SODatabaseAsset(){
			this.Id = -1;
			this.Name = string.Empty;
		}

		public SODatabaseAsset(int id){
			this.Id = id;
			this.Name = string.Empty;
		}

		public SODatabaseAsset(int id, string name){
			this.Id = id;
			this.Name = name;
		}

	}

}