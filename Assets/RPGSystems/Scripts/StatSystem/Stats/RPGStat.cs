using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RPG stat.
/// </summary>
namespace RPGSystems.StatSystem{
	public class RPGStat{
		/// <summary>
		/// The name of the stat.
		/// </summary>
		private string _statName;

		/// <summary>
		/// The stat base value.
		/// </summary>
		private int _statBaseValue;

		/// <summary>
		/// Gets or sets the name of the stat.
		/// </summary>
		/// <value>The name of the stat.</value>
		public string StatName{
			get{ return _statName; }
			set{ _statName = value;}
		}

		/// <summary>
		/// Gets the stat value.
		/// </summary>
		/// <value>The stat value.</value>
		public virtual int StatValue{
			get{ return StatBaseValue;}
		}

		/// <summary>
		/// Gets or sets the stat base value.
		/// </summary>
		/// <value>The stat base value.</value>
		public virtual int StatBaseValue{
			get{ return _statBaseValue;}
			set{ _statBaseValue = value;}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGStat"/> class.
		/// </summary>
		public RPGStat(){
			this.StatName = string.Empty;
			this.StatBaseValue = 0;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGStat"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="value">Value.</param>
		public RPGStat(string name, int value){
			this.StatName = name;
			this.StatBaseValue = value;
		}
	}
}