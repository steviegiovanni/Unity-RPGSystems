using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPGSystems.StatSystem;

public class UIExperienceBar : MonoBehaviour {
	public RPGEntity entity;

	public RectTransform expBarArea;
	public RectTransform expBarFill;

	public Text expBarValues;

	void Awake(){
		entity.EntityLevel.OnEntityExpGain += OnExpGain;
		UpdateUI ();
	}

	void OnExpGain(object sender, RPGExpGainEventArgs args){
		UpdateUI ();
	}

	void UpdateUI(){
		float expPercent = Mathf.Clamp ((float) entity.EntityLevel.ExpCurrent / (float) entity.EntityLevel.ExpRequired, 0f, 1f);
		float newRightOffset = -expBarArea.rect.width + expBarArea.rect.width * expPercent;
		expBarFill.offsetMax = new Vector2 ((int)newRightOffset, expBarFill.offsetMax.y);

		expBarValues.text = string.Format ("{0} / {1} (Level {2})", entity.EntityLevel.ExpCurrent, entity.EntityLevel.ExpRequired, entity.EntityLevel.Level);
	}
}
