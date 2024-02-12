using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManagerCompareCardsPhaseState : UIManagerState
{
	public UIManagerCompareCardsPhaseState(UIManager owner) : base(owner) { 
		_uiScriptableObject.flipCoinEvent.AddListener(FlipCoinEventHandler);
	}

	public override void Execute()
	{
		GUILayout.BeginArea(new Rect(10, 10, 500, 500));
		GUILayout.Label("Here the game manager would compare all of the cards that each player played.");
		GUILayout.EndArea();
	}
	
	void FlipCoinEventHandler() => _owner.StartCoinFlip();

}
