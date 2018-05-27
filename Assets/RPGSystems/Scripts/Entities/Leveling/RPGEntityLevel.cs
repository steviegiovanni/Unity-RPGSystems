using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class RPGEntityLevel : MonoBehaviour {
	[SerializeField]
	private int level = 0;

	[SerializeField]
	private int levelMin = 0;

	[SerializeField]
	private int levelMax = 100;

	private int expCurrent = 0;

	private int expRequired = 0;

	public event EventHandler<RPGExpGainEventArgs> OnEntityExpGain;
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

	public int ExpCurrent{
		get { return expCurrent;}
		set{ expCurrent = value;}
	}

	public int ExpRequired{
		get{ return expRequired;}
		set{ expRequired = value;}
	}

	public abstract int GetExpRequiredForLevel (int level);

	private void Awake(){
		ExpRequired = GetExpRequiredForLevel (Level);
	}

	public void ModifyExp(int amount){
		ExpCurrent += amount;

		if (OnEntityExpGain != null) {
			OnEntityExpGain (this, new RPGExpGainEventArgs (amount));
		}

		CheckCurrentExp ();
	}

	public void SetCurrentExp(int value){
		int expGained = value - ExpCurrent;

		ExpCurrent = value;

		if (OnEntityExpGain != null) {
			OnEntityExpGain (this, new RPGExpGainEventArgs (expGained));
		}

		CheckCurrentExp ();
	}

	public void CheckCurrentExp(){
		int oldLevel = Level;

		InternalCheckCurrentExp ();

		if (oldLevel != Level && OnEntityLevelChange != null)
			OnEntityLevelChange (this, new RPGLevelChangeEventArgs (level, oldLevel));
	}

	private void InternalCheckCurrentExp(){
		while (true) {
			if (ExpCurrent > ExpRequired) {
				ExpCurrent -= ExpRequired;
				InternalIncreaseCurrentLevel ();
			} else if (ExpCurrent < 0) {
				ExpCurrent += GetExpRequiredForLevel (Level - 1);
				InternalDecreaseCurrentLevel ();
			} else {
				break;
			}
		}	
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
			ExpCurrent = GetExpRequiredForLevel (Level);
		}

		ExpRequired = GetExpRequiredForLevel (Level);
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
			ExpCurrent = 0;
		}


		ExpRequired = GetExpRequiredForLevel (Level);
		if ((oldLevel != Level) &&(OnEntityLevelDown != null)) {
			OnEntityLevelDown (this, new RPGLevelChangeEventArgs (Level, oldLevel));
		}
	}

	public void SetLevel(int targetLevel){
		SetLevel (targetLevel, true);
	}

	public void SetLevel(int targetLevel, bool clearExp){
		int oldLevel = Level;
		Level = targetLevel;
		ExpRequired = GetExpRequiredForLevel (Level);

		if (clearExp) {
			SetCurrentExp (0);
		} else {
			InternalCheckCurrentExp ();
		}

		InternalIncreaseCurrentLevel ();
		if ((oldLevel != Level) && (OnEntityLevelChange != null)) {
			OnEntityLevelChange (this, new RPGLevelChangeEventArgs (Level, oldLevel));
		}
	}
}
