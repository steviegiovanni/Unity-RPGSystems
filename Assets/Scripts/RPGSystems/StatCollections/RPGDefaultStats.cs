using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGDefaultStats : RPGStatCollection {
	protected override void ConfigureStats ()
	{
		RPGStat health = CreateOrGetStat (RPGStatType.Health);
		health.StatName = "health";
		health.StatValue = 100;

		RPGStat mana = CreateOrGetStat (RPGStatType.Mana);
		mana.StatName = "mana";
		mana.StatValue = 50;
	}
}
