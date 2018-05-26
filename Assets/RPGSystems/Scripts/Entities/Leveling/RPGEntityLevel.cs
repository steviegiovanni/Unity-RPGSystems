using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RPGEntityLevel : MonoBehaviour {
	[SerializeField]
	private int level = 0;

	[SerializeField]
	private int levelMin = 0;

	[SerializeField]
	private int levelMax = 100;

	public event EventHandler<RPGLevelChangeEventArgs> OnEntityLevelChange;
	public event EventHandler<RPGLevelChangeEventArgs> OnEntityLevelUp;
	public event EventHandler<RPGLevelChangeEventArgs> OnEntityLevelDown;

	public int Level{
		get { return level;}
		set{ level = value;}
	}

	public int LevelMin{
		get { return levelMin;}
		set{ levelMin = value;}
	}

	public int LevelMax{
		get { return levelMax;}
		set{ levelMax = value;}
	}

	public void IncreaseCurrentLevel(){
		int oldLevel = Level;
		InternalIncreaseCurrentLevel ();
		if ((oldLevel != Level) && (OnEntityLevelChange != null)) {
			OnEntityLevelChange (this, new RPGLevelChangeEventArgs (Level, oldLevel));
		}
	}

	private void InternalIncreaseCurrentLevel(){
		int oldLevel = Level++;

		if (Level > LevelMax) {
			Level = LevelMax;
		}

		if ((oldLevel != Level) &&(OnEntityLevelUp != null)) {
			OnEntityLevelUp (this, new RPGLevelChangeEventArgs (Level, oldLevel));
		}
	}

	public void DecreaseCurrentLevel(){
		int oldLevel = Level;
		InternalDecreaseCurrentLevel ();
		InternalIncreaseCurrentLevel ();
		if ((oldLevel != Level) && (OnEntityLevelChange != null)) {
			OnEntityLevelChange (this, new RPGLevelChangeEventArgs (Level, oldLevel));
		}
	}

	private void InternalDecreaseCurrentLevel(){
		int oldLevel = Level--;
		if (Level < LevelMin) {
			Level = LevelMin;
		}

		if ((oldLevel != Level) &&(OnEntityLevelDown != null)) {
			OnEntityLevelDown (this, new RPGLevelChangeEventArgs (Level, oldLevel));
		}
	}

	public void SetLevel(int targetLevel){
		int oldLevel = Level;
		Level = targetLevel;

		InternalIncreaseCurrentLevel ();
		if ((oldLevel != Level) && (OnEntityLevelChange != null)) {
			OnEntityLevelChange (this, new RPGLevelChangeEventArgs (Level, oldLevel));
		}
	}
}
