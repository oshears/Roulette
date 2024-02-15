using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManagerCompareCardsPhaseState : UIManagerState
{
	public UIManagerCompareCardsPhaseState(UIManager owner) : base(owner) { 
		_uiScriptableObject.flipCoinEvent.AddListener(FlipCoinEventHandler);
		_uiScriptableObject.flipCoinDoneEvent.AddListener(FlipCoinDoneEventHandler);
	}

	public override void Enter()
	{	
		// TODO: update the card banner based on the cards played!
		
		_owner.SetCardBannerActive(true);
		_owner.SetFlipCoinButtonActive(true);
		
	}

	
	public override void Execute()
	{
		// GUILayout.BeginArea(new Rect(10, 10, 500, 500));
		// GUILayout.Label("Here the game manager would compare all of the cards that each player played.");
		// GUILayout.EndArea();
	}

	public override void Exit()
	{
		_owner.SetCardBannerActive(false);
		_owner.SetFlipCoinButtonActive(false);
	}

	
	void FlipCoinEventHandler(){
		_owner.SetFlipCoinButtonActive(false);
		_owner.StartCoinFlip();
	}
	
	void FlipCoinDoneEventHandler(Coin.Side side)
	{
		if (side == Coin.Side.Heads)
		{
			_uiScriptableObject.SetBannerText("Lowest number loses!");
		}
		else
		{
			_uiScriptableObject.SetBannerText("Highest number loses!");
		}
		_uiScriptableObject.OnShowBanner();
	}

}
