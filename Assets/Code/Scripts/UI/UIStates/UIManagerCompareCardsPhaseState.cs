using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManagerCompareCardsPhaseState : UIManagerState
{
	public UIManagerCompareCardsPhaseState(UIManager owner) : base(owner) { 
		_uiScriptableObject.playedCardsReadyEvent.AddListener(PlayedCardsReadyEventHandler);
		_uiScriptableObject.flipCoinButtonClickEvent.AddListener(FlipCoinButtonEventHandler);
		_uiScriptableObject.flipCoinDoneEvent.AddListener(FlipCoinDoneEventHandler);
		_uiScriptableObject.beginRoulettePhaseEvent.AddListener(BeginRoulettePhaseEventHandler);
		// _uiScriptableObject.bannerButtonClick.AddListener(BannerButtonEventHandler);
	}

	public override void Enter()
	{	
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
		Debug.Log("Disabling Card Banner!");
		_owner.SetCardBannerActive(false);
		_owner.SetFlipCoinButtonActive(false);
	}
	
	void PlayedCardsReadyEventHandler()
	{
		_owner.SetCardBannerActive(true);
	}

	
	void FlipCoinButtonEventHandler(){
		Debug.Log("Coin Flip Button Pressed!");
		_owner.SetFlipCoinButtonActive(false);
		_owner.StartCoinFlip();
	}
	
	void FlipCoinDoneEventHandler(CoinController.Side side)
	{
		if (side == CoinController.Side.Heads)
		{
			_uiScriptableObject.SetBannerText("Lowest number loses!");
		}
		else
		{
			_uiScriptableObject.SetBannerText("Highest number loses!");
		}
		_uiScriptableObject.OnShowBanner();
	}
	
	void BeginRoulettePhaseEventHandler()
	{
		Debug.Log("UI moving into UIManagerPreGunState!");
		changeState(new UIManagerPreGunState(_owner));
	}

}
