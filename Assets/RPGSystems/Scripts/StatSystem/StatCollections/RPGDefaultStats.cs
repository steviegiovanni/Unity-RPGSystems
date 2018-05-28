using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// RPG default stats.
	/// </summary>
	public class RPGDefaultStats : RPGStatCollection {
		/// <summary>
		/// Configures the stats.
		/// </summary>
		protected override void ConfigureStats ()
		{
			var stamina = CreateOrGetStat<RPGAttribute>(RPGStatType.Stamina);
			stamina.StatName = "Stamina";
			stamina.StatBaseValue = 10.0f;

			var wisdom = CreateOrGetStat<RPGAttribute>(RPGStatType.Wisdom);
			wisdom.StatName = "Wisdom";
			wisdom.StatBaseValue = 5.0f;

			var health = CreateOrGetStat<RPGVital>(RPGStatType.Health);
			health.StatName = "health";
			health.StatBaseValue = 100.0f;
			health.AddLinker (new RPGStatLinkerBasic (CreateOrGetStat<RPGAttribute> (RPGStatType.Stamina), 10f));
			health.UpdateLinkers ();
			health.SetCurrentValueToMax ();

			var mana = CreateOrGetStat<RPGVital>(RPGStatType.Mana);
			mana.StatName = "mana";
			mana.StatBaseValue = 2000.0f;
			mana.AddLinker (new RPGStatLinkerBasic (CreateOrGetStat<RPGAttribute> (RPGStatType.Wisdom), 50f));
			mana.UpdateLinkers ();
			mana.SetCurrentValueToMax ();
		}
	}
}