using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.Utility.Database{

[System.Serializable]
public class BaseDatabaseAsset : IDatabaseAsset {
	[SerializeField]
	private int id;

	[SerializeField]
	private string assetName;

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
			return assetName;
		}
		set {
			assetName = value;
		}
	}

	#endregion

	public BaseDatabaseAsset(){
		this.Id = -1;
		this.Name = string.Empty;
	}

	public BaseDatabaseAsset(int id){
		this.Id = id;
		this.Name = string.Empty;
	}

	public BaseDatabaseAsset(int id, string name){
		this.Id = id;
		this.Name = name;
	}

}

}