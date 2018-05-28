using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPGSystems.StatSystem{
	/// <summary>
	/// RPG attribute.
	/// </summary>
	public class RPGAttribute: RPGStatModifiable, IStatScalable, IStatLinkable{
		/// <summary>
		/// The stat level value.
		/// </summary>
		private int _statLevelValue;

		/// <summary>
		/// The stat linker value.
		/// </summary>
		private int _statLinkerValue;

		/// <summary>
		/// The stat linkers.
		/// </summary>
		private List<RPGStatLinker> _statLinkers;

		/// <summary>
		/// Gets the stat level value.
		/// </summary>
		/// <value>The stat level value.</value>
		public int StatLevelValue{
			get { return _statLevelValue;}
		}

		/// <summary>
		/// Gets or sets the stat base value.
		/// </summary>
		/// <value>The stat base value.</value>
		public override float StatBaseValue{
			get{return base.StatBaseValue + StatLevelValue + StatLinkerValue; }
		}

		#region IStatScalable implementation
		/// <summary>
		/// Scales the stat.
		/// </summary>
		/// <param name="level">Level.</param>
		public virtual void ScaleStat (int level)
		{
			_statLevelValue = level;
			TriggerValueChange ();
		}

		#endregion

		#region IStatLinkable implementation
		/// <summary>
		/// Adds the linker.
		/// </summary>
		/// <param name="linker">Linker.</param>
		public void AddLinker (RPGStatLinker linker)
		{
			_statLinkers.Add (linker);
			linker.OnValueChange += OnLinkerValueChange;
		}

		/// <summary>
		/// Removes the linker.
		/// </summary>
		/// <param name="linker">Linker.</param>
		public void RemoveLinker (RPGStatLinker linker)
		{
			_statLinkers.Remove (linker);
			linker.OnValueChange -= OnLinkerValueChange;
		}

		/// <summary>
		/// Clears the linkers.
		/// </summary>
		public void ClearLinkers ()
		{
			foreach (var linker in _statLinkers) {
				linker.OnValueChange -= OnLinkerValueChange;
			}

			_statLinkers.Clear ();
		}

		/// <summary>
		/// Updates the linkers.
		/// </summary>
		public void UpdateLinkers ()
		{
			_statLinkerValue = 0;
			foreach (RPGStatLinker link in _statLinkers)
				_statLinkerValue += link.Value;
			TriggerValueChange ();
		}

		/// <summary>
		/// Gets the stat linker value.
		/// </summary>
		/// <value>The stat linker value.</value>
		public int StatLinkerValue {
			get {
				return _statLinkerValue;
			}
		}

		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="RPGSystems.StatSystem.RPGAttribute"/> class.
		/// </summary>
		public RPGAttribute(){
			_statLinkers = new List<RPGStatLinker> ();
		}

		/// <summary>
		/// Raises the linker value change event.
		/// </summary>
		/// <param name="linker">Linker.</param>
		/// <param name="args">Arguments.</param>
		private void OnLinkerValueChange(object linker, EventArgs args){
			UpdateLinkers ();
		}
	}
}