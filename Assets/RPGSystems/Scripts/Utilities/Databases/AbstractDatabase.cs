using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractDatabase<T> : ScriptableObject where T:IDatabaseAsset{
	[SerializeField]
	private List<T> objects;

	protected List<T> Objects{
		get{
			if (objects == null) {
				objects = new List<T> ();
			}
			return objects;
		}
	}

	public void Add(T obj){
		Objects.Add (obj);
	}

	public void Remove(T obj){
		Objects.Remove (obj);
	}

	public void RemoveAt(int index){
		Objects.RemoveAt (index);
	}

	public void Replace(int index, T obj){
		Objects [index] = obj;
	}

	public int Count{
		get{ return Objects.Count;}
	}

	public T GetAtIndex(int index){
		if (Count > 0) {
			if (index >= 0 && index < this.Count) {
				return Objects [index];
			}
		}

		return default(T);
	}

	public T GetById(int id){
		for (int i = 0; i < Count; i++) {
			var asset = GetAtIndex (i);
			if (asset.Id == id)
				return asset;
		}
		return default(T);
	}

	public int GetFirstAvailableId(){
		if (Count <= 0) {
			return 1;
		} else {
			int targetId = 1;
			bool foundUsableId = false;
			while (!foundUsableId) {
				foundUsableId = true;
				for (int i = 0; i < Count; i++) {
					if (GetAtIndex (i).Id == targetId) {
						foundUsableId = false;
						targetId++;
						break;
					}
				}
			}
			return targetId;
		}
	}

	public int GetNextId(){
		int maxId = 0;
		for (int i = 0; i < Count; i++) {
			var asset = GetAtIndex (i);
			if (asset.Id > maxId) {
				maxId = asset.Id;
			}
		}
		return maxId + 1;
	}

	public bool ContainsDuplicateIds(){
		for (int i = 0; i < Count-1; i++) {
			var asset1 = GetAtIndex (i);
			for(int j = i+1; j< Count; j++){
				var asset2 = GetAtIndex(j);
				if(asset1.Id == asset2.Id){
					return true;
				}
			}
		}

		return false;
	}
}
