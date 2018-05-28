using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGSystems.Utility.Database;

namespace RPGSystems.StatSystem{
	[System.Serializable]
	public class RPGStatTypeAsset : BaseDatabaseAsset {
		[SerializeField]
		private string nameShort;

		[SerializeField]
		private string description;

		[SerializeField]
		private Sprite icon;

		public string NameShort{
			get{ return nameShort;}
			set{ nameShort = value;}
		}

		public string Description{
			get{ return description;}
			set{ description = value;}
		}

		public Sprite Icon{
			get{ return icon;}
			set{ icon = value;}
		}

		public RPGStatTypeAsset(): base(){
			this.NameShort = string.Empty;
			this.Description = string.Empty;
			this.Icon = null;
		}

		public RPGStatTypeAsset(int id): base(id){
			this.NameShort = string.Empty;
			this.Description = string.Empty;
			this.Icon = null;
		}

		public RPGStatTypeAsset(int id, string name): base(id, name){
			this.NameShort = string.Empty;
			this.Description = string.Empty;
			this.Icon = null;
		}

		public RPGStatTypeAsset(int id, string name, string nameShort, string description, Sprite icon): base(id, name){
			this.NameShort = nameShort;
			this.Description = description;
			this.Icon = icon;
		}
	}
}
